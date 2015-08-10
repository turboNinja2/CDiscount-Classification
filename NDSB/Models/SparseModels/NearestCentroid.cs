using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NDSB.SparseMappings;

namespace NDSB.SparseMethods
{
    public class NearestCentroid<T> : IModelClassification<Dictionary<T, double>>
    {
        private const int _PRE_ALLOC_NB_CENTROIDS_ = 6000;
        private const int _PRE_ALLOC_COMPONENTS_ = 1000;

        private static ParallelOptions _parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = Globals.NbCores };

        #region Private members
        private Dictionary<int, Dictionary<T, double>> _centroids;
        private IMapping<Dictionary<T, double>> _mapping;
        #endregion

        public NearestCentroid(IMapping<Dictionary<T, double>> map)
        {
            _mapping = map;
        }

        /// <summary>
        /// Generates, normalizes and stores the centroids.
        /// </summary>
        /// <param name="labels"></param>
        /// <param name="points"></param>
        public void Train(int[] labels, Dictionary<T, double>[] points)
        {
            int[] distinctLabels = labels.Distinct().ToArray();
            int nLabels = distinctLabels.Length;

            _centroids = new Dictionary<int, Dictionary<T, double>>(_PRE_ALLOC_NB_CENTROIDS_);

            for (int i = 0; i < nLabels; i++) // pre alloc
                _centroids.Add(distinctLabels[i], new Dictionary<T, double>(_PRE_ALLOC_COMPONENTS_));

            for (int i = 0; i < labels.Length; i++) // training
                SparseLinearSpace.Add(_centroids[labels[i]], _mapping.Map(points[i]));

            ToSphere<T> tsMap = new ToSphere<T>();
            Parallel.For(0, _centroids.Count, _parallelOptions, i => { _centroids[distinctLabels[i]] = tsMap.Map(_centroids[distinctLabels[i]]); });
        }

        /// <summary>
        /// Returns the label of the nearest centroid of the point.
        /// Note that since the norms of the point and the centroid are 1, it is equivalent (and faster) 
        /// to maximize the dot product.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public int Predict(Dictionary<T, double> point)
        {
            point = _mapping.Map(point);
            ToSphere<T> tsMap = new ToSphere<T>();

            point = tsMap.Map(point);

            double maxSimilarity = Double.MinValue;
            int bestLabel = -1;
            for (int i = 0; i < _centroids.Count; i++)
            {
                double currentSimilarity = HilbertSpace.DotProduct(point, _centroids.ElementAt(i).Value);
                if (currentSimilarity > maxSimilarity)
                {
                    bestLabel = _centroids.ElementAt(i).Key;
                    maxSimilarity = currentSimilarity;
                }
            }
            return bestLabel;
        }

        public string Description()
        {
            return "NearCent_" + _mapping.Description();
        }
    }
}
