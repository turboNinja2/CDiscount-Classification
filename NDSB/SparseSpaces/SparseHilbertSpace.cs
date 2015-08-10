using System.Collections.Generic;

namespace NDSB.SparseMethods
{
    public static class HilbertSpace
    {
        public static double DotProduct<T>(Dictionary<T, double> sp1, Dictionary<T, double> sp2)
        {
            double dotproduct = 0;
            foreach (KeyValuePair<T, double> kvp1 in sp1)
                if (sp2.ContainsKey(kvp1.Key))
                    dotproduct += kvp1.Value * sp2[kvp1.Key];
            return dotproduct;
        }
    }
}
