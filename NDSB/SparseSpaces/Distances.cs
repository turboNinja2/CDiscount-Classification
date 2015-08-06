using System;
using System.Collections.Generic;

namespace NDSB
{
    public static class Distances
    {
        /// <summary>
        /// Evaluates Sum of squares distance for sparse vectors.
        /// The sum is performed over the keys that are present in at least one of the inputs.
        /// 
        /// http://codereview.stackexchange.com/questions/99170/fast-evaluation-of-euclidean-distance-with-sparse-data
        /// For more details about the optimization of this function.
        /// </summary>
        /// <param name="sp1"></param>
        /// <param name="sp2"></param>
        /// <returns></returns>
        public static double SumSquares(Dictionary<string, double> sp1, Dictionary<string, double> sp2)
        {
            double distance = 0;

            foreach (KeyValuePair<string, double> kvp1 in sp1)
            {
                double possibleValue = 0.0d;
                sp2.TryGetValue(kvp1.Key, out possibleValue);

                double currentValue = kvp1.Value - possibleValue;

                distance += currentValue * currentValue;
            }

            foreach (KeyValuePair<string, double> kvp2 in sp2)
            {
                if (!sp1.ContainsKey(kvp2.Key))
                {
                    distance += kvp2.Value * kvp2.Value;
                }
            }
            return distance;
        }

        public static double Norm3(Dictionary<string, double> sp1, Dictionary<string, double> sp2)
        {
            double distance = 0;
            foreach (KeyValuePair<string, double> kvp1 in sp1)
            {
                if (sp2.ContainsKey(kvp1.Key))
                    distance += Math.Pow(Math.Abs(kvp1.Value - sp2[kvp1.Key]), 3);
                else
                    distance += Math.Pow(Math.Abs(kvp1.Value), 3);
            }

            foreach (KeyValuePair<string, double> kvp2 in sp2)
                if (!sp1.ContainsKey(kvp2.Key))
                    distance += Math.Pow(Math.Abs(kvp2.Value), 3);

            return distance;
        }

        public static double TaxiCab(Dictionary<string, double> sp1, Dictionary<string, double> sp2)
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
    }
}
