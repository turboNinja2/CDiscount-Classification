using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NDSB.Models.SparseModels
{
    using Point = Dictionary<string, double>;

    public static class GenericMLHelper
    {
        public static string TrainPredictAndWrite(IModelClassification<Point>[] models, string trainFilePath, string testFilePath, bool stem)
        {
            string tfidfTestFile = TFIDF.TextToTFIDFCSR(testFilePath, stem),
                tfidfTrainFile = TFIDF.TextToTFIDFCSR(trainFilePath, stem);

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

        public static void TrainPredictAndValidateTFIDF(IModelClassification<Point>[] models, string trainFilePath, string tfidfTrainFile, string tfidfTestFile, string tfidfValidationFile)
        {
            Point[] trainSet = CSRHelper.ImportPoints(tfidfTrainFile),
                testSet = CSRHelper.ImportPoints(tfidfTestFile),
                validationSet = CSRHelper.ImportPoints(tfidfValidationFile);

            int[] trainLabels = DSCdiscountUtils.ReadLabelsFromTraining(trainFilePath);

            for (int i = 0; i < models.Length; i++)
            {
                Tuple<int[], int[]> res = ClassificationHelper.TrainValidateAndPredict(models[i], trainSet, trainLabels, validationSet, testSet);

                string desc = Path.GetFileNameWithoutExtension(trainFilePath) + models[i].Description();

                Directory.CreateDirectory(Path.GetDirectoryName(trainFilePath) + "\\test");
                string testFilePath = Path.GetDirectoryName(trainFilePath) + "\\test\\test_" + desc + ".csv";

                int[] predictedTest = res.Item1;

                File.WriteAllText(testFilePath, desc + Environment.NewLine);
                File.AppendAllLines(testFilePath, predictedTest.Select(c => c.ToString()));

                Directory.CreateDirectory(Path.GetDirectoryName(trainFilePath) + "\\validation");
                string validationFilePath = Path.GetDirectoryName(trainFilePath) + "\\validation\\" + Path.GetFileNameWithoutExtension(tfidfValidationFile) + "_" + desc + ".csv";

                int[] predictedValidation = res.Item2;
                File.WriteAllText(validationFilePath, desc + Environment.NewLine);
                File.AppendAllLines(validationFilePath, predictedValidation.Select(c => c.ToString()));
            }
        }

        public static void TrainPredictAndValidate(IModelClassification<Point>[] models, string testFilePath, string trainFilePath, string validationFilePath, bool stem)
        {
            string tfidfTestFile = TFIDF.TextToTFIDFCSR(testFilePath, stem),
                tfidfTrainFile = TFIDF.TextToTFIDFCSR(trainFilePath, stem),
                tfidfValidationFile = TFIDF.TextToTFIDFCSR(validationFilePath, stem);

            TFIDF.ClearVocabulary();
            TrainPredictAndValidateTFIDF(models, trainFilePath, tfidfTrainFile, tfidfTestFile, tfidfValidationFile);
        }

    }
}
