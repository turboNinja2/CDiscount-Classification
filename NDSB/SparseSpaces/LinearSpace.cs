using System;
using System.Collections.Generic;
using System.Linq;

namespace NDSB.SparseMethods
{
    public static class LinearSpace
    {

        public static void Multiply(Dictionary<string, double> point, double coefficient)
        {
            for (int i = 0; i < point.Count; i++)
            {
                string key = point.Keys.ElementAt(i);
                point[key] = coefficient * point[key];
            }
        }

        public static void Add(Dictionary<string, double> sp1, Dictionary<string, double> sp2)
        {
            foreach (KeyValuePair<string, double> kvp2 in sp2)
            {
                if (sp1.ContainsKey(kvp2.Key))
                    sp1[kvp2.Key] += kvp2.Value;
                else
                    sp1.Add(kvp2.Key, kvp2.Value);
            }
        }
    }
}
