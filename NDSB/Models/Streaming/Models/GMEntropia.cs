﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DataScienceECom.Models
{
    class GMEntropia : IStreamingModel<int,int>
    {
        private static int preallocSize = 2000000;

        Dictionary<string, EmpiricScore<int>> _w = new Dictionary<string, EmpiricScore<int>>(preallocSize);
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

        public GMEntropia(double power, int minValue, double entropy, int refresh = 1000000)
        {
            _power = power;
            _minValue = minValue;
            _maxEntropy = entropy;
            _refresh = refresh;
        }

        public string Description()
        {
            return ("GMEntropia_" + Convert.ToString(_power) + "_" + Convert.ToString(_refresh) + "_" + Convert.ToString(_minValue) + 
                "_" + Convert.ToString(_maxEntropy));
        }

        public void Update(int y, IList<string> xs)
        {
            if (Predict(xs) == y) return;

            foreach (string x in xs)
            {
                if (_forbidden.ContainsKey(x)) continue; // don't talk about them any more

                if (!_w.ContainsKey(x))
                {
                    _w.Add(x, new EmpiricScore<int>());
                    _n.Add(x, 0);
                }
                _n[x] += 1;
                _w[x].UpdateKey(y, Math.Pow(_n[x], -_power));
            }
        }

        public int Predict(IList<string> xs)
        {
            EmpiricScore<int>[] ess = new EmpiricScore<int>[xs.Count];
            for (int i = 0; i < ess.Length; i++)
            {
                if (_w.ContainsKey(xs[i]))
                    ess[i] = _w[xs[i]];
                else
                    ess[i] = new EmpiricScore<int>();
            }
            EmpiricScore<int> es = EmpiricScore<int>.Merge(ess);
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
                    continue;
                }

                if (_w[currentKey].Entropy() > _maxEntropy)
                {
                    _w.Remove(currentKey);
                    _n.Remove(currentKey);
                    _forbidden.Add(currentKey, true);
                }

            }
        }

        public void ClearModel()
        {
            _w.Clear();
            _n.Clear();
            _forbidden.Clear();
        }

    }
}
