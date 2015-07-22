using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NDSB.SparseMappings;

namespace NDSB.Models.SparseModels
{
    using Point = Dictionary<string, double>;
    using NDSB.SparseMethods;

    public static class NearestCentroidHelper
    {
        public static string TrainPredictAndWrite(NearestCentroid[] models, string trainFilePath, string testFilePath)
        {
            string tfidfValidationFile = TFIDF.TextToTFIDFCSR(testFilePath),
                tfidfTrainFile = TFIDF.TextToTFIDFCSR(trainFilePath);

            Point[] trainSet = CSRHelper.ImportPoints(tfidfTrainFile),
                validationSet = CSRHelper.ImportPoints(tfidfValidationFile);

            int[] trainLabels = DSCdiscountUtils.ReadLabelsFromTraining(trainFilePath);

            for (int i = 0; i < models.Length; i++)
            {
                int[] predicted = ClassificationHelper.TrainAndPredict(models[i], trainSet, trainLabels, validationSet);
                string desc =  Path.GetFileNameWithoutExtension(trainFilePath) + "_NC_" + models[i].Description() ;
                string filePath = Path.GetDirectoryName(trainFilePath) + "\\" + desc + ".csv";
                File.AppendAllText(filePath, desc);
                File.AppendAllLines(filePath, predicted.Select(c=> c.ToString()));
            }
            return trainFilePath;
        }
    }
}
