using System;
using System.Collections.Generic;
using System.Linq;

namespace NDSB.SparseMappings
{
    public class ToSphere<T> : IMapping<Dictionary<T, double>>
    {
        public Dictionary<T, double> Map(Dictionary<T, double> input)
        {
            Dictionary<T, double> res = new Dictionary<T, double>();
            if (input.Count() == 0) return res;
            double norm = Math.Sqrt(input.Select(kvp => Math.Pow(kvp.Value, 2)).Sum());
            foreach (KeyValuePair<T, double> kvp in input)
                res.Add(kvp.Key, kvp.Value / norm);
            return res;
        }

        public string Description()
        {
            return "ToSphere";
        }
    }
}
