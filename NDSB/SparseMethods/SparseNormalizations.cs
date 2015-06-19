using System.Collections.Generic;
using System.Linq;

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
    }
}
