using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataScienceECom;

namespace NDSB.Models.SparseModels
{
    public class BagOfWords<T> : IModelClassification<Dictionary<T, double>>
    {
        private double _minTFIDF;
        private const int _INVERTED_INDEXES_PREALLOC_ = 100000;

        private Dictionary<List<T>, EmpiricScore<int>> _bags;
        private Dictionary<T, int[]> _invertedIndexes = new Dictionary<T, int[]>();

        private int[] _labels;
        private Dictionary<T, double>[] _points;

        private int _minOccurences;
        private int _maxOccurences;

        private Random _rnd;

        public BagOfWords(int minOccurences, int maxOccurences, double minTFIDF)
        {
            _minTFIDF = minTFIDF;
            _minOccurences = minOccurences;
            _maxOccurences = maxOccurences;
            _rnd = new Random(0);
        }

        public void Train(int[] labels, Dictionary<T, double>[] points)
        {
            _labels = labels;
            _points = points;
            _invertedIndexes = SmartIndexes.InverseKeys(points, _minTFIDF, _INVERTED_INDEXES_PREALLOC_);

            T[] keys = _invertedIndexes.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
                if (_invertedIndexes[keys[i]].Length > _maxOccurences || _invertedIndexes[keys[i]].Length < _minOccurences)
                    _invertedIndexes.Remove(keys[i]);

            _bags = Get2Bags(_minOccurences);
        }

        private Dictionary<List<T>, EmpiricScore<int>> Get2Bags(int minOccurences)
        {
            Dictionary<List<T>, EmpiricScore<int>> bags = new Dictionary<List<T>, EmpiricScore<int>>();

            foreach (KeyValuePair<T, int[]> entry1 in _invertedIndexes)
            {
                foreach (KeyValuePair<T, int[]> entry2 in _invertedIndexes)
                {
                    if (entry2.Value.Length < minOccurences) continue;
                    int[] intersectedIndexes = SmartIndexes.IntersectSortedIntUnsafe(entry1.Value, entry2.Value);
                    if (intersectedIndexes.Length > minOccurences)
                    {
                        if (entry1.Key.Equals(entry2.Key)) break;

                        int[] relevantLabels = SmartIndexes.GetElementsAt(_labels, intersectedIndexes);
                        EmpiricScore<int> labelsScores = new EmpiricScore<int>(relevantLabels);
                        bags.Add(new List<T>() { entry1.Key, entry2.Key }, labelsScores);

                        /*
                        foreach (KeyValuePair<T, int[]> entry3 in _invertedIndexes)
                        {
                            if (entry3.Key.Equals(entry2.Key) || entry3.Key.Equals(entry1.Key)) continue;

                            int[] intersectedIndexes2 = SmartIndexes.IntersectSortedIntUnsafe(entry3.Value, intersectedIndexes);
                            
                            if (intersectedIndexes2.Length > minOccurences)
                            {
                                relevantLabels = SmartIndexes.GetElementsAt(_labels, intersectedIndexes);
                                labelsScores = new EmpiricScore<int>(relevantLabels);
                                bags.Add(new List<T>() { entry1.Key, entry2.Key, entry3.Key }, labelsScores);

                            }
                        }
                        */
                    }
                }
            }

            return bags;
        }

        public string Description()
        {
            return "zizi";
        }

        public int Predict(Dictionary<T, double> point)
        {
            return 0;
        }


    }
}
