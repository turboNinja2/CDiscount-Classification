using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NDSB.SparseMappings;

namespace NDSB.Models.SparseModels
{
    using System;
    using Point = Dictionary<string, double>;

    public static class KNNHelper
    {

        public static int[] GetPredictions(KNN model, IMapping<Point> map, string trainFilePath, string testFilePath, string trainLabelsPath)
        {
            Point[] trainSet = CSRHelper.ImportPoints(trainFilePath),
                testSet = CSRHelper.ImportPoints(testFilePath);

            Parallel.For(0, trainSet.Length, i => { trainSet[i] = map.Map(trainSet[i]); });
            Parallel.For(0, testSet.Length, i => { testSet[i] = map.Map(testSet[i]); });

            int[] trainLabels = DSCdiscountUtils.ReadLabelsFromTraining(trainLabelsPath),
                predicted = ClassificationHelper.TrainAndPredict(model, trainSet, trainLabels, testSet);

            return predicted;
        }

        public static double ValidateAndGetError(KNN model, IMapping<Point> map, string trainFilePath, string validationFilePath, string trainLabelsPath, string validationLabelsPath)
        {
            int[] validationLabels = DSCdiscountUtils.ReadLabelsFromTraining(validationLabelsPath);
            return ClassificationHelper.Accuracy(GetPredictions(model, map, trainFilePath, validationFilePath, trainLabelsPath), validationLabels);
        }


        public static string PrepareDataAndValidateModels(KNN[] models, IMapping<Point> map, string trainFilePath, string validationFilePath)
        {
            string tfidfValidationFile = TFIDF.TextToTFIDFCSR(validationFilePath),
                tfidfTrainFile = TFIDF.TextToTFIDFCSR(trainFilePath);

            string cvPath = Path.GetDirectoryName(trainFilePath) + "\\CrossValidation.csv";

            for (int i = 0; i < models.Length; i++)
            {
                double currentError = ValidateAndGetError(models[i], map, tfidfTrainFile, tfidfValidationFile, trainFilePath, validationFilePath);
                string desc = "KNN " + Path.GetFileNameWithoutExtension(trainFilePath) + ";" + map.Description() + ";" + models[i].Description() + ";" + currentError + Environment.NewLine;
                File.AppendAllText(cvPath, desc);
            }
            return cvPath;
        }

        public static void PrepareDataAndWritePredictions(KNN[] models, IMapping<Point> map, string trainFilePath, string validationFilePath)
        {
            string tfidfValidationFile = TFIDF.TextToTFIDFCSR(validationFilePath),
                tfidfTrainFile = TFIDF.TextToTFIDFCSR(trainFilePath);

            for (int i = 0; i < models.Length; i++)
            {
                string desc = Path.GetFileNameWithoutExtension(trainFilePath) + models[i].Description() + "_" + map.Description();
                int[] pred = GetPredictions(models[i], map, tfidfTrainFile, tfidfValidationFile, trainFilePath);
                List<string> toWrite = new List<string>();
                toWrite.Add(desc);
                toWrite.AddRange(pred.Select(c => c.ToString()));
                File.WriteAllLines(Path.GetDirectoryName(trainFilePath) + "\\" + desc + ".csv", toWrite);
            }

        }
    }
}
