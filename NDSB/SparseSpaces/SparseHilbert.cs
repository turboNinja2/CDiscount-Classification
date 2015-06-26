using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDSB.SparseMethods
{
    using Vector = Dictionary<string, double>;

    public static class SparseHilbert
    {
        public static double DotProduct(Vector sp1, Vector sp2)
        {
            double dotproduct = 0;

            foreach (KeyValuePair<string, double> kvp1 in sp1)
                if (sp2.ContainsKey(kvp1.Key))
                    dotproduct += kvp1.Value * sp2[kvp1.Key];

            return dotproduct;
        }


    }
}
