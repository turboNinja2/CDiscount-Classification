using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NDSB.SparseMethods;
using System.Threading.Tasks;
using NDSB.SparseMappings;

namespace NDSB
{
    public static class MLHelper
    {

        public static void TFIDFTrainAndPredict(int maxElementsPerClass, int nbNeighbours,
    string trainFilePath, string testFilePath)
        {
            string downSampledFilePath = DownSample.Split(trainFilePath, maxElementsPerClass,
                DSCdiscountUtils.GetLabelCDiscountDB);

            string testTFIDFFilePath = DSCdiscountUtils.TextToTFIDFCSR(testFilePath);
            string trainTFIDFFilePath = DSCdiscountUtils.TextToTFIDFCSR(downSampledFilePath);
            string labelsFilePath = DSCdiscountUtils.ExtractLabelsFromTraining(downSampledFilePath);

            File.Delete(downSampledFilePath);

            Dictionary<string, double>[] trainPoints = CSRHelper.ImportPoints(trainTFIDFFilePath);
            Dictionary<string, double>[] testPoints = CSRHelper.ImportPoints(testTFIDFFilePath);
            int[] labels = DSCdiscountUtils.ReadLabels(labelsFilePath);

            #region Centroids

            string[] predicted2 = NearestCentroid.TrainAndPredict(new NearestCentroid((new Interactions(2, 20))), trainPoints, labels, testPoints);

            string outfileNameNC2 = Path.GetDirectoryName(trainTFIDFFilePath) + "\\" + Path.GetFileNameWithoutExtension(trainTFIDFFilePath) +
                "_nc_Interactions_" + maxElementsPerClass + "_pred.txt";

            File.AppendAllText(outfileNameNC2, String.Join(Environment.NewLine, predicted2));

            string[] predicted3 = NearestCentroid.TrainAndPredict(new NearestCentroid((new PureInteractions(2, 20))), trainPoints, labels, testPoints);

            string outfileNameNC3 = Path.GetDirectoryName(trainTFIDFFilePath) + "\\" + Path.GetFileNameWithoutExtension(trainTFIDFFilePath) +
                "_nc_pureInteractions_" + maxElementsPerClass + "_pred.txt";

            File.AppendAllText(outfileNameNC3, String.Join(Environment.NewLine, predicted3));

            string[] predicted = NearestCentroid.TrainAndPredict(new NearestCentroid((new Identity<Dictionary<string, double>>())), trainPoints, labels, testPoints);

            string outfileNameNC = Path.GetDirectoryName(trainTFIDFFilePath) + "\\" + Path.GetFileNameWithoutExtension(trainTFIDFFilePath) +
                "_nc_identity_" + maxElementsPerClass + "_pred.txt";

            File.AppendAllText(outfileNameNC, String.Join(Environment.NewLine, predicted));

            #endregion

            #region KNN

            string outfileNameKNN = Path.GetDirectoryName(trainTFIDFFilePath) + "\\" + Path.GetFileNameWithoutExtension(trainTFIDFFilePath) +
                "_knn_" + maxElementsPerClass + "_" + nbNeighbours + "_pred.txt";

            string[] predictedKNN = new string[testPoints.Count()];

            for (int i = 0; i < trainPoints.Length; i++)
                trainPoints[i] = LinearSpace.ToCube(trainPoints[i]);

            KNNII knn = new KNNII();
            knn.StampInverseDictionary(trainPoints, 0.5);

            Parallel.For(0, testPoints.Length, i =>
            {
                int[] pred = knn.NearestNeighbours(labels, trainPoints, LinearSpace.ToCube(testPoints[i]), nbNeighbours, MetricSpace.ManhattanDistance);
                predictedKNN[i] = String.Join(";", pred);
            });

            File.AppendAllText(outfileNameKNN, String.Join(Environment.NewLine, predictedKNN));

            #endregion

            File.Delete(labelsFilePath);
            File.Delete(testTFIDFFilePath);
            File.Delete(trainTFIDFFilePath);
        }
    }
}
