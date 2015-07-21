using System;
using System.Collections.Generic;
using System.IO;

namespace NDSB
{
    public static class DSCdiscountUtils
    {
        public static string GetLabelCDiscountDB(string input)
        {
            return input.Split(';')[3];
        }

        public static string ExtractLabelsFromTraining(string inputFilePath, int maxLines = int.MaxValue)
        {
            string outputFilePath = Path.GetDirectoryName(inputFilePath) + "\\" + Path.GetFileNameWithoutExtension(inputFilePath) + "_labels.txt";
            List<string> toWrite = new List<string>();

            foreach (string line in LinesEnumerator.YieldLinesOfFile(inputFilePath, maxLines))
                toWrite.Add(GetLabelCDiscountDB(line));

            File.WriteAllLines(outputFilePath, toWrite);
            return outputFilePath;
        }

        public static int[] ReadLabelsFromTraining(string inputFilePath, bool header = true)
        {
            List<int> labels = new List<int>(1000000);
            foreach (string line in LinesEnumerator.YieldLinesOfFile(inputFilePath))
            {
                if (header)
                {
                    header = false;
                    continue;
                }
                int label = Convert.ToInt32(GetLabelCDiscountDB(line));
                labels.Add(label);
            }
            return labels.ToArray();
        }
    }
}
