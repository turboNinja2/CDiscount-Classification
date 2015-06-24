using System.Collections.Generic;
using System.Linq;
using System;

namespace NDSB.SparseMethods
{
    public static class SparseNormalizations
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
            double norm = Math.Sqrt(input.Select(kvp => Math.Pow(kvp.Value,2)).Sum());
            foreach (KeyValuePair<string, double> kvp in input)
                res.Add(kvp.Key, kvp.Value / norm);
            return res;
        }
    }
}
