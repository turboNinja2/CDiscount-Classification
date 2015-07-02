using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDSB.SparseMethods
{
    public static class KNNHelper
    {
        /// <summary>
        /// Performs k iterations of the bubble sort algorithm 
        /// </summary>
        /// <param name="labels"></param>
        /// <param name="distances"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] LazyBubbleSort(int[] labels, double[] distances, int k)
        {
            int[] result = new int[k];

            if (labels.Length == 0)
                return result;

            int n = labels.Length;
            for (int j = 0; j < k; j++)
                for (int i = n - 2; i >= 0; i--)
                    if (distances[i] > distances[i + 1])
                    {
                        double distanceTmp = distances[i + 1];
                        distances[i + 1] = distances[i];
                        distances[i] = distanceTmp;

                        int labelTmp = labels[i + 1];
                        labels[i + 1] = labels[i];
                        labels[i] = labelTmp;
                    }

            Array.Copy(labels, 0, result, 0, Math.Min(labels.Length, k));
            return result;
        }

        /// <summary>
        /// Given keywords, returns the line indexes containing at least one of the keywords.
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public static int[] PreselectNeighbours(string[] keywords, Dictionary<string, List<int>> invertedIndexes)
        {
            List<int> candidateIndexes = new List<int>();
            for (int i = 0; i < keywords.Length; i++)
                if (invertedIndexes.ContainsKey(keywords[i]))
                    candidateIndexes.AddRange(invertedIndexes[keywords[i]]);
            return candidateIndexes.Distinct().ToArray();
        }

    }
}
