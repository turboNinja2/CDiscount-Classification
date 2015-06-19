using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDSB
{
    class SparseKNN
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
                        double tmp = distancesCopy[i + 1];
                        distancesCopy[i + 1] = distancesCopy[i];
                        distancesCopy[i] = tmp;

                        int labelTmp = labelsCopy[i + 1];
                        labelsCopy[i + 1] = labelsCopy[i];
                        labelsCopy[i] = labelTmp;
                    }

            int[] result = new int[elementsToSort];
            Array.Copy(labelsCopy, result, elementsToSort);
            return result;
        }

        private static double EuclideDistance(Dictionary<string, double> sp1, Dictionary<string, double> sp2)
        {
            double distance = 0;
            foreach (KeyValuePair<string, double> kvp1 in sp1)
            {
                if (sp2.ContainsKey(kvp1.Key))
                    distance += Math.Pow((kvp1.Value - sp2[kvp1.Key]), 2);
                else
                    distance += Math.Pow((kvp1.Value), 2);
            }

            foreach (KeyValuePair<string, double> kvp2 in sp2)
                if (!sp1.ContainsKey(kvp2.Key))
                    distance += Math.Pow((kvp2.Value), 2);

            return distance;
        }

        public static Dictionary<string, double> ToCube(Dictionary<string, double> input)
        {
            Dictionary<string, double> res = new Dictionary<string, double>();
            if (input.Count() == 0) return res;
            
            double max = input.Select(kvp => kvp.Value).Max();
                        foreach (KeyValuePair<string, double> kvp in input)
                res.Add(kvp.Key, kvp.Value / max);
            return res;
        }

        private static double ManhattanDistance(Dictionary<string, double> sp1, Dictionary<string, double> sp2)
        {
            double distance = 0;
            foreach (KeyValuePair<string, double> kvp1 in sp1)
            {
                if (sp2.ContainsKey(kvp1.Key))
                    distance += Math.Abs(kvp1.Value - sp2[kvp1.Key]);
                else
                    distance += Math.Abs(kvp1.Value);
            }

            foreach (KeyValuePair<string, double> kvp2 in sp2)
                if (!sp1.ContainsKey(kvp2.Key))
                    distance += Math.Abs(kvp2.Value);

            return distance;
        }


        public static int Predict(int[] labels, Dictionary<string, double>[] sample, Dictionary<string, double> newPoint, int nbNeighbours)
        {
            double[] distances = new double[sample.Length];

            Parallel.For(0, sample.Length, i => { distances[i] = ManhattanDistance(newPoint, sample[i]); });

            int[] neighboursLabels = LazyBubbleSort(labels, distances, nbNeighbours);
            int mostLikely = neighboursLabels.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
            return mostLikely;
        }
    }
}
