using System;
using System.Collections.Generic;
using System.Linq;

namespace NDSB.SparseMethods
{
    public static class LinearSpace
    {
        public static Dictionary<string, double> ToCube(Dictionary<string, double> input)
        {
            Dictionary<string, double> res = new Dictionary<string, double>();
            if (input.Count() == 0) return res;
            double max = input.Select(kvp => kvp.Value).Max();
            foreach (KeyValuePair<string, double> kvp in input)
                res.Add(kvp.Key, kvp.Value / max);
            return res;
        }

        public static Dictionary<string, double> ToTriangle(Dictionary<string, double> input)
        {
            Dictionary<string, double> res = new Dictionary<string, double>();
            if (input.Count() == 0) return res;
            double sum = input.Select(kvp => kvp.Value).Sum();
            foreach (KeyValuePair<string, double> kvp in input)
                res.Add(kvp.Key, kvp.Value / sum);
            return res;
        }

        public static Dictionary<string, double> ToSphere(Dictionary<string, double> input)
        {
            Dictionary<string, double> res = new Dictionary<string, double>();
            if (input.Count() == 0) return res;
            double norm = Math.Sqrt(input.Select(kvp => Math.Pow(kvp.Value, 2)).Sum());
            foreach (KeyValuePair<string, double> kvp in input)
                res.Add(kvp.Key, kvp.Value / norm);
            return res;
        }

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
