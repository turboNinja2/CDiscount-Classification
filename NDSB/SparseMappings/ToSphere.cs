using System;
using System.Collections.Generic;
using System.Linq;

namespace NDSB.SparseMappings
{
    public class ToSphere : IMapping<Dictionary<string, double>>
    {
        public Dictionary<string, double> Map(Dictionary<string, double> input)
        {
            Dictionary<string, double> res = new Dictionary<string, double>();
            if (input.Count() == 0) return res;
            double norm = Math.Sqrt(input.Select(kvp => Math.Pow(kvp.Value, 2)).Sum());
            foreach (KeyValuePair<string, double> kvp in input)
                res.Add(kvp.Key, kvp.Value / norm);
            return res;
        }

        public string Description()
        {
            return "ToSphere";
        }
    }
}
