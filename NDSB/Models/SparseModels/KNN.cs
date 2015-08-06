using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NDSB.Models.SparseModels;
using NDSB.SparseMappings;

namespace NDSB
{
    using Point = Dictionary<string, double>;
    using System.Diagnostics;

    public class KNN : IModelClassification<Point>
    {
        public delegate double Distance(Dictionary<string, double> sp1, Dictionary<string, double> sp2);

        private const int _INVERTED_INDEXES_PREALLOC_ = 100000;

        #region Private attributes

        private int[] _labels;
        private Point[] _points;

        private Dictionary<string, int[]> _invertedIndexes = new Dictionary<string, int[]>();

        private Distance _distance;
        private double _minTFIDF;
        private int _nbNeighbours;

        private IMapping<Point> _mapping;

        #endregion

        public KNN(Distance distance, int nbNeighbours, double minTFIDF, IMapping<Point> mapping)
        {
            _distance = distance;
            _minTFIDF = minTFIDF;
            _nbNeighbours = nbNeighbours;
            _mapping = mapping;
        }

        /// <summary>
        /// Creates a shallow copy of the data and creates an inverted dictionary.
        /// Be careful, the data is normalized ! Re-import the data after using a KNN (or use it after all the other methods)
        /// </summary>
        /// <param name="labels"></param>
        /// <param name="points"></param>
        public void Train(int[] labels, Point[] points)
        {
            _labels = labels;

            Parallel.For(0, points.Length, i => { points[i] = _mapping.Map(points[i]); });

            _points = points;
            _invertedIndexes = SmartIndexes.InverseKeys(points, _minTFIDF, _INVERTED_INDEXES_PREALLOC_);
        }

        public int Predict(Point pt)
        {
            pt = _mapping.Map(pt);
            return NearestLabels(_labels, _points, pt, _nbNeighbours, _distance).GroupBy(item => item).OrderByDescending(g => g.Count()).Select(g => g.Key).First();
        }

        public string Description()
        {
            return "KNN_min" + _minTFIDF + "_k" + _nbNeighbours + "_dist" + _distance.Method.Name + "_map" + _mapping.Description();
        }

        /// <summary>
        /// Returns the labels of the nearest neighbours
        /// </summary>
        /// <param name="labels"></param>
        /// <param name="sample"></param>
        /// <param name="newPoint"></param>
        /// <param name="nbNeighbours"></param>
        /// <returns></returns>
        /// 
        private int[] NearestLabels(int[] labels, Point[] sample, Point newPoint, int nbNeighbours, Distance distance)
        {
            string[] keys = newPoint.Keys.ToArray();

            int[] relevantIndexes = PreselectNeighbours(keys, _invertedIndexes);
            double[] distances = new double[relevantIndexes.Length];
            int[] selectedLabels = new int[relevantIndexes.Length];

            for (int i = 0; i < relevantIndexes.Length; i++)
            {
                int relevantIndex = relevantIndexes[i];
                distances[i] = distance(newPoint, sample[relevantIndex]);
                selectedLabels[i] = labels[relevantIndex];
            }

            int[] neighboursLabels = LazyBubbleSort(selectedLabels, distances, nbNeighbours);

            return neighboursLabels;
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
        private static int[] PreselectNeighbours(string[] keywords, Dictionary<string, int[]> invertedIndexes)
        {

            List<int> candidateIndexes = new List<int>();
            for (int i = 0; i < keywords.Length; i++)
                if (invertedIndexes.ContainsKey(keywords[i]))
                    candidateIndexes.AddRange(invertedIndexes[keywords[i]]);
            return candidateIndexes.Distinct().ToArray();

        }
    }
}
