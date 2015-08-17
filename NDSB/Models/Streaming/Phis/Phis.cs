using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NDSB;

namespace DataScienceECom.Phis
{
    public delegate Tuple<T, List<string>> Phi<T>(string line, string header);

    public delegate string StringTransform(string inputString);

    public static class Phis
    {
        private static Tuple<int, List<string>> phiInteract2(string line, string header, StringTransform sf, PriceTransform pt)
        {
            line = line.ToLower();
            string[] predictors = (sf(line)).Split(';');
            string[] headerElements = header.Split(';');

            List<string> hashedPredictors = new List<string>();
            int answer = 0;
            string priceHash = "";
            string brandHash = "";

            for (int i = 0; i < headerElements.Length; i++)
            {
                string currentHeaderElt = headerElements[i];
                if (currentHeaderElt == "Categorie3")
                {
                    answer = Convert.ToInt32(predictors[i]);
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
                    brandHash = "mq_" + brandName;
                    continue;
                }

                string[] splittedElt = predictors[i].Split(' ');
                hashedPredictors.AddRange(ListExtensions.CartesianProduct(splittedElt.Where(c => c.Length > 2).ToList()));
            }
            hashedPredictors.Add(brandHash);
            hashedPredictors.Add(priceHash);
            hashedPredictors.Add(brandHash + priceHash);
            return new Tuple<int, List<string>>(answer, hashedPredictors);
        }

        public static Tuple<int, List<string>> phi17(string line, string header)
        {
            return phiInteract2(line, header, StringCleaner.RemoveSomePunctuationAndAccents, PriceTransforms.LogPrice);
        }
    }
}
