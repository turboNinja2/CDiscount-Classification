using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDSB.Models.SparseModels
{
    using Point = Dictionary<string, double>;
    using DataScienceECom;

    public class DecisionTree : IModelClassification<Point>
    {
        private const int _INVERTED_INDEXES_PREALLOC_ = 1000000;

        // Shallow copy of the data
        private int[] _labels = new int[0];
        private Point[] _points = new Point[0];

        // Parameters
        private int _minElementsPerLeaf;
        private int _maxDepth;
        private double _minTFIDF;

        // Model
        private List<string> _splitters = new List<string>();
        private Random _rnd = new Random(1);
        private BinaryTree<string> _rules;
        private Dictionary<string, List<int>> _invertedIndexes = new Dictionary<string, List<int>>(_INVERTED_INDEXES_PREALLOC_);

        public DecisionTree(int maxDepth, double minTFIDF, int minElementsPerLeaf = 25)
        {
            _maxDepth = maxDepth;
            _minTFIDF = minTFIDF;
            _minElementsPerLeaf = minElementsPerLeaf;
        }

        public void Train(int[] labels, Point[] points)
        {
            _labels = labels;
            _points = points;
            _invertedIndexes = DataIndexer.InverseKeysAndSort(_points, _minTFIDF);
            _splitters = _invertedIndexes.Keys.ToList();

            int[] allIndexes = new int[labels.Length];
            for (int i = 0; i < allIndexes.Length; i++)
                allIndexes[i] = i;

            _rules = new BinaryTree<string>();

            TrainTree(_rules, _maxDepth, allIndexes);
        }

        private void TrainTree(BinaryTree<string> rules, int currentDepth, int[] subIndexes)
        {
            currentDepth--;

            string currentSplitter = FindeBestSplit(subIndexes);
            if (currentDepth == 0 || subIndexes.Length < _minElementsPerLeaf || currentSplitter == "")
            {
                int[] currentLabels = GetElementsAt(_labels, subIndexes);
                int mostLikelyElement = new EmpiricScore(currentLabels).MostLikelyElement();
                rules.Node = mostLikelyElement.ToString();
                return;
            }

            rules.Node = currentSplitter;

            int[] indexesLeft = DataIndexer.IntersectSorted<int>(_invertedIndexes[currentSplitter], subIndexes, Comparer<int>.Default).ToArray(), //_invertedIndexes[currentSplitter].Intersect(subIndexes).ToArray(),
                indexesRight = subIndexes.Except(_invertedIndexes[currentSplitter]).ToArray();

            rules.LeftChild = new BinaryTree<string>();
            rules.RightChild = new BinaryTree<string>();

            TrainTree(rules.LeftChild, currentDepth, indexesLeft);
            TrainTree(rules.RightChild, currentDepth, indexesRight);
        }

        public int Predict(Point pt)
        {
            List<string> keywords = pt.Keys.ToList();
            return Predict(keywords, _rules);
        }

        private int Predict(List<string> keywords, BinaryTree<string> rules)
        {
            if (rules.LeftChild == null && rules.RightChild == null) return Convert.ToInt32(rules.Node);
            if (keywords.Contains(rules.Node)) return Predict(keywords, rules.LeftChild);
            else return Predict(keywords, rules.RightChild);
        }

        public string Description()
        {
            return "Nope";
        }

        public static int[] GetElementsAt(int[] labels, int[] indexes)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < indexes.Length; i++)
                result.Add(labels[indexes[i]]);
            return result.ToArray();
        }

        public static int[] GetElementsNotAt(int[] labels, int[] indexes)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < indexes.Length; i++)
                result.Add(labels[indexes[i]]);
            return result.ToArray();
        }


        public string FindeBestSplit(int[] subSelectedIndexes)
        {
            double lowestEntropy = double.MaxValue;
            string bestSplitter = "";

            for (int i = 0; i < _splitters.Count; i++)
            {
                if (_rnd.Next(100) < 95) continue;

                string splitter = _splitters[i];

                int[] relevantIndexes = DataIndexer.IntersectSorted<int>(_invertedIndexes[splitter], subSelectedIndexes, Comparer<int>.Default).ToArray();

                int[] associatedLabels = GetElementsAt(_labels, relevantIndexes);
                int[] complementaryLabels = GetElementsAt(_labels, subSelectedIndexes.Except(relevantIndexes).ToArray());

                if (associatedLabels.Length < _minElementsPerLeaf || complementaryLabels.Length < _minElementsPerLeaf) continue; // impose to have enough elements per leaf

                double associatedEntropy = (new EmpiricScore(associatedLabels)).NormalizedEntropy() + (new EmpiricScore(complementaryLabels)).NormalizedEntropy();
                if (associatedEntropy < lowestEntropy)
                {
                    lowestEntropy = associatedEntropy;
                    bestSplitter = splitter;
                }
            }

            return bestSplitter;
        }
    }
}
