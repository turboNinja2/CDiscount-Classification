using System;
using System.Collections.Generic;
using System.Linq;
using DataScienceECom;

namespace NDSB.Models.SparseModels
{
    public class BagOfWords<T> : IModelClassification<Dictionary<T, double>> where T : IComparable
    {
        private const int _INVERTED_INDEXES_PREALLOC_ = 100000;

        private double _minTFIDF;
        private double _maxGini;
        private int _maxDepth;
        private int _minOccurences;
        private int _maxOccurences;

        private Dictionary<T, int[]> _invertedIndexes = new Dictionary<T, int[]>();
        Dictionary<List<T>, EmpiricScore<int>> _bagsHistogram;

        public BagOfWords(int maxDepth, int minOccurences, int maxOccurences, double maxGini, double minTFIDF)
        {
            _minTFIDF = minTFIDF;
            _minOccurences = minOccurences;
            _maxOccurences = maxOccurences;
            _maxGini = maxGini;
            _maxDepth = maxDepth;
        }

        public void Train(int[] labels, Dictionary<T, double>[] points)
        {
            _invertedIndexes = SmartIndexes.InverseKeys(points, _minTFIDF, _INVERTED_INDEXES_PREALLOC_);

            T[] keys = _invertedIndexes.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
                if (_invertedIndexes[keys[i]].Length > _maxOccurences || _invertedIndexes[keys[i]].Length < _minOccurences)
                    _invertedIndexes.Remove(keys[i]);

            Dictionary<List<T>, int[]> invertedPairs = SmartIndexes.InversePairs(_invertedIndexes, _minOccurences);

            _bagsHistogram = new Dictionary<List<T>, EmpiricScore<int>>(new ListComparer<T>());

            foreach (KeyValuePair<List<T>, int[]> invertedPair in invertedPairs)
            {
                int[] relevantLabels = SmartIndexes.GetElementsAt<int>(labels, invertedPair.Value);
                EmpiricScore<int> histogram = new EmpiricScore<int>(relevantLabels);
                if (histogram.Gini() < _maxGini)
                    _bagsHistogram.Add(invertedPair.Key, histogram.Normalize());
            }

            Dictionary<List<T>, int[]> invertedTriple = SmartIndexes.InverseBags(_invertedIndexes, invertedPairs, _minOccurences);

            foreach (KeyValuePair<List<T>, int[]> invertedBag in invertedTriple)
            {
                int[] relevantLabels = SmartIndexes.GetElementsAt<int>(labels, invertedBag.Value);
                EmpiricScore<int> histogram = new EmpiricScore<int>(relevantLabels);
                if (histogram.Gini() < _maxGini)
                    _bagsHistogram.Add(invertedBag.Key, histogram.Normalize());
            }

            Dictionary<List<T>, int[]> inverted4uple = SmartIndexes.InverseBags(_invertedIndexes, invertedTriple, _minOccurences);

            foreach (KeyValuePair<List<T>, int[]> invertedBag in inverted4uple)
            {
                int[] relevantLabels = SmartIndexes.GetElementsAt<int>(labels, invertedBag.Value);
                EmpiricScore<int> histogram = new EmpiricScore<int>(relevantLabels);
                if (histogram.Gini() < _maxGini)
                    _bagsHistogram.Add(invertedBag.Key, histogram.Normalize());
            }

        }

        public string Description()
        {
            return "BOW_" + _maxOccurences + "_" + _minOccurences + "_" + _maxGini + "_" + _minTFIDF;
        }

        public int Predict(Dictionary<T, double> point)
        {
            List<List<T>> bags = ListExtensions.CreateSortedBags<T>(point.Keys.ToList());

            List<EmpiricScore<int>> histograms = new List<EmpiricScore<int>>();
            foreach (List<T> bag in bags)
                if (_bagsHistogram.ContainsKey(bag))
                    histograms.Add(_bagsHistogram[bag]);

            return EmpiricScore<int>.Merge(histograms).MostLikelyElement();
        }
    }
}
