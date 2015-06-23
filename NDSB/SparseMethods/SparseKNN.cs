using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NDSB
{
    public static class SparseKNN
    {
        private static int[] LazyBubbleSort(int[] labels, double[] distances, int elementsToSort)
        {
            int[] labelsCopy = new int[labels.Length];
            double[] distancesCopy = new double[distances.Length];
            labels.CopyTo(labelsCopy, 0);
            distances.CopyTo(distancesCopy, 0);

            int n = labels.Length;
            for (int j = 0; j < elementsToSort; j++)
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

            int[] result = new int[elementsToSort];
            Array.Copy(labelsCopy, result, elementsToSort);
            return result;
        }



        public static int[] NearestNeighbours(int[] labels, Dictionary<string, double>[] sample, Dictionary<string, double> newPoint, int nbNeighbours)
        {
            double[] distances = new double[sample.Length];
            Parallel.For(0, sample.Length, i => { distances[i] = SparseDistances.ManhattanDistance(newPoint, sample[i]); });
            int[] neighboursLabels = LazyBubbleSort(labels, distances, nbNeighbours);
            return neighboursLabels;
        }
    }
}
