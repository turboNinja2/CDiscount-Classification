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
        private double _maxGini;

        private const int _INVERTED_INDEXES_PREALLOC_ = 100000;

        private Dictionary<T, int[]> _invertedIndexes = new Dictionary<T, int[]>();
        Dictionary<List<T>, EmpiricScore<int>> _pairsHistograms;

        private int[] _labels;
        private Dictionary<T, double>[] _points;

        private int _minOccurences;
        private int _maxOccurences;

        public BagOfWords(int minOccurences, int maxOccurences, double maxGini, double minTFIDF)
        {
            _minTFIDF = minTFIDF;
            _minOccurences = minOccurences;
            _maxOccurences = maxOccurences;
            _maxGini = maxGini;
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

            Dictionary<List<T>, int[]> invertedPairs = SmartIndexes.InversePairs(_invertedIndexes, _minOccurences);

            _pairsHistograms = new Dictionary<List<T>, EmpiricScore<int>>(new ListComparer<T>());

            foreach (KeyValuePair<List<T>, int[]> invertedPair in invertedPairs)
            {
                int[] relevantLabels = SmartIndexes.GetElementsAt<int>(_labels, invertedPair.Value);
                EmpiricScore<int> histogram = new EmpiricScore<int>(relevantLabels);
                if(histogram.Gini() < _maxGini)
                    _pairsHistograms.Add(invertedPair.Key, histogram.Normalize());
            }

            Dictionary<List<T>, int[]> invertedBags = SmartIndexes.InverseBags(_invertedIndexes, invertedPairs, _minOccurences);

            foreach (KeyValuePair<List<T>, int[]> invertedBag in invertedBags)
            {
                int[] relevantLabels = SmartIndexes.GetElementsAt<int>(_labels, invertedBag.Value);
                EmpiricScore<int> histogram = new EmpiricScore<int>(relevantLabels);
                if (histogram.Gini() < _maxGini)
                    _pairsHistograms.Add(invertedBag.Key, histogram.Normalize());
            }

        }

        public string Description()
        {
            return "BOW_" + _maxOccurences + "_" + _minOccurences + "_" + _maxGini + "_" + _minTFIDF;
        }

        public int Predict(Dictionary<T, double> point)
        {
            List<List<T>> bags = ListExtensions.CreateSortedBags<T>(point.Keys.ToList());

            List<EmpiricScore<int>> histograms = new List<EmpiricScore<int>>();
            foreach (List<T> bag in bags)
                if (_pairsHistograms.ContainsKey(bag))
                    histograms.Add(_pairsHistograms[bag]);

            return EmpiricScore<int>.Merge(histograms).MostLikelyElement();
        }
    }
}
