using System.Collections.Generic;
using System.Linq;

namespace NDSB.SparseMappings
{
    public class PureInteractions : IMapping<Dictionary<string, double>>
    {
        private int _minSize;
        private int _maxSize;

        public PureInteractions(int minSize, int maxSize)
        {
            _minSize = minSize;
            _maxSize = maxSize;
        }

        public Dictionary<string, double> Map(Dictionary<string, double> point)
        {
            Dictionary<string, double> res = new Dictionary<string, double>(20);
            string[] keys = point.Keys.ToArray();
            double[] values = point.Values.ToArray();

            for (int i = 0; i < point.Count; i++)
                for (int j = i; j < point.Count; j++)
                {
                    string ki = keys[i],
                        kj = keys[j];
                    if (i == j) continue; //res.Add(keys[i], values[i]);
                    else // interactions only
                        if (ki.Length < _maxSize && ki.Length > _minSize && kj.Length < _maxSize && kj.Length > _minSize)
                        {
                            double coef = values[i] * values[j];
                            if (string.Compare(ki, kj) > 0) //dimension reduction ;)
                                res.Add(ki + "_" + kj, coef);
                            else
                                res.Add(kj + "_" + ki, coef);
                        }
                }
            return res;
        }

        public string Description()
        {
            return "PureInt_" + _minSize + "_" + _maxSize;
        }
    }
}
