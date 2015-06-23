using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NDSB
{
    public static class SparseKNN
    {
        public delegate double Distance(Dictionary<string, double> sp1, Dictionary<string, double> sp2);

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
                    if (distancesCopy[i] > distancesCopy[i + 1])
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
            double[] distances = new double[sample.Length];
            Parallel.For(0, sample.Length, i => { distances[i] = distance(newPoint, sample[i]); });
            int[] neighboursLabels = LazyBubbleSort(labels, distances, nbNeighbours);
            return neighboursLabels;
        }
    }
}
