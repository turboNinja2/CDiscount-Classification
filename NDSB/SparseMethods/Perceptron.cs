using System.Collections.Generic;

namespace NDSB.SparseMethods
{
    public class Perceptron
    {
        private Dictionary<string, double> _w = new Dictionary<string, double>(10000);

        public double Predict(Dictionary<string, double> point)
        {
            return HilbertSpace.DotProduct(point, _w);
        }

        private void Update(Dictionary<string, double> xt, double yt, double gammat)
        {
            if (Predict(xt) * yt <= 0)
            {
                LinearSpace.Multiply(xt, gammat * yt);
                LinearSpace.Add(_w, xt);
            }
        }

        public void Train(Dictionary<string, double>[] xts, int[] yts, double lambda)
        {
            for (int i = 0; i < xts.Length; i++)
            {
                int t = i + 1;
                double etat = 1 / (lambda * t);
                Update(xts[i], yts[i], etat);
            }
        }

        public void TrainSpecificClass(Dictionary<string, double>[] xts, int[] yts, double lambda, int target)
        {
            for (int i = 0; i < xts.Length; i++)
            {
                int t = i + 1;
                double etat = 1 / (lambda * t);
                int label = (yts[i] == target ? 1 : -1);
                Update(xts[i], label, etat);
            }
        }

    }
}
