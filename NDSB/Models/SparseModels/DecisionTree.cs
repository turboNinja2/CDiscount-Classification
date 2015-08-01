using System;
using System.Collections.Generic;
using System.Linq;
using DataScienceECom;

namespace NDSB.Models.SparseModels
{
    using Point = Dictionary<string, double>;
    using System.Diagnostics;

    public class DecisionTree : IModelClassification<Point>
    {
        // Shallow copy of the data
        private int[] _labels = new int[0];
        private Point[] _points = new Point[0];

        // Parameters
        private int _minElementsPerLeaf;
        private int _maxDepth;

        // Model
        private HashSet<string> _splitters = new HashSet<string>();

        private BinaryTree<string> _rules;
        private Dictionary<string, int[]> _invertedIndexes;

        public DecisionTree(int maxDepth, int minElementsPerLeaf)
        {
            _maxDepth = maxDepth;
            _minElementsPerLeaf = minElementsPerLeaf;
        }

        public void Train(int[] labels, Point[] points)
        {
            _labels = labels;
            _points = points;

            // sorting it allows performance improvement later
            _invertedIndexes = SmartIndexes.InverseKeysAndSort(_points);

            // only the following splitters are relevant
            _splitters = new HashSet<string>(_invertedIndexes.Where(kvp => kvp.Value.Length > _minElementsPerLeaf).Select(k => k.Key));

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

            if (currentSplitter == "" || currentDepth == 0)
            {
                int[] currentLabels = GetElementsAt(_labels, subIndexes);
                int mostLikelyElement = new EmpiricScore<int>(currentLabels).MostLikelyElement();
                rules.Node = mostLikelyElement.ToString();
                return;
            }

            rules.Node = currentSplitter;
            int[] indexesLeft = SmartIndexes.IntersectSortedIntUnsafe(_invertedIndexes[currentSplitter], subIndexes);
            rules.LeftChild = new BinaryTree<string>();
            rules.RightChild = new BinaryTree<string>();

            TrainTree(rules.LeftChild, currentDepth, indexesLeft);
            indexesLeft = new int[0];

            int[] indexesRight = subIndexes.Except(_invertedIndexes[currentSplitter]).ToArray();
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
            int[] initialLabels = GetElementsAt(_labels, subSelectedIndexes);
            EmpiricScore<int> initalLabelsDistribution = new EmpiricScore<int>(initialLabels);

            double totalGini = (initalLabelsDistribution).NormalizedEntropy() * 2; // what if I randomly splitted the data set 
            string bestSplitter = "";

            List<string> splitters = GetSubsetOfCommonFeatures(subSelectedIndexes);

            for (int i = 0; i < splitters.Count; i++)
            {
                string splitter = splitters[i];
                int[] relevantIndexes = SmartIndexes.IntersectSortedIntUnsafe(_invertedIndexes[splitter], subSelectedIndexes);

                int nLeft = relevantIndexes.Length;
                if (nLeft < _minElementsPerLeaf) continue; // note that relevantIndexes and associatedLabels ahve the same length

                initialLabels = GetElementsAt(_labels, relevantIndexes);

                int nRight = subSelectedIndexes.Length - initialLabels.Length;
                if (nRight < _minElementsPerLeaf) continue;

                EmpiricScore<int> histLeft = new EmpiricScore<int>(initialLabels);
                double GiniLeft = histLeft.Gini();

                EmpiricScore<int> histRight = initalLabelsDistribution.Except(histLeft);
                double GiniRight = histRight.Gini();

                double associatedGini = (nLeft * GiniLeft + nRight * GiniRight) / (nRight + nLeft);

                if (associatedGini < totalGini)
                {
                    totalGini = associatedGini;
                    bestSplitter = splitter;
                }
            }

            if (totalGini < 0.1) return "";

            return bestSplitter;
        }

        public List<string> GetSubsetOfCommonFeatures(int[] subSelectedIndexes)
        {
            HashSet<string> commonSplitters = new HashSet<string>();
            for (int i = 0; i < subSelectedIndexes.Length; i++)
                for (int j = 0; j < _points[subSelectedIndexes[i]].Count; j++)
                {
                    string candidateSplitter = _points[subSelectedIndexes[i]].ElementAt(j).Key;
                    if (_splitters.Contains(candidateSplitter))
                        commonSplitters.Add(candidateSplitter);
                    if (commonSplitters.Count > 600) return commonSplitters.ToList();
                }
            return commonSplitters.ToList();
        }
    }
}
