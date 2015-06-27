using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace NDSB.SparseMethods
{
    class MulticlassPerceptron
    {
        private ConcurrentDictionary<int, Perceptron> _perceptrons = new ConcurrentDictionary<int, Perceptron>();

        public void Train(Dictionary<string, double>[] xts, int[] yts, double lambda)
        {
            int[] labels = yts.Distinct().ToArray();
            int nbClasses = labels.Length;

            int approxTrainedPerceptrons = 0;

            Parallel.For(0, nbClasses, i =>
            {
                Perceptron currentPerceptron = new Perceptron();
                currentPerceptron.TrainSpecificClass(xts, yts, lambda, labels[i]);
                _perceptrons.TryAdd(labels[i], currentPerceptron);
                approxTrainedPerceptrons++;
            });
        }




    }
}
