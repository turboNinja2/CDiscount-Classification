using System;
using System.Collections.Generic;
using System.Linq;
using NDSB.Kernels;
using NDSB.SparseMethods;

namespace NDSB
{
    public class KNNII
    {
        public delegate double Distance(Dictionary<string, double> sp1, Dictionary<string, double> sp2);

        public Dictionary<string, List<int>> _invertedIndexes = new Dictionary<string, List<int>>(1000000);

        /// <summary>
        /// Returns the labels of the nearest neighbours
        /// </summary>
        /// <param name="labels"></param>
        /// <param name="sample"></param>
        /// <param name="newPoint"></param>
        /// <param name="nbNeighbours"></param>
        /// <returns></returns>
        public int[] NearestLabels(int[] labels, Dictionary<string, double>[] sample, Dictionary<string, double> newPoint, int nbNeighbours, Distance distance, double minTFIDF = 0)
        {
            string[] keys = newPoint.Keys.ToArray();
            int[] relevantIndexes = KNNHelper.PreselectNeighbours(keys, _invertedIndexes);

            double[] distances = new double[relevantIndexes.Length];
            int[] selectedLabels = new int[relevantIndexes.Length];

            for (int i = 0; i < relevantIndexes.Length; i++)
            {
                distances[i] = distance(newPoint, sample[relevantIndexes[i]]);
                selectedLabels[i] = labels[relevantIndexes[i]];
            }
            int[] neighboursLabels = KNNHelper.LazyBubbleSort(selectedLabels, distances, nbNeighbours);
            return neighboursLabels;
        }

        /// <summary>
        /// Creates an inverse dictionnary and stamps it.
        /// </summary>
        /// <param name="sample"></param>
        public void StampInverseDictionary(Dictionary<string, double>[] sample, double minTFIDF)
        {
            if (_invertedIndexes.Count == 0)
            {
                for (int i = 0; i < sample.Length; i++)
                {
                    Dictionary<string, double> sparsePoint = sample[i];
                    foreach (KeyValuePair<string, double> kvp in sparsePoint)
                    {
                        string currentKey = kvp.Key;
                        if (kvp.Value < minTFIDF) continue;
                        if (_invertedIndexes.ContainsKey(currentKey))
                            _invertedIndexes[currentKey].Add(i);
                        else
                        {
                            _invertedIndexes.Add(currentKey, new List<int>(100));
                            _invertedIndexes[currentKey].Add(i);
                        }
                    }
                }
            }
        }


    }
}
