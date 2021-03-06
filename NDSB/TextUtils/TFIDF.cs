﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Iveonik.Stemmers;

namespace NDSB
{
    /// <summary>
    /// Copyright (c) 2013 Kory Becker http://www.primaryobjects.com/kory-becker.aspx
    /// 
    /// Permission is hereby granted, free of charge, to any person obtaining
    /// a copy of this software and associated documentation files (the
    /// "Software"), to deal in the Software without restriction, including
    /// without limitation the rights to use, copy, modify, merge, publish,
    /// distribute, sublicense, and/or sell copies of the Software, and to
    /// permit persons to whom the Software is furnished to do so, subject to
    /// the following conditions:
    /// 
    /// The above copyright notice and this permission notice shall be
    /// included in all copies or substantial portions of the Software.
    /// 
    /// Description:
    /// Performs a TF*IDF (Term Frequency * Inverse Document Frequency) transformation on an array of documents.
    /// Each document string is transformed into an array of doubles, cooresponding to their associated TF*IDF values.
    /// 
    /// Usage:
    /// string[] documents = LoadYourDocuments();
    ///
    /// double[][] inputs = TFIDF.Transform(documents);
    /// inputs = TFIDF.Normalize(inputs);
    /// 
    /// Edit : in its current version, it does not perform stemming any more.
    /// 
    /// </summary>
    public static class TFIDF
    {
        /// <summary>
        /// Reads a file, gets the TFIDF representation of the file and turns it to a .csr file
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <param name="maxLines"></param>
        public static string TextToTFIDFCSR(string inputFilePath, bool stem, int minVoc = 3, int maxLines = int.MaxValue)
        {
            string outputFilePath = Path.GetDirectoryName(inputFilePath) + "\\" + Path.GetFileNameWithoutExtension(inputFilePath) + stem.ToString() + minVoc.ToString() + "_tfidf.csr";


            List<string> buffer = new List<string>();
            foreach (var cd in TFIDF.Transform2(LinesEnumerator.YieldLines(inputFilePath, maxLines), stem, minVoc))
            {
                List<string> res = cd.Select(kvp => kvp.Key + ":" + Math.Round(kvp.Value, 3)).ToList();
                string toWrite = String.Join(" ", res);
                buffer.Add(toWrite);
            }
            File.WriteAllLines(outputFilePath, buffer);
            return outputFilePath;
        }

        /// <summary>
        /// Document vocabulary, containing each word's IDF value.
        /// </summary>
        private static ConcurrentDictionary<string, double> _vocabularyIDF = new ConcurrentDictionary<string, double>();

        public static void ClearVocabulary()
        {
            _vocabularyIDF.Clear();
        }

        /// <summary>
        /// Transforms a list of documents into their associated TF*IDF values.
        /// If a vocabulary does not yet exist, one will be created, based upon the documents' words.
        /// </summary>
        /// <param name="documents">string[]</param>
        /// <param name="vocabularyThreshold">Minimum number of occurences of the term within all documents</param>
        /// <returns>double[][]</returns>
        public static IEnumerable<Dictionary<string, double>> Transform2(IEnumerable<string> documents, bool stem, int vocabularyThreshold)
        {
            List<List<string>> stemmedDocs;
            List<string> vocabulary;

            // Get the vocabulary and stem the documents at the same time.
            vocabulary = GetVocabulary(documents, out stemmedDocs, vocabularyThreshold, stem);

            if (_vocabularyIDF.Count == 0)
            {
                // Calculate the IDF for each vocabulary term.
                int vocabularySize = vocabulary.Count;

                Parallel.For(0, vocabularySize, i =>
                {
                    string term = vocabulary[i];
                    double numberOfDocsContainingTerm = stemmedDocs.Where(d => d.Contains(term)).Count();
                    _vocabularyIDF[term] = Math.Log((double)stemmedDocs.Count / ((double)1 + numberOfDocsContainingTerm));
                });
            }

            // Transform each document into a vector of tfidf values.
            return GetSparseTFIDFVectors(stemmedDocs, _vocabularyIDF);
        }

