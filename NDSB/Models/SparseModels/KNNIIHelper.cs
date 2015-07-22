using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NDSB.SparseMappings;


namespace NDSB.Models.SparseModels
{
    using Point = Dictionary<string, double>;

    public static class KNNIIHelper
    {

        public static int[] GetPredictions(KNNII model, IMapping<Point> map, string trainFilePath, string testFilePath, string trainLabelsPath)
        {
            Point[] trainSet = CSRHelper.ImportPoints(trainFilePath),
                testSet = CSRHelper.ImportPoints(testFilePath);

            Parallel.For(0, trainSet.Length, i => { trainSet[i] = map.Map(trainSet[i]); });
            Parallel.For(0, testSet.Length, i => { testSet[i] = map.Map(testSet[i]); });

            int[] trainLabels = DSCdiscountUtils.ReadLabelsFromTraining(trainLabelsPath),
                predicted = ClassificationHelper.TrainAndPredict(model, trainSet, trainLabels, testSet);

            return predicted;
        }

        public static double ValidateAndGetError(KNNII model, IMapping<Point> map, string trainFilePath, string validationFilePath, string trainLabelsPath, string validationLabelsPath)
        {
            int[] validationLabels = DSCdiscountUtils.ReadLabelsFromTraining(validationLabelsPath);
            return ClassificationHelper.Accuracy(GetPredictions(model, map, trainFilePath, validationFilePath, trainFilePath), validationLabels);
        }


        public static string PrepareDataAndValidateModels(KNNII[] models, IMapping<Point> map, string trainFilePath, string validationFilePath)
        {
            string tfidfValidationFile = TFIDF.TextToTFIDFCSR(validationFilePath),
                tfidfTrainFile = TFIDF.TextToTFIDFCSR(trainFilePath);

            string cvPath = Path.GetDirectoryName(trainFilePath) + "\\CrossValidation.csv";

            for (int i = 0; i < models.Length; i++)
            {
                double currentError = ValidateAndGetError(models[i], map, tfidfTrainFile, tfidfValidationFile, trainFilePath, validationFilePath);
                string desc = "KNN " + trainFilePath + ";" + map.Description() + ";" + models[i].Description() + ";" + currentError;
                File.AppendAllText(cvPath, desc);
            }
            return cvPath;
        }


    }
}
