using System.Collections.Generic;
using System.Threading.Tasks;
using DataScienceECom;

namespace NDSB.Models.SparseModels
{
    using Point = Dictionary<string, double>;

    public class EnsembleTrees : IModelClassification<Point>
    {
        private DecisionTree[] _trees = new DecisionTree[0];
        private int _maxDepth;
        private int _minElementsPerLeaf;
        private int _nTrees;

        public EnsembleTrees(int maxDepth, int minElementsPerLeaf, int nTrees)
        {
            _maxDepth = maxDepth;
            _minElementsPerLeaf = minElementsPerLeaf;
            _nTrees = nTrees;
        }

        public void Train(int[] labels, Point[] points)
        {
            _trees = new DecisionTree[_nTrees];
            for (int i = 0; i < _nTrees; i++)
                _trees[i] = new DecisionTree(_maxDepth, _minElementsPerLeaf);
            for (int i = 0; i < _nTrees; i++)
                _trees[i].Train(labels, points);
        }

        public int Predict(Point pt)
        {
            int[] responses = new int[_nTrees];
            for (int i = 0; i < _nTrees; i++)
                responses[i] = _trees[i].Predict(pt);
            return (new EmpiricScore<int>(responses)).MostLikelyElement();
        }

        public string Description()
        {
            return "RF_" + _maxDepth + "_" + _minElementsPerLeaf + "_" + _nTrees;
        }
    }
}
