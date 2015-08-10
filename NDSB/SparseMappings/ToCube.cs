using System.Collections.Generic;
using System.Linq;

namespace NDSB.SparseMappings
{
    public class ToCube<T> : IMapping<Dictionary<T, double>>
    {
        public Dictionary<T, double> Map(Dictionary<T, double> input)
        {
            Dictionary<T, double> res = new Dictionary<T, double>();
            if (input.Count() == 0) return res;
            double max = input.Select(kvp => kvp.Value).Max();
            foreach (KeyValuePair<T, double> kvp in input)
                res.Add(kvp.Key, kvp.Value / max);
            return res;
        }

        public string Description()
        {
            return "ToCube";
        }
    }
}
