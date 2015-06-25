using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDSB.SparseMethods
{
    public static class SparseLinearSpace
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

        public static void Multiply(double coefficient, Dictionary<string, double> point)
        {
            foreach (KeyValuePair<string, double> kvp in point)
                point[kvp.Key] = coefficient * point[kvp.Key];
        }

        public static void Add(Dictionary<string, double> sp1, Dictionary<string, double> sp2)
        {
            Dictionary<string, double> result = new Dictionary<string, double>(sp1.Count + sp2.Count);
            foreach (KeyValuePair<string, double> kvp1 in sp1)
                result.Add(kvp1.Key, kvp1.Value);

        
        
        }
    }
}
