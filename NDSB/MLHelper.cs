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
            #region Prepare data

            string downSampledFilePath = DownSample.Split(trainFilePath, maxElementsPerClass,
                DSCdiscountUtils.GetLabelCDiscountDB);

            string testTFIDFFilePath = DSCdiscountUtils.TextToTFIDFCSR(testFilePath);
            string trainTFIDFFilePath = DSCdiscountUtils.TextToTFIDFCSR(downSampledFilePath);
            string labelsFilePath = DSCdiscountUtils.ExtractLabels(downSampledFilePath);
            File.Delete(downSampledFilePath);

            #endregion

            Dictionary<string, double>[] trainPoints = CSRHelper.ImportPoints(trainTFIDFFilePath);
            Dictionary<string, double>[] testPoints = CSRHelper.ImportPoints(testTFIDFFilePath);
            int[] labels = DSCdiscountUtils.ReadLabels(labelsFilePath);

            #region Centroids

            string[] predicted2 = NearestCentroid.TrainAndPredict(
                new NearestCentroid((new PureInteractions(2, 20))), 
                trainPoints, labels, testPoints);

            string outfileNameNC2 = Path.GetDirectoryName(trainTFIDFFilePath) + "\\" + Path.GetFileNameWithoutExtension(trainTFIDFFilePath) +
                "_nc_PureInteractions_" + maxElementsPerClass + "_pred.txt";

            File.AppendAllText(outfileNameNC2, String.Join(Environment.NewLine, predicted2));

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

        public static void KNN_CrossValidate(int nbNeighbours, int maxElementsPerClass, string trainFilePath, string validationFilePath)
        {
            string downSampledFilePath = DownSample.Split(trainFilePath, maxElementsPerClass,
               DSCdiscountUtils.GetLabelCDiscountDB);

            string validationTFIDFFilePath = DSCdiscountUtils.TextToTFIDFCSR(validationFilePath);
            string trainTFIDFFilePath = DSCdiscountUtils.TextToTFIDFCSR(downSampledFilePath);
            string labelsFilePath = DSCdiscountUtils.ExtractLabels(downSampledFilePath);
            string validationLabelsFilePath = DSCdiscountUtils.ExtractLabels(validationFilePath);

            File.Delete(downSampledFilePath);

            Dictionary<string, double>[] trainPoints = CSRHelper.ImportPoints(trainTFIDFFilePath);
            Dictionary<string, double>[] validationPoints = CSRHelper.ImportPoints(validationLabelsFilePath);
            int[] trainLabels = DSCdiscountUtils.ReadLabels(labelsFilePath);
            int[] validationLabels = DSCdiscountUtils.ReadLabels(validationLabelsFilePath);

        }

        public static void KNN_GetError(int nbNeighbours, int maxElementsPerClass,
            Dictionary<string, double>[] trainPoints, Dictionary<string, double>[] validationPoints, 
            int[] trainLabels, int[] validationLabels, IMapping<Dictionary<string,double>> mapping)
        {
            int[][] predictedKNNScaled = new int[validationPoints.Count()][];

            for (int i = 0; i < trainPoints.Length; i++)
                trainPoints[i] = mapping.Map(trainPoints[i]);

            KNNII knnScaled = new KNNII();
            knnScaled.StampInverseDictionary(trainPoints, 0.3);

            Parallel.For(0, validationPoints.Length, i =>
            {
                int[] pred = knnScaled.NearestLabels(trainLabels, trainPoints, mapping.Map(validationPoints[i]),
                    nbNeighbours, MetricSpace.ManhattanDistance);
                predictedKNNScaled[i] = pred;
            });

        }

    }
}
