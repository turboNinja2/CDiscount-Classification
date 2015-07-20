using System.Linq;
using System.Threading.Tasks;

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
    }
}
