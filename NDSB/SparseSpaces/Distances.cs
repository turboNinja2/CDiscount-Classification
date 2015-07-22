using System;
using System.Collections.Generic;

namespace NDSB
{
    public static class Distances
    {
        public static double Euclide(Dictionary<string, double> sp1, Dictionary<string, double> sp2)
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
