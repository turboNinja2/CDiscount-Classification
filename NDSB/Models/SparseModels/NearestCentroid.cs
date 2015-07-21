using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NDSB.SparseMappings;
using System.Reflection;

namespace NDSB.SparseMethods
{
    using Point = Dictionary<string, double>;

    public class NearestCentroid : IModelClassification<Point>
    {
        private const int _PRE_ALLOC_NB_CENTROIDS_ = 6000;
        private const int _PRE_ALLOC_COMPONENTS_ = 1000;

        private static ParallelOptions _parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = 6 };

        #region Private members
        private Dictionary<int, Point> _centroids;
        private IMapping<Point> _mapping;
        #endregion

        public NearestCentroid(IMapping<Point> map)
        {
            _mapping = map;
        }

        /// <summary>
        /// Generates, normalizes and stores the centroids.
        /// </summary>
        /// <param name="labels"></param>
        /// <param name="points"></param>
        public void Train(int[] labels, Point[] points)
        {
            int[] distinctLabels = labels.Distinct().ToArray();
            int nLabels = distinctLabels.Length;

            _centroids = new Dictionary<int, Point>(_PRE_ALLOC_NB_CENTROIDS_);

            for (int i = 0; i < nLabels; i++) // pre alloc
                _centroids.Add(distinctLabels[i], new Point(_PRE_ALLOC_COMPONENTS_));

            for (int i = 0; i < labels.Length; i++) // training
                LinearSpace.Add(_centroids[labels[i]], _mapping.Map(points[i]));

            ToSphere tsMap = new ToSphere();
            Parallel.For(0, _centroids.Count, _parallelOptions, i => { _centroids[distinctLabels[i]] = tsMap.Map(_centroids[distinctLabels[i]]); });
        }

        /// <summary>
        /// Returns the label of the nearest centroid of the point.
        /// Note that since the norms of the point and the centroid are 1, it is equivalent (and faster) 
        /// to maximize the dot product.
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public int Predict(Point pt)
        {
            pt = _mapping.Map(pt);
            ToSphere tsMap = new ToSphere();

            pt = tsMap.Map(pt);

            double maxSimilarity = Double.MinValue;
            int bestLabel = -1;
            for (int i = 0; i < _centroids.Count; i++)
            {
                double currentSimilarity = HilbertSpace.DotProduct(pt, _centroids.ElementAt(i).Value);
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
            return "NearestCentroid_Map" + _mapping.Description();
        }
    }
}
