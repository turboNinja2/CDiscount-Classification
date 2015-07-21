using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using NDSB.SparseMappings;

namespace NDSB.Models
{
    public static class ClassificationHelper
    {
        public static int[] TrainAndPredict<T>(IModelClassification<T> model, T[] trainPoints, int[] labels, T[] testPoints)
        {
            model.Train(labels, trainPoints);
            int[] predicted = new int[testPoints.Count()];
            Parallel.For(0, testPoints.Length, i =>
            {
                int pred = model.Predict(testPoints[i]);
                predicted[i] = pred;
            });
            return predicted;
        }

        public static double Accuracy<T>(IModelClassification<T> model, T[] trainPoints, int[] labels, T[] validationPoints, int[] validationLabels)
        {
            int[] predicted = TrainAndPredict(model, trainPoints, labels, validationPoints);
            int acc = 0;
            for (int i = 0; i < validationLabels.Length; i++)
                if (predicted[i] == validationLabels[i])
                    acc++;

            return acc * 1f / validationLabels.Length;
        }
    }
}
