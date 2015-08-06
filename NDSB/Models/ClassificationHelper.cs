using System;
using System.Linq;
using System.Threading.Tasks;

namespace NDSB.Models
{
    public static class ClassificationHelper
    {
        private static ParallelOptions _parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = Globals.NbCores };

        public static int[] TrainAndPredict<T>(IModelClassification<T> model, T[] trainPoints, int[] labels, T[] testPoints)
        {
            model.Train(labels, trainPoints);

            int[] predicted = new int[testPoints.Count()];
            Parallel.For(0, testPoints.Length, _parallelOptions, i =>
            {
                int pred = model.Predict(testPoints[i]);
                predicted[i] = pred;
            });
            return predicted;
        }

        public static Tuple<int[], int[]> TrainValidateAndPredict<T>(IModelClassification<T> model, T[] trainPoints, int[] labels, T[] validationPoints, T[] testPoints)
        {
            model.Train(labels, trainPoints);

            int[] predictedTest = new int[testPoints.Length];
            Parallel.For(0, testPoints.Length, _parallelOptions, i =>
            {
                int pred = model.Predict(testPoints[i]);
                predictedTest[i] = pred;
            });

            int[] predictedValidation = new int[validationPoints.Length];
            Parallel.For(0, validationPoints.Length, _parallelOptions, i =>
            {
                int pred = model.Predict(validationPoints[i]);
                predictedValidation[i] = pred;
            });

            return new Tuple<int[], int[]>(predictedTest, predictedValidation);
        }

        public static double Accuracy(int[] predicted, int[] validationLabels)
        {
            int acc = 0;
            for (int i = 0; i < validationLabels.Length; i++)
                if (predicted[i] == validationLabels[i])
                    acc++;
            return acc * 1f / validationLabels.Length;
        }
    }
}
