using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NDSB.SparseMethods;

namespace NDSB
{
    public static class KNN
    {
        public delegate double Distance(Dictionary<string, double> sp1, Dictionary<string, double> sp2);

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
            int[] neighboursLabels = KNNHelper.LazyBubbleSort(labels, distances, nbNeighbours);
            return neighboursLabels;
        }
    }
}
