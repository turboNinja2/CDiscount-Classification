using System;
using System.Collections.Generic;
using System.Linq;

namespace DataScienceECom
{
    class EmpiricScore
    {
        private Dictionary<int, double> _scores = new Dictionary<int, double>(20);

        public Dictionary<int, double> Scores
        {
            get { return _scores; }
        }

        public EmpiricScore()
        {

        }

        public EmpiricScore(int[] rawLabels)
        {
            for (int i = 0; i < rawLabels.Length; i++)
                UpdateKey(rawLabels[i], 1);
        }

        public int MostLikelyElement()
        {
            if (_scores.Count == 0) return -1;

            double bestScore = double.MinValue;
            int mostLikely = _scores.Keys.First();
            foreach (KeyValuePair<int, double> kvp in _scores)
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

        public void UpdateKey(int key, double value)
        {
            if (_scores.ContainsKey(key))
                _scores[key] += value;
            else
                _scores.Add(key, value);
        }

        public EmpiricScore Normalize()
        {
            double sum = _scores.Select(k => k.Value).Sum();
            EmpiricScore result = new EmpiricScore();
            foreach (KeyValuePair<int, double> kvp in _scores)
                result.UpdateKey(kvp.Key, kvp.Value / sum);
            return result;
        }

        public double NormalizedEntropy()
        {
            double entropy = 0;
            EmpiricScore normalized = this.Normalize();
            foreach (KeyValuePair<int, double> kvp in normalized._scores)
            {
                double p = kvp.Value;
                entropy += p * Math.Log(p, 2);
            }
            return -entropy;
        }

        public static EmpiricScore Merge(IList<EmpiricScore> empiricScores)
        {
            EmpiricScore result = new EmpiricScore();
            foreach (EmpiricScore empiricScore in empiricScores)
                foreach (KeyValuePair<int, double> kvp in empiricScore.Scores)
                    result.UpdateKey(kvp.Key, kvp.Value);

            return result;
        }
    }
}
