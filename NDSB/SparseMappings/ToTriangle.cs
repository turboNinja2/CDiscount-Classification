using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDSB.SparseMappings
{
    public class ToTriangle : IMapping<Dictionary<string, double>>
    {
        public Dictionary<string, double> Map(Dictionary<string, double> input)
        {
            Dictionary<string, double> res = new Dictionary<string, double>();
            if (input.Count() == 0) return res;
            double sum = input.Select(kvp => kvp.Value).Sum();
            foreach (KeyValuePair<string, double> kvp in input)
                res.Add(kvp.Key, kvp.Value / sum);
            return res;
        }

    }
}
