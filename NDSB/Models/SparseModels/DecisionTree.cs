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
        // Shallow copy of the data
        private int[] _labels = new int[0];
        private Point[] _points = new Point[0];

        // Parameters
        private int _minElementsPerLeaf;
        private int _maxDepth;

        // Model
        private List<string> _splitters = new List<string>();
        private Random _rnd = new Random(1);
        private BinaryTree<string> _rules;
        private Dictionary<string, List<int>> _invertedIndexes;
        private HashSet<string> _splittersUsed = new HashSet<string>();

        private double _earlyStopEntropy = 3.5f;

        public DecisionTree(int maxDepth, int minElementsPerLeaf = 8, int seed = 0)
        {
            _maxDepth = maxDepth;
            _minElementsPerLeaf = minElementsPerLeaf;
            _rnd = new Random(seed);
        }

        public void Train(int[] labels, Point[] points)
        {
            _labels = labels;
            _points = points;

            // sorting it allows performance improvement later
            _invertedIndexes = SmartIndexes.InverseKeysAndSort(_points);

            // only the following splitters are relevant
            _splitters = _invertedIndexes.Where(kvp => kvp.Value.Count > _minElementsPerLeaf).Select(k => k.Key).ToList();

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

            if (currentDepth == 0 || currentSplitter == "")
            {
                int[] currentLabels = GetElementsAt(_labels, subIndexes);
                int mostLikelyElement = new EmpiricScore(currentLabels).MostLikelyElement();
                rules.Node = mostLikelyElement.ToString();
                return;
            }

            rules.Node = currentSplitter;
            _splittersUsed.Add(currentSplitter);

            int[] indexesLeft = SmartIndexes.IntersectSorted<int>(_invertedIndexes[currentSplitter], subIndexes, Comparer<int>.Default).ToArray(),
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
            return "DTree_leafSize" + _minElementsPerLeaf + "md_" + _maxDepth + "bis";
        }

        public static int[] GetElementsAt(int[] labels, int[] indexes)
        {
            int[] result = new int[indexes.Length];
            for (int i = 0; i < indexes.Length; i++)
                result[i] = labels[indexes[i]];
            return result;
        }

        public string FindeBestSplit(int[] subSelectedIndexes)
        {
            int[] associatedLabels = GetElementsAt(_labels, subSelectedIndexes);

            double lowestEntropy = (new EmpiricScore(associatedLabels)).NormalizedEntropy() * 2; // what if I randomly splitted the data set 
            string bestSplitter = "";

            if (lowestEntropy < _earlyStopEntropy * 2) return ""; // early stopping

            List<string> splitters = GetSubsetOfCommonFeatures(subSelectedIndexes);

            for (int i = 0; i < splitters.Count; i++)
            {
                string splitter = splitters[i];

                int[] relevantIndexes = SmartIndexes.IntersectSorted<int>(_invertedIndexes[splitter], subSelectedIndexes, Comparer<int>.Default).ToArray();
                if (relevantIndexes.Length < _minElementsPerLeaf) continue; // note that relevantIndexes and associatedLabels ahve the same length

                associatedLabels = GetElementsAt(_labels, relevantIndexes);

                int[] complementaryIndexes = SmartIndexes.ExceptSorted<int>(subSelectedIndexes, relevantIndexes).ToArray();
                if (complementaryIndexes.Length < _minElementsPerLeaf) continue;

                int[] complementaryLabels = GetElementsAt(_labels, complementaryIndexes);

                double associatedEntropy = (new EmpiricScore(associatedLabels)).NormalizedEntropy() + (new EmpiricScore(complementaryLabels)).NormalizedEntropy();
                if (associatedEntropy < lowestEntropy)
                {
                    lowestEntropy = associatedEntropy;
                    bestSplitter = splitter;
                }
            }
            return bestSplitter;
        }

        public List<string> GetSubsetOfCommonFeatures(int[] subSelectedIndexes)
        {
            HashSet<string> commonSplitters = new HashSet<string>();
            for (int i = 0; i < subSelectedIndexes.Length; i++)
                for (int j = 0; j < _points[subSelectedIndexes[i]].Count; j++)
                {
                    string candidateSplitter = _points[subSelectedIndexes[i]].ElementAt(j).Key;
                    if (_splitters.Contains(candidateSplitter) && !_splittersUsed.Contains(candidateSplitter) && _rnd.Next(2) == 1)
                        commonSplitters.Add(candidateSplitter);
                    if (commonSplitters.Count > 200) return commonSplitters.ToList();
                }
            return commonSplitters.ToList();
        }
    }
}
