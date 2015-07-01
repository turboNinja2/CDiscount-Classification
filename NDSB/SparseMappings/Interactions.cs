using System;
using System.Collections.Generic;
using System.Linq;

namespace NDSB.SparseMappings
{
    public class Interactions : IMapping<Dictionary<string, double>>
    {
        private int _minSize;
        private int _maxSize;

        public Interactions(int minSize, int maxSize)
        {
            _minSize = minSize;
            _maxSize = maxSize;
        }

        public Dictionary<string, double> Map(Dictionary<string, double> point)
        {
            Dictionary<string, double> res = new Dictionary<string, double>(20);
            string[] keys = point.Keys.ToArray();
            double[] values = point.Values.ToArray();

            double sqrt2 = Math.Sqrt(2);

            for (int i = 0; i < point.Count; i++)
                for (int j = i; j < point.Count; j++)
                {
                    if (i == j) res.Add(keys[i], values[i] * values[i]);
                    else // poor man dimension reduction...
                        if (keys[i].Length < _maxSize && keys[i].Length > _minSize && keys[j].Length < _maxSize && keys[j].Length > _minSize)
                        {
                            double coef = sqrt2 * values[i] * values[j];
                            if (keys[i].Length < keys[j].Length)
                                res.Add(keys[i] + "_" + keys[j], coef);
                            else
                                res.Add(keys[j] + "_" + keys[i], coef);
                        }
                }

            return res;
        }
    }
}
