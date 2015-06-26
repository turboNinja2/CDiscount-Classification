using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace NDSB.SparseMethods
{
    class SparseMulticlassPerceptron
    {
        private ConcurrentDictionary<int, SparsePerceptron> _perceptrons = new ConcurrentDictionary<int, SparsePerceptron>();

        public void Train(Dictionary<string, double>[] xts, int[] yts, double lambda)
        {
            int[] labels = yts.Distinct().ToArray();
            int nbClasses = labels.Length;

            int approxTrainedPerceptrons = 0;

            Parallel.For(0, nbClasses, i =>
            {
                SparsePerceptron currentPerceptron = new SparsePerceptron();
                currentPerceptron.TrainSpecificClass(xts, yts, lambda, labels[i]);
                _perceptrons.TryAdd(labels[i], currentPerceptron);
                approxTrainedPerceptrons++;
            });
        }




    }
}
