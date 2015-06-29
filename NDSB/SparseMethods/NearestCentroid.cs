using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDSB.SparseMappings;

namespace NDSB.SparseMethods
{
    using Point = Dictionary<string, double>;
    using System.Threading.Tasks;

    public class NearestCentroid
    {
        private Dictionary<int, Point> _centroids;
        public IMapping<Point> _mapping = new IdentitySparse<Point>();

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

            _centroids = new Dictionary<int, Point>();
            
            Dictionary<int, int> labelsCount = new Dictionary<int, int>();

            for (int i = 0; i < nLabels; i++) // pre alloc
            {
                _centroids.Add(distinctLabels[i], new Dictionary<string, double>(500));
                labelsCount.Add(distinctLabels[i], 0);
            }

            for (int i = 0; i < labels.Length; i++) // training
            {
                labelsCount[labels[i]] += 1;
                LinearSpace.Add(_centroids[labels[i]], _mapping.Map(points[i]));
            }
            
            /*
            for (int i = 0; i < distinctLabels.Length; i++) // scaling
                LinearSpace.Multiply(_centroids[distinctLabels[i]], 1f / labelsCount[distinctLabels[i]]);
            */

            //for (int i = 0; i < _centroids.Count; i++)
            Parallel.For(0, _centroids.Count, i =>
            {
                _centroids[distinctLabels[i]] = LinearSpace.ToSphere(_centroids[distinctLabels[i]]);
            });
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
            pt = LinearSpace.ToSphere(pt);
            double maxSimilarity = Double.MinValue;
            int bestLabel = -1;
            for (int i = 0; i < _centroids.Count; i++)
            {
                double currentSimilarity = HilbertSpace.DotProduct(_mapping.Map(pt),_centroids.ElementAt(i).Value);
                if (currentSimilarity > maxSimilarity)
                {
                    bestLabel = _centroids.ElementAt(i).Key;
                    maxSimilarity = currentSimilarity;
                }
            }
            return bestLabel;
        }

    }
}
