using System.Collections.Generic;
using System;
using System.Linq;

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

        public static List<List<T>> CreateSortedBags<T>(List<T> input) where T : IComparable
        {
            List<List<T>> res = new List<List<T>>();
            foreach (T elt1 in input)
                foreach (T elt2 in input)
                {
                    if (elt1.CompareTo(elt2) >= 0) continue;
                    else
                    {
                        List<T> toAdd = new List<T>() { elt1, elt2 };
                        toAdd.Sort();
                        res.Add(toAdd);
                        foreach (T elt3 in input)
                        {
                            if (toAdd.Last().CompareTo(elt3) >= 0) continue;
                            toAdd = new List<T>() { elt1, elt2, elt3 };
                            res.Add(toAdd);
                            foreach (T elt4 in input)
                            {
                                if (toAdd.Last().CompareTo(elt4) >= 0) continue;
                                toAdd = new List<T>() { elt1, elt2, elt3, elt4 };
                                res.Add(toAdd);
                            }
                        }
                    }
                }
            return res;
        }
    }
}
