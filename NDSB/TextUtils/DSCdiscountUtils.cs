using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NDSB
{
    public static class DSCdiscountUtils
    {
        public static string GetLabelCDiscountDB(string input)
        {
            return input.Split(';')[3];
        }

        /// <summary>
        /// Reads a file, gets the TFIDF representation of the file and turns it to a .csr file
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <param name="maxLines"></param>
        public static void TextToTFIDFCSR(string inputFilePath, int maxLines = int.MaxValue)
        {
            string outputFilePath = Path.GetDirectoryName(inputFilePath) + "\\" + Path.GetFileNameWithoutExtension(inputFilePath) + "_sparse.txt";
            List<string> buffer = new List<string>();
            foreach (var cd in TFIDF.Transform2(LinesEnumerator.YieldLinesOfFile(inputFilePath, maxLines)))
            {
                List<string> res = cd.Select(kvp => kvp.Key + ":" + Math.Round(kvp.Value, 3)).ToList();
                string toWrite = String.Join(" ", res);
                buffer.Add(toWrite);
            }
            File.AppendAllLines(outputFilePath, buffer);
        }

        public static void ExtractLabelsFromTraining(string inputFilePath, int maxLines = int.MaxValue)
        {
            string outputFilePath = Path.GetDirectoryName(inputFilePath) + "\\" + Path.GetFileNameWithoutExtension(inputFilePath) + "_labels.txt",
                toWrite = "";

            foreach (string line in LinesEnumerator.YieldLinesOfFile(inputFilePath, maxLines))
                toWrite += GetLabelCDiscountDB(line) + Environment.NewLine;

            File.AppendAllText(outputFilePath, toWrite + Environment.NewLine);
        }

        public static int[] ReadLabels(string inputFilePath, bool header = true)
        {
            List<int> labels = new List<int>(1000000);
            foreach (string line in LinesEnumerator.YieldLinesOfFile(inputFilePath))
            {
                if (header)
                {
                    header = false;
                    continue;
                }
                int label = Convert.ToInt32(line);
                labels.Add(label);
            }
            return labels.ToArray();
        }

    }
}
