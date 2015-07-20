using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDSB.SparseMethods;
using System.IO;

namespace NDSB.Models
{
    public static class DirtyHelpers
    {
        public static void RunKNN(string trainFilePath, string testFilePath, int nbNeighbours = 60, int maxEltsPerClass = 800)
        {
            string dsTrainFile = DownSample.Split(trainFilePath, maxEltsPerClass, DSCdiscountUtils.GetLabelCDiscountDB),
                tfidfTestFile = TFIDF.TextToTFIDFCSR(testFilePath),
                tfidfTrainFile = TFIDF.TextToTFIDFCSR(dsTrainFile);

            KNNII knn = new KNNII(MetricSpace.EuclideDistance, nbNeighbours, 0.5);

            Dictionary<string, double>[] trainSet = CSRHelper.ImportPoints(tfidfTrainFile),
                testSet = CSRHelper.ImportPoints(tfidfTestFile);

            Parallel.For(0, trainSet.Length, i => { trainSet[i] = LinearSpace.ToSphere(trainSet[i]); });
            Parallel.For(0, testSet.Length, i => { testSet[i] = LinearSpace.ToSphere(testSet[i]); });

            int[] preds = ClassificationHelper.TrainAndPredict(knn, trainSet, DSCdiscountUtils.ReadLabelsFromTraining(dsTrainFile), testSet);

            string predPath = Path.GetDirectoryName(dsTrainFile) + "\\" + Path.GetFileNameWithoutExtension(dsTrainFile) + "_" + knn.Description() + ".csv";
            File.WriteAllLines(predPath, preds.Select(c => c.ToString()).ToArray());

            TFIDF.Clear();
        }

    }
}
