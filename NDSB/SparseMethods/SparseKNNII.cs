using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NDSB
{
    public static class SparseKNNII
    {
        public delegate double Distance(Dictionary<string, double> sp1, Dictionary<string, double> sp2);

        public static Dictionary<string, List<int>> _invertedIndexes = new Dictionary<string, List<int>>(1000000);

        /// <summary>
        /// Returns the labels of the nearest neighbours
        /// </summary>
        /// <param name="labels"></param>
        /// <param name="sample"></param>
        /// <param name="newPoint"></param>
        /// <param name="nbNeighbours"></param>
        /// <returns></returns>
        public static int[] NearestNeighbours(int[] labels, Dictionary<string, double>[] sample, Dictionary<string, double> newPoint, int nbNeighbours, Distance distance)
        {
            StampInverseDictionary(sample);

            string[] keys = newPoint.Keys.ToArray();

            List<int> relevantIndexes = PreselectNeighbours(keys);

            double[] distances = new double[relevantIndexes.Count];
            int[] selectedLabels = new int[relevantIndexes.Count];

            for (int i = 0; i < relevantIndexes.Count; i++)
            {
                distances[i] = distance(newPoint, sample[relevantIndexes[i]]);
                selectedLabels[i] = labels[relevantIndexes[i]];
            }
            int[] neighboursLabels = LazyBubbleSort(selectedLabels, distances, nbNeighbours);
            return neighboursLabels;
        }

        private static void StampInverseDictionary(Dictionary<string, double>[] sample)
        {
            if (_invertedIndexes.Count == 0)
            {
                for (int i = 0; i < sample.Length; i++)
                {
                    Dictionary<string, double> sparsePoint = sample[i];
                    foreach (KeyValuePair<string, double> kvp in sparsePoint)
                    {
                        string currentKey = kvp.Key;
                        if (currentKey.Length < 3) continue;
                        if (_invertedIndexes.ContainsKey(currentKey))
                        {
                            _invertedIndexes[currentKey].Add(i);
                        }
                        else
                        {
                            _invertedIndexes.Add(currentKey, new List<int>(100));
                            _invertedIndexes[currentKey].Add(i);
                        }
                    }
                }
            }
        }

        private static List<int> PreselectNeighbours(string[] keywords)
        {
            List<int> candidateIndexes = new List<int>();
            for (int i = 0; i < keywords.Length; i++)
            {
                if (_invertedIndexes.ContainsKey(keywords[i]))
                    candidateIndexes.AddRange(_invertedIndexes[keywords[i]]);
            }
            return candidateIndexes.Distinct().ToList();
        }


        /// <summary>
        /// Performs k iterations of the bubble sort algorithm 
        /// </summary>
        /// <param name="labels"></param>
        /// <param name="distances"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private static int[] LazyBubbleSort(int[] labels, double[] distances, int k)
        {
            int[] labelsCopy = new int[labels.Length];
            double[] distancesCopy = new double[distances.Length];
            labels.CopyTo(labelsCopy, 0);
            distances.CopyTo(distancesCopy, 0);

            int n = labels.Length;
            for (int j = 0; j < k; j++)
                for (int i = n - 2; i >= 0; i--)
                    if (distancesCopy[i] > distancesCopy[i + 1] )
                    {
                        double distanceTmp = distancesCopy[i + 1];
                        distancesCopy[i + 1] = distancesCopy[i];
                        distancesCopy[i] = distanceTmp;

                        int labelTmp = labelsCopy[i + 1];
                        labelsCopy[i + 1] = labelsCopy[i];
                        labelsCopy[i] = labelTmp;
                    }

            int[] result = new int[k];
            Array.Copy(labelsCopy, result, k);
            return result;
        }


    }
}
