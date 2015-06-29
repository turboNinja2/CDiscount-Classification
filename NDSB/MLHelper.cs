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

            NearestCentroid nc2 = new NearestCentroid(new InteractionsSparse(2,20));
            nc2.Train(labels, trainPoints);

            string[] predicted2 = new string[testPoints.Count()];
            Parallel.For(0, testPoints.Length, i =>
            {
                int pred = nc2.Predict(testPoints[i]);
                predicted2[i] = pred.ToString();
            });

            string outfileNameNC2 = Path.GetDirectoryName(trainTFIDFFilePath) + "\\" + Path.GetFileNameWithoutExtension(trainTFIDFFilePath) +
                "_nc2_" + maxElementsPerClass + "_pred.txt";

            File.AppendAllText(outfileNameNC2, String.Join(Environment.NewLine, predicted2));


            NearestCentroid nc = new NearestCentroid(new IdentitySparse<Dictionary<string,double>>());
            nc.Train(labels, trainPoints);

            string[] predicted = new string[testPoints.Count()];
            Parallel.For(0, testPoints.Length, i =>
            {
                int pred = nc.Predict(testPoints[i]);
                predicted[i] = pred.ToString();
            });

            string outfileNameNC = Path.GetDirectoryName(trainTFIDFFilePath) + "\\" + Path.GetFileNameWithoutExtension(trainTFIDFFilePath) +
                "_nc_" + maxElementsPerClass + "_pred.txt";

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
