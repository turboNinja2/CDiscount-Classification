using System;
using System.Collections.Generic;
using System.Linq;
using NDSB.Models.Streaming.Phis;

namespace DataScienceECom.Models
{
    using FeatureHistogram = Dictionary<string, EmpiricScore<int>>;
    using Histogram = EmpiricScore<int>;

    class HierarchicalSGD : IStreamingModel<Hierarchy, int>
    {
        private static int preallocSize = 2000000;

        FeatureHistogram _w1 = new Dictionary<string, EmpiricScore<int>>(preallocSize);
        FeatureHistogram _w2 = new Dictionary<string, EmpiricScore<int>>(preallocSize);
        FeatureHistogram _w3 = new Dictionary<string, EmpiricScore<int>>(preallocSize);

        Dictionary<string, int> _n = new Dictionary<string, int>(preallocSize);
        Dictionary<string, bool> _forbidden = new Dictionary<string, bool>(preallocSize);

        #region Hyper-parameters
        double _power;
        double _maxEntropy;

        int _minValue;
        int _refresh;
        #endregion

        public int Refresh
        {
            get { return _refresh; }
        }

        public HierarchicalSGD(double power, int minValue, double entropy, int refresh = 1000000)
        {
            _power = power;
            _minValue = minValue;
            _maxEntropy = entropy;
            _refresh = refresh;
        }

        public string Description()
        {
            return ("HierSGD_" + Convert.ToString(_power) + "_" + Convert.ToString(_refresh) + "_" + Convert.ToString(_minValue) +
                "_" + Convert.ToString(_maxEntropy));
        }

        public void Update(Hierarchy y, IList<string> xs)
        {
            foreach (string x in xs)
            {
                if (_forbidden.ContainsKey(x)) continue; // don't talk about them any more
                if (!_n.ContainsKey(x))
                    _n.Add(x, 0);
                _n[x] += 1;
            }

            UpdateSubCat(y.Cat1, xs, _w1);
            xs.Add("c1_" + y.Cat1);

            if (!_n.ContainsKey("c1_" + y.Cat1))
                _n.Add("c1_" + y.Cat1, 0);
            _n["c1_" + y.Cat1] += 1;

            UpdateSubCat(y.Cat2, xs, _w2);
            xs.Add("c2_" + y.Cat2);

            if (!_n.ContainsKey("c2_" + y.Cat2))
                _n.Add("c2_" + y.Cat2, 0);
            _n["c2_" + y.Cat2] += 1;


            UpdateSubCat(y.Cat3, xs, _w3);
        }

        private void UpdateSubCat(int y, IList<string> xs, FeatureHistogram w)
        {
            if (PredictSubCat(xs, w) == y) return;

            foreach (string x in xs)
            {
                if (_forbidden.ContainsKey(x)) continue; // don't talk about them any more

                if (!w.ContainsKey(x))
                    w.Add(x, new EmpiricScore<int>());

                w[x].UpdateKey(y, Math.Pow(_n[x], -_power));
            }
        }

        public int Predict(IList<string> xs)
        {
            int cat1 = PredictSubCat(xs, _w1);
            xs.Add("c1_" + cat1.ToString());

            int cat2 = PredictSubCat(xs, _w2);
            xs.Add("c2_" + cat2.ToString());

            int cat3 = PredictSubCat(xs, _w3);

            return cat3;
        }

        private int PredictSubCat(IList<string> xs, FeatureHistogram w)
        {
            Histogram[] esCat1 = new EmpiricScore<int>[xs.Count];

            for (int i = 0; i < esCat1.Length; i++)
            {
                if (w.ContainsKey(xs[i]))
                    esCat1[i] = w[xs[i]];
                else
                    esCat1[i] = new EmpiricScore<int>();
            }
            Histogram es = EmpiricScore<int>.Merge(esCat1);

            return es.MostLikelyElement();
        }

        public void GarbageCollect()
        {
            string[] keys = _n.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                string currentKey = keys[i];

                if (_n.ContainsKey(currentKey) && _n[currentKey] < _minValue)
                {
                    _w1.Remove(currentKey);
                    _w2.Remove(currentKey);
                    _w3.Remove(currentKey);
                    _n.Remove(currentKey);
                    continue;
                }

                if (_n.ContainsKey(currentKey) && _w3.ContainsKey(currentKey) && _w3[currentKey].Entropy() > _maxEntropy)
                {
                    _w3.Remove(currentKey);
                    _n.Remove(currentKey);
                    _forbidden.Add(currentKey, true);
                }

            }
        }

        public void ClearModel()
        {
            _w1.Clear();
            _w2.Clear();
            _w3.Clear();
            _n.Clear();
            _forbidden.Clear();
        }

    }
}
