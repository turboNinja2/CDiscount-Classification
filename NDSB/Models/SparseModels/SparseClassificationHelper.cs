using System.Collections.Generic;
using System.IO;

namespace NDSB.Models
{
    using Point = Dictionary<string, double>;

    public static class SparseClassificationHelper
    {

        public static double ValidateAndGetError(IModelClassification<Point> model, string trainFilePath, string validationFilePath, string trainLabelsPath, string validationLabelsPath)
        {
            Point[] trainSet = CSRHelper.ImportPoints(trainFilePath),
                validationSet = CSRHelper.ImportPoints(validationFilePath);

            int[] trainLabels = DSCdiscountUtils.ReadLabelsFromTraining(trainLabelsPath),
                validationLabels = DSCdiscountUtils.ReadLabelsFromTraining(validationLabelsPath),
                predicted = ClassificationHelper.TrainAndPredict(model, trainSet, trainLabels, validationSet);

            return ClassificationHelper.Accuracy(predicted, validationLabels);
        }

        public static string PrepareDataAndValidateModels(IModelClassification<Point>[] models, string trainFilePath, string validationFilePath)
        {
            string tfidfValidationFile = TFIDF.TextToTFIDFCSR(validationFilePath),
                tfidfTrainFile = TFIDF.TextToTFIDFCSR(trainFilePath);

            string cvPath = Path.GetDirectoryName(trainFilePath) + "\\CrossValidation.csv";

            for (int i = 0; i < models.Length; i++)
            {
                double currentError = ValidateAndGetError(models[i], tfidfTrainFile, tfidfValidationFile, trainFilePath, validationFilePath);
                string desc = trainFilePath + ";" + models[i].Description() + ";" + currentError;
                File.AppendAllText(cvPath, desc);
            }

            return cvPath;
        }
    }
}