        /// <summary>
        /// Converts a list of stemmed documents (lists of stemmed words) and their associated vocabulary + idf values, into an array of TF*IDF values.
        /// </summary>
        /// <param name="docs">List of List of string</param>
        /// <param name="vocabularyIDF">Dictionary of string, double (term, IDF)</param>
        /// <returns>double[][]</returns>
        private static IEnumerable<Dictionary<string, double>> GetSparseTFIDFVectors(List<List<string>> docs, ConcurrentDictionary<string, double> vocabularyIDF)
        {
            // Transform each document into a vector of tfidf values.
            List<List<double>> vectors = new List<List<double>>();
            foreach (var doc in docs)
            {
                //List<double> vector = new List<double>();
                double[] vector = new double[vocabularyIDF.Count()];
                Dictionary<string, double> sparseLine = new Dictionary<string, double>();

                foreach (string element in doc.Distinct())
                {
                    double tf = doc.Where(d => d == element).Count();
                    if (vocabularyIDF.ContainsKey(element))
                    {
                        double tfidf = tf * vocabularyIDF[element];
                        if (tfidf != 0)
                            sparseLine.Add(element, tfidf);
                    }
                }
                yield return sparseLine;
            }
        }

        /// <summary>
        /// Saves the TFIDF vocabulary to disk.
        /// </summary>
        /// <param name="filePath">File path</param>
        public static void Save(string filePath = "vocabulary.dat")
        {
            // Save result to disk.
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, _vocabularyIDF);
            }
        }

        /// <summary>
        /// Loads the TFIDF vocabulary from disk.
        /// </summary>
        /// <param name="filePath">File path</param>
        public static void Load(string filePath = "vocabulary.dat")
        {
            // Load from disk.
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                _vocabularyIDF = (ConcurrentDictionary<string, double>)formatter.Deserialize(fs);
            }
        }

        #region Private Helpers

        /// <summary>
        /// Parses and tokenizes a list of documents, returning a vocabulary of words.
        /// </summary>
        /// <param name="docs">string[]</param>
        /// <param name="stemmedDocs">List of List of string</param>
        /// <returns>Vocabulary (list of strings)</returns>
        private static List<string> GetVocabulary(IEnumerable<string> docs, out List<List<string>> stemmedDocs, int vocabularyThreshold, bool stem)
        {
            FrenchStemmer fs = new FrenchStemmer();

            List<string> vocabulary = new List<string>();
            Dictionary<string, int> wordCountList = new Dictionary<string, int>();
            stemmedDocs = new List<List<string>>();

            int docIndex = 0;

            foreach (var doc in docs)
            {
                List<string> stemmedDoc = new List<string>();
                docIndex++;
                string[] parts2 = Tokenize(doc);

                List<string> words = new List<string>();
                foreach (string part in parts2)
                {
                    // Strip non-alphanumeric characters.
                    string stripped = Regex.Replace(part, "[^a-zA-Z0-9]", "");
                    stripped = stripped.ToLower();
                    words.Add(stripped);

                    if (stripped.Length > 0)
                    {
                        if (stem)
                            stripped = fs.Stem(stripped);

                        // Build the word count list.
                        if (wordCountList.ContainsKey(stripped))
                            wordCountList[stripped]++;
                        else
                            wordCountList.Add(stripped, 0);

                        stemmedDoc.Add(stripped);
                    }
                }
                stemmedDocs.Add(stemmedDoc);
            }

            // Get the top words.
            var vocabList = wordCountList.Where(w => w.Value >= vocabularyThreshold);
            foreach (var item in vocabList)
                vocabulary.Add(item.Key);

            return vocabulary;
        }

        /// <summary>
        /// Tokenizes a string, returning its list of words.
        /// </summary>
        /// <param name="text">string</param>
        /// <returns>string[]</returns>
        public static string[] Tokenize(string text)
        {
            // Strip all HTML.
            text = Regex.Replace(text, "<[^<>]+>", "");

            // Strip numbers.
            text = Regex.Replace(text, "[0-9]+", "number");

            // Strip urls.
            text = Regex.Replace(text, @"(http|https)://[^\s]*", "httpaddr");

            // Strip email addresses.
            text = Regex.Replace(text, @"[^\s]+@[^\s]+", "emailaddr");

            // Strip dollar sign.
            text = Regex.Replace(text, "[$]+", "dollar");

            // Strip usernames.
            text = Regex.Replace(text, @"@[^\s]+", "username");

            // Tokenize and also get rid of any punctuation
            return text.Split(" @$/#.-:&*+=[]?!(){},''\">_<;%\\".ToCharArray());
        }

        #endregion
    }
}