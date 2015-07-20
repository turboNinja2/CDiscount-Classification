using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NDSB.SparseMethods;
using System.Threading.Tasks;
using NDSB.SparseMappings;
using NDSB.Models;

namespace NDSB
{
    public static class MLHelper
    {




        public static void TFIDFTrainAndPredict(int maxElementsPerClass, int nbNeighbours,
    string trainFilePath, string testFilePath)
        {
            #region Prepare data

            string downSampledFilePath = DownSample.Split(trainFilePath, maxElementsPerClass,
                DSCdiscountUtils.GetLabelCDiscountDB);

            string testTFIDFFilePath = DSCdiscountUtils.TextToTFIDFCSR(testFilePath);
            string trainTFIDFFilePath = DSCdiscountUtils.TextToTFIDFCSR(downSampledFilePath);
            string labelsFilePath = DSCdiscountUtils.ExtractLabelsFromTraining(downSampledFilePath);
            File.Delete(downSampledFilePath);

            #endregion

            Dictionary<string, double>[] trainPoints = CSRHelper.ImportPoints(trainTFIDFFilePath);
            Dictionary<string, double>[] testPoints = CSRHelper.ImportPoints(testTFIDFFilePath);
            int[] labels = DSCdiscountUtils.ReadLabels(labelsFilePath);


            #region Centroids

            int[] predicted2 = ClassificationHelper.TrainAndPredict(new NearestCentroid((new Interactions(2, 20, 0.1))), trainPoints, labels, testPoints);

            string outfileNameNC2 = Path.GetDirectoryName(trainTFIDFFilePath) + "\\" + Path.GetFileNameWithoutExtension(trainTFIDFFilePath) +
                "_nc_Interactions_01_" + maxElementsPerClass + "_pred.txt";

            File.AppendAllText(outfileNameNC2, String.Join(Environment.NewLine, predicted2));

            int[] predicted3 = ClassificationHelper.TrainAndPredict(new NearestCentroid((new Interactions(2, 20, 0.5))), trainPoints, labels, testPoints);

            string outfileNameNC3 = Path.GetDirectoryName(trainTFIDFFilePath) + "\\" + Path.GetFileNameWithoutExtension(trainTFIDFFilePath) +
                "_nc_Interactions_05_" + maxElementsPerClass + "_pred.txt";

            File.AppendAllText(outfileNameNC3, String.Join(Environment.NewLine, predicted3));

            #endregion


            /*
            #region KNN

            string[] predictedKNN = new string[testPoints.Count()];

            KNNII knn = new KNNII();
            knn.StampInverseDictionary(trainPoints, 3);

            Parallel.For(0, testPoints.Length, i =>
            {
                int[] pred = knn.NearestLabels(labels, trainPoints, testPoints[i], nbNeighbours, MetricSpace.ManhattanDistance);
                predictedKNN[i] = String.Join(";", pred);
            });

            string outfileNameKNN = Path.GetDirectoryName(trainTFIDFFilePath) + "\\" + Path.GetFileNameWithoutExtension(trainTFIDFFilePath) +
                "_knn_" + maxElementsPerClass + "_" + nbNeighbours + "_pred.txt";
            File.AppendAllText(outfileNameKNN, String.Join(Environment.NewLine, predictedKNN));


            string[] predictedKNNScaled = new string[testPoints.Count()];
            
            for (int i = 0; i < trainPoints.Length; i++)
                trainPoints[i] = LinearSpace.ToCube(trainPoints[i]);

            KNNII knnScaled = new KNNII();
            knnScaled.StampInverseDictionary(trainPoints, 0.5);

            Parallel.For(0, testPoints.Length, i =>
            {
                int[] pred = knnScaled.NearestLabels(labels, trainPoints, LinearSpace.ToCube(testPoints[i]), nbNeighbours, MetricSpace.ManhattanDistance);
                predictedKNNScaled[i] = String.Join(";", pred);
            });

            string outfileNameKNNScaled = Path.GetDirectoryName(trainTFIDFFilePath) + "\\" + Path.GetFileNameWithoutExtension(trainTFIDFFilePath) +
                "_knn_scaled_" + maxElementsPerClass + "_" + nbNeighbours + "_pred.txt";
            File.AppendAllText(outfileNameKNNScaled, String.Join(Environment.NewLine, predictedKNNScaled));

            #endregion
            */

            File.Delete(labelsFilePath);
            File.Delete(testTFIDFFilePath);
            File.Delete(trainTFIDFFilePath);
        }
    }
}
