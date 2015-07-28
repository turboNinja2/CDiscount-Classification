using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NDSB.Models.SparseModels
{
    using Point = Dictionary<string, double>;

    public static class GenericMLHelper
    {
        public static string TrainPredictAndWrite(IModelClassification<Point>[] models, string trainFilePath, string testFilePath)
        {
            string tfidfTestFile = TFIDF.TextToTFIDFCSR(testFilePath),
                tfidfTrainFile = TFIDF.TextToTFIDFCSR(trainFilePath);

            return TrainPredictAndWriteFromTFIDF(models, trainFilePath, tfidfTrainFile, tfidfTestFile);
        }

        public static string TrainPredictAndWriteFromTFIDF(IModelClassification<Point>[] models, string trainFilePath, string tfidfTrainFile, string tfidfTestFile)
        {
            Point[] trainSet = CSRHelper.ImportPoints(tfidfTrainFile),
                validationSet = CSRHelper.ImportPoints(tfidfTestFile);

            int[] trainLabels = DSCdiscountUtils.ReadLabelsFromTraining(trainFilePath);

            for (int i = 0; i < models.Length; i++)
            {
                int[] predicted = ClassificationHelper.TrainAndPredict(models[i], trainSet, trainLabels, validationSet);
                string desc = Path.GetFileNameWithoutExtension(trainFilePath) + models[i].Description();
                string filePath = Path.GetDirectoryName(trainFilePath) + "\\" + desc + ".csv";
                File.AppendAllText(filePath, desc + Environment.NewLine);
                File.AppendAllLines(filePath, predicted.Select(c => c.ToString()));
            }
            return trainFilePath;
        }
    }
}
