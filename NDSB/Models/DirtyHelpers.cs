using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDSB.SparseMethods;
using System.IO;
using NDSB.SparseMappings;

namespace NDSB.Models
{
    public static class DirtyHelpers
    {
        public static void DownsampleTFIDFRunKNN(string trainFilePath, string testFilePath, int nbNeighbours = 60, int maxEltsPerClass = 800)
        {
            string dsTrainFile = DownSample.Run(trainFilePath, maxEltsPerClass, DSCdiscountUtils.GetLabelCDiscountDB),
                tfidfTestFile = TFIDF.TextToTFIDFCSR(testFilePath),
                tfidfTrainFile = TFIDF.TextToTFIDFCSR(dsTrainFile);

            KNNII knn = new KNNII(Distances.Norm3, nbNeighbours, 0.5);

            Dictionary<string, double>[] trainSet = CSRHelper.ImportPoints(tfidfTrainFile),
                testSet = CSRHelper.ImportPoints(tfidfTestFile);

            ToSphere toSphere = new ToSphere();

            Parallel.For(0, trainSet.Length, i => { trainSet[i] = toSphere.Map(trainSet[i]); });
            Parallel.For(0, testSet.Length, i => { testSet[i] = toSphere.Map(testSet[i]); });

            int[] preds = ClassificationHelper.TrainAndPredict(knn, trainSet, DSCdiscountUtils.ReadLabelsFromTraining(dsTrainFile), testSet);

            string predPath = Path.GetDirectoryName(dsTrainFile) + "\\" + Path.GetFileNameWithoutExtension(dsTrainFile) + "_" + knn.Description() + ".csv";
            File.WriteAllLines(predPath, preds.Select(c => c.ToString()).ToArray());

            TFIDF.Clear();

            File.Delete(dsTrainFile);
            File.Delete(tfidfTestFile);
            File.Delete(tfidfTrainFile);
        }

        public static void GetAccuracy(string trainFilePath, string testFilePath, int maxEltsPerClass = 800)
        {

        }

    }
}
