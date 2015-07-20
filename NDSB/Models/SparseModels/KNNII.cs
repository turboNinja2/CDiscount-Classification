using System;
using System.Collections.Generic;
using System.Linq;
using NDSB.SparseMethods;

namespace NDSB
{
    using Point = Dictionary<string, double>;

    public class KNNII : IModelClassification<Point>
    {
        public delegate double Distance(Dictionary<string, double> sp1, Dictionary<string, double> sp2);

        private const int _INVERTED_INDEXES_PREALLOC_ = 1000000;

        #region Private attributes
        private Distance _distance;
        private Dictionary<string, List<int>> _invertedIndexes = new Dictionary<string, List<int>>(_INVERTED_INDEXES_PREALLOC_);
        private int[] _labels;
        private Point[] _points;
        private double _minTFIDF;
        #endregion

        public KNNII(Distance distance, double minTFIDF)
        {
            _distance = distance;
            _minTFIDF = minTFIDF;
        }

        public void Train(int[] labels, Point[] points)
        {
            _labels = labels;
            _points = points;
            StampInverseDictionary(points, _minTFIDF);
        }

        public int Predict(Point pt)
        {
            return NearestLabels(_labels, _points, pt, 1, _distance)[0];
        }

        /// <summary>
        /// Returns the labels of the nearest neighbours
        /// </summary>
        /// <param name="labels"></param>
        /// <param name="sample"></param>
        /// <param name="newPoint"></param>
        /// <param name="nbNeighbours"></param>
        /// <returns></returns>
        public int[] NearestLabels(int[] labels, Point[] sample, Point newPoint, int nbNeighbours, Distance distance)
        {
            string[] keys = newPoint.Keys.ToArray();
            int[] relevantIndexes = PreselectNeighbours(keys, _invertedIndexes);

            double[] distances = new double[relevantIndexes.Length];
            int[] selectedLabels = new int[relevantIndexes.Length];

            for (int i = 0; i < relevantIndexes.Length; i++)
            {
                distances[i] = distance(newPoint, sample[relevantIndexes[i]]);
                selectedLabels[i] = labels[relevantIndexes[i]];
            }
            int[] neighboursLabels = LazyBubbleSort(selectedLabels, distances, nbNeighbours);
            return neighboursLabels;
        }

        /// <summary>
        /// Creates an inverse dictionnary and stamps it.
        /// </summary>
        /// <param name="sample"></param>
        private void StampInverseDictionary(Dictionary<string, double>[] sample, double minTFIDF)
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

        /// <summary>
        /// Performs k iterations of the bubble sort algorithm 
        /// </summary>
        /// <param name="labels"></param>
        /// <param name="distances"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private static int[] LazyBubbleSort(int[] labels, double[] distances, int k)
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
        private static int[] PreselectNeighbours(string[] keywords, Dictionary<string, List<int>> invertedIndexes)
        {
            List<int> candidateIndexes = new List<int>();
            for (int i = 0; i < keywords.Length; i++)
                if (invertedIndexes.ContainsKey(keywords[i]))
                    candidateIndexes.AddRange(invertedIndexes[keywords[i]]);
            return candidateIndexes.Distinct().ToArray();
        }


    }
}
