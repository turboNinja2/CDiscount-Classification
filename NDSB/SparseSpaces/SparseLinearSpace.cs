using System;
using System.Collections.Generic;
using System.Linq;

namespace NDSB.SparseMethods
{
    public static class SparseLinearSpace
    {

        public static void Multiply<T>(Dictionary<T, double> point, double coefficient)
        {
            for (int i = 0; i < point.Count; i++)
            {
                T key = point.Keys.ElementAt(i);
                point[key] = coefficient * point[key];
            }
        }

        public static void Add<T>(Dictionary<T, double> sp1, Dictionary<T, double> sp2)
        {
            foreach (KeyValuePair<T, double> kvp2 in sp2)
            {
                if (sp1.ContainsKey(kvp2.Key))
                    sp1[kvp2.Key] += kvp2.Value;
                else
                    sp1.Add(kvp2.Key, kvp2.Value);
            }
        }
    }
}
