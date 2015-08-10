using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDSB
{
    public static class ListExtensions
    {
        public static List<string> CartesianProduct(this List<string> input)
        {
            List<string> res = new List<string>();

            for (int i = 0; i < input.Count; i++)
                for (int j = i; j < input.Count; j++)
                {
                    string ki = input[i],
                        kj = input[j];
                    if (string.Compare(ki, kj) > 0)
                        res.Add(ki + "_" + kj);
                    else
                        res.Add(kj + "_" + ki);
                }
            return res;
        }

        public static List<string> CartesianProduct(this List<string> input, string input2)
        {
            List<string> res = new List<string>();
            for (int i = 0; i < input.Count; i++)
                res.Add(input[i] + "_" + input2);
            return res;
        }
    }
}
