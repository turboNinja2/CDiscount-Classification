using System;
using System.Collections.Generic;
using System.Globalization;
using NDSB.Models.Streaming.Phis;

namespace DataScienceECom.Phis
{
    public static class HierachicalPhis
    {
        private static Tuple<Hierarchy, List<string>> phiSmart2(string line, string header,
    StringTransform sf,
    int minLetters, int maxLetters, int minLetters2,
    PriceTransform pt)
        {
            line = line.ToLower();
            string[] predictors = (sf(line)).Split(';');
            string[] headerElements = header.Split(';');

            List<string> hashedPredictors = new List<string>();
            string priceHash = "";
            string brandHash = "";

            Hierarchy answer = new Hierarchy(0, 0, 0);

            for (int i = 0; i < headerElements.Length; i++)
            {
                string currentHeaderElt = headerElements[i];

                if (currentHeaderElt == "Categorie3")
                {
                    answer.Cat3 = Convert.ToInt32(predictors[i]);
                    continue;
                }
                if (currentHeaderElt == "Categorie2")
                {
                    answer.Cat2 = Convert.ToInt32(predictors[i]);
                    continue;
                }
                if (currentHeaderElt == "Categorie1")
                {
                    answer.Cat1 = Convert.ToInt32(predictors[i]);
                    continue;
                }

                if (currentHeaderElt.StartsWith("Cat") || currentHeaderElt.StartsWith("Ident")) continue;

                if (currentHeaderElt == "prix")
                {
                    priceHash = "px_" + pt(Convert.ToDouble(predictors[i], CultureInfo.GetCultureInfo("en-US")));
                    continue;
                }

                if (currentHeaderElt == "Marque")
                {
                    string brandName = predictors[i];
                    if (String.Equals(brandName, "aucune")) brandName = "";
                    brandHash = "Mq_" + brandName;
                    continue;
                }

                string[] splittedElt = predictors[i].Split(' ');

                string previous = "";
                foreach (string str in splittedElt)
                {
                    if (str.Length > minLetters && str.Length < maxLetters)
                    {
                        string strToAdd = str;
                        if (str.EndsWith("s"))
                            strToAdd = str.Substring(0, str.Length - 1);

                        hashedPredictors.Add(strToAdd);
                        if (previous.Length > 0)
                            hashedPredictors.Add(strToAdd + "_" + previous);
                        previous = strToAdd;
                        continue;
                    }

                    if (str.Length > minLetters2)
                        hashedPredictors.Add(str);
                }
            }

            if (priceHash != "px_-1") hashedPredictors.Add(priceHash);

            if (brandHash != "Mq_")
            {
                hashedPredictors.Add(brandHash);
                if (priceHash != "px_-1") hashedPredictors.Add(brandHash + "_" + priceHash);
            }

            return new Tuple<Hierarchy, List<string>>(answer, hashedPredictors);
        }

        public static Tuple<Hierarchy, List<string>> phi18(string line, string header)
        {
            return phiSmart2(line, header, StringCleaner.RemoveMorePunctuationAndAccents4, 1, 20, 20, PriceTransforms.LogPrice);
        }
    }
}
