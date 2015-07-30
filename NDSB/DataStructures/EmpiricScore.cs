using System;
using System.Collections.Generic;
using System.Linq;

namespace DataScienceECom
{
    /// <summary>
    /// Given a set of keys, performs a lot of operations.
    /// A particular use of this class can be to count elements.
    /// </summary>
    /// <typeparam name="T">The type of the set of keys</typeparam>
    public class EmpiricScore<T>
    {
        private Dictionary<T, double> _scores = new Dictionary<T, double>(20);
        private const double _THRESHOLD_ = 1e-5f;

        public Dictionary<T, double> Scores
        {
            get { return _scores; }
        }

        public EmpiricScore()
        {

        }

        public EmpiricScore(int preAlloc)
        {
            _scores = new Dictionary<T, double>(preAlloc);
        }

        public EmpiricScore(EmpiricScore<T> model)
        {
            _scores = new Dictionary<T, double>(model.Scores);
        }

        public EmpiricScore(T[] rawLabels)
        {
            for (int i = 0; i < rawLabels.Length; i++)
                UpdateKey(rawLabels[i], 1);
        }

        public T MostLikelyElement()
        {
            if (_scores.Count == 0) return default(T);

            double bestScore = double.MinValue;
            T mostLikely = _scores.Keys.First();
            foreach (KeyValuePair<T, double> kvp in _scores)
            {
                double currentScore = kvp.Value;
                if (currentScore > bestScore)
                {
                    bestScore = currentScore;
                    mostLikely = kvp.Key;
                }
            }
            return mostLikely;
        }

        public void UpdateKey(T key, double value)
        {
            if (_scores.ContainsKey(key))
                _scores[key] += value;
            else
                _scores.Add(key, value);
        }

        public EmpiricScore<T> Normalize()
        {
            double sum = _scores.Select(k => k.Value).Sum();
            EmpiricScore<T> result = new EmpiricScore<T>(_scores.Count);
            foreach (KeyValuePair<T, double> kvp in _scores)
                result.UpdateKey(kvp.Key, kvp.Value / sum);
            return result;
        }

        public double NormalizedEntropy()
        {
            double entropy = 0;
            EmpiricScore<T> normalized = this.Normalize();
            foreach (KeyValuePair<T, double> kvp in normalized._scores)
            {
                double p = kvp.Value;
                entropy += p * Math.Log(p, 2);
            }
            return -entropy;
        }

        public static EmpiricScore<T> Merge(IList<EmpiricScore<T>> empiricScores)
        {
            EmpiricScore<T> result = new EmpiricScore<T>();
            foreach (EmpiricScore<T> empiricScore in empiricScores)
                foreach (KeyValuePair<T, double> kvp in empiricScore.Scores)
                    result.UpdateKey(kvp.Key, kvp.Value);
            return result;
        }

        public EmpiricScore<T> Except(EmpiricScore<T> b)
        {
            EmpiricScore<T> diff = new EmpiricScore<T>(this);
            foreach(KeyValuePair<T,double> kvp in b._scores)
                if (diff._scores.ContainsKey(kvp.Key))
                {
                    diff._scores[kvp.Key] -= kvp.Value;
                    if (Math.Abs(diff._scores[kvp.Key]) < _THRESHOLD_)
                        diff._scores.Remove(kvp.Key);
                }
            return diff;
        }
    }
}
