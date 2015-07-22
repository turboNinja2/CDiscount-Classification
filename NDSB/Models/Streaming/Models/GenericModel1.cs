using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataScienceECom.Models
{
    class GenericModel1 : IStreamingModel
    {
        private static int preallocSize = 2000000;
        Dictionary<string, EmpiricScore> _w = new Dictionary<string, EmpiricScore>(preallocSize);
        Dictionary<string, int> _n = new Dictionary<string, int>(preallocSize);

        double _power;
        int _minValue;
        int _refresh = 1000000;

        public int Refresh
        {
            get { return _refresh; }
        }

        public GenericModel1(double power, int minValue)
        {
            _power = power;
            _minValue = minValue;
        }

        public new string ToString()
        {
            return ("Generic1_" + Convert.ToString(_power) + "_" + Convert.ToString(_minValue));
        }

        public void Update(int y, string[] xs)
        {
            if (Predict(xs) == y) return;

            foreach (string x in xs)
            {
                if (!_w.ContainsKey(x))
                {
                    _w.Add(x, new EmpiricScore());
                    _n.Add(x, 0);
                }
                _n[x] += 1;
                _w[x].UpdateKey(y, Math.Pow(_n[x], -_power));
            }
        }

        public int Predict(string[] xs)
        {
            EmpiricScore[] ess = new EmpiricScore[xs.Length];
            for (int i = 0; i < ess.Length; i++)
            {
                if (_w.ContainsKey(xs[i]))
                    ess[i] = _w[xs[i]];
                else
                    ess[i] = new EmpiricScore();
            }
            EmpiricScore es = EmpiricScore.Merge(ess);
            return es.MostLikelyElement();
        }

        public void GarbageCollect()
        {
            string[] keys = _n.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                string currentKey = keys[i];
                if (_n[currentKey] < _minValue)
                {
                    _w.Remove(currentKey);
                    _n.Remove(currentKey);
                }
            }
        }

        public void ClearModel()
        {
            _w.Clear();
            _n.Clear();
        }

    }
}
