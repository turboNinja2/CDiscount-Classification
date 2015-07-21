using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDSB.SparseMappings
{
    public class ToCube : IMapping<Dictionary<string, double>>
    {
        public Dictionary<string, double> Map(Dictionary<string, double> input)
        {
            Dictionary<string, double> res = new Dictionary<string, double>();
            if (input.Count() == 0) return res;
            double max = input.Select(kvp => kvp.Value).Max();
            foreach (KeyValuePair<string, double> kvp in input)
                res.Add(kvp.Key, kvp.Value / max);
            return res;
        }

        public string Description()
        {
            return "ToCube";
        }

    }
}
