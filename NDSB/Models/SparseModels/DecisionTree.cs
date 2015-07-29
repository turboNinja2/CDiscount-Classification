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

        public DecisionTree(int maxDepth, int minElementsPerLeaf = 20)
        {
            _maxDepth = maxDepth;
            _minElementsPerLeaf = minElementsPerLeaf;
        }

        public void Train(int[] labels, Point[] points)
        {
            _labels = labels;
            _points = points;
            _invertedIndexes = DataIndexer.InverseKeysAndSort(_points); // sorting it allows performance improvement later
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

            string currentSplitter = RandomSplit(subIndexes);//FindeBestSplit(subIndexes);

            if (currentDepth == 0 || subIndexes.Length < _minElementsPerLeaf || currentSplitter == "")
            {
                int[] currentLabels = GetElementsAt(_labels, subIndexes);
                int mostLikelyElement = new EmpiricScore(currentLabels).MostLikelyElement();
                rules.Node = mostLikelyElement.ToString();
                return;
            }

            rules.Node = currentSplitter;

            int[] indexesLeft = DataIndexer.IntersectSorted<int>(_invertedIndexes[currentSplitter], subIndexes, Comparer<int>.Default).ToArray(),
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
            return "DTree_leafSize" + _minElementsPerLeaf + "md_" + _maxDepth;
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
            double lowestEntropy = double.MaxValue;
            string bestSplitter = "";

            for (int i = 0; i < _splitters.Count; i++)
            {
                if (_rnd.Next(100) < 95) continue;

                string splitter = _splitters[i];

                int[] relevantIndexes = DataIndexer.IntersectSorted<int>(_invertedIndexes[splitter], subSelectedIndexes, Comparer<int>.Default).ToArray();
                if (relevantIndexes.Length < _minElementsPerLeaf) continue; // note that relevantIndexes and associatedLabels ahve the same length

                int[] associatedLabels = GetElementsAt(_labels, relevantIndexes);
                int[] complementaryLabels = GetElementsAt(_labels, subSelectedIndexes.Except(relevantIndexes).ToArray());

                if (complementaryLabels.Length < _minElementsPerLeaf) continue;

                double associatedEntropy = (new EmpiricScore(associatedLabels)).NormalizedEntropy() + (new EmpiricScore(complementaryLabels)).NormalizedEntropy();
                if (associatedEntropy < lowestEntropy)
                {
                    lowestEntropy = associatedEntropy;
                    bestSplitter = splitter;
                }
            }
            return bestSplitter;
        }

        public string RandomSplit(int[] subSelectedIndexes)
        {
            HashSet<string> commonSplitters = new HashSet<string>();
            for (int i = 0; i < subSelectedIndexes.Length; i++)
                for (int j = 0; j < _points[subSelectedIndexes[i]].Count; j++)
                    if (_splitters.Contains(_points[subSelectedIndexes[i]].ElementAt(j).Key))
                        commonSplitters.Add(_points[subSelectedIndexes[i]].ElementAt(j).Key);

            int n = commonSplitters.Count;
            if (n == 0) return "";

            int index = _rnd.Next(n);
            string result = commonSplitters.ElementAt(index);
            _splitters.Remove(result);
            return result;
        }


    }


}
