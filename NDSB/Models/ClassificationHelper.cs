using System.Linq;
using System.Threading.Tasks;

namespace NDSB.Models
{
    public static class ClassificationHelper
    {
        private static ParallelOptions _parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = 6 };

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
