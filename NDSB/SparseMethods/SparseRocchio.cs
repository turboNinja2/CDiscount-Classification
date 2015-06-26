using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDSB.SparseMethods
{
    using Point = Dictionary<string, double>;

    public class SparseCentroids
    {
        private Dictionary<int, Point> _centroids;

        public void Train(int[] labels, Dictionary<string, double>[] points)
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
                SparseVectorial.Add(_centroids[labels[i]], points[i]);
            }

            for (int i = 0; i < distinctLabels.Length; i++) // scaling
                SparseVectorial.Multiply(_centroids[distinctLabels[i]], 1f / labelsCount[distinctLabels[i]]);
        }

        public int Predict(Point pt)
        {
            double minDistance = Double.MaxValue;
            int bestLabel = -1;
            for (int i = 0; i < _centroids.Count; i++)
            {
                double currentDistance = SparseHilbert.DotProduct(pt,_centroids.ElementAt(i).Value);
                if (currentDistance < minDistance)
                    bestLabel = _centroids.ElementAt(i).Key;
            }
            return bestLabel;
        }

    }
}
