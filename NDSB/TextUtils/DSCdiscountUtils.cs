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

        public static int[] ReadLabelsFromTraining(string inputFilePath, bool header = true)
        {
            List<int> labels = new List<int>(1000000);
            foreach (string line in LinesEnumerator.YieldLines(inputFilePath))
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
