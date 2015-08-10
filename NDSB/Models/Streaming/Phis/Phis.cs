using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Iveonik.Stemmers;
using NDSB;

namespace DataScienceECom.Phis
{
    public delegate Tuple<T, List<string>> Phi<T>(string line, string header);

    public delegate string StringTransform(string inputString);

    public static class Phis
    {

        private static Tuple<int, List<string>> phiSmart(string line, string header,
            StringTransform sf,
            int minLetters, int maxLetters, int minLetters2,
            PriceTransform pt)
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
                    brandHash = "Mq_" + brandName;
                    continue;
                }


                string[] splittedElt = predictors[i].Split(' ');

                string previous = "";
                foreach (string str in splittedElt)
                {
                    if (str.Length > minLetters && str.Length < maxLetters)
                    {
                        hashedPredictors.Add(str);
                        if (previous.Length > 0)
                            hashedPredictors.Add(str + "_" + previous);
                        previous = str;
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

            return new Tuple<int, List<string>>(answer, hashedPredictors);
        }

        private static Tuple<int, List<string>> phiSmart2(string line, string header,
    StringTransform sf,
    int minLetters, int maxLetters, int minLetters2,
    PriceTransform pt)
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

            return new Tuple<int, List<string>>(answer, hashedPredictors);
        }


        private static Tuple<int, List<string>> phiInteract(string line, string header,
    StringTransform sf, PriceTransform pt)
        {
            line = line.ToLower();
            string[] predictors = (sf(line)).Split(';');
            string[] headerElements = header.Split(';');

            List<string> hashedPredictors = new List<string>();
            int answer = 0;

            for (int i = 0; i < headerElements.Length; i++)
            {
                string currentHeaderElt = headerElements[i];
                if (currentHeaderElt == "Categorie3")
                {
                    answer = Convert.ToInt32(predictors[i]);
                    continue;
                }

                if (currentHeaderElt.StartsWith("Cat") || currentHeaderElt.StartsWith("Ident")) continue;

                string[] splittedElt = predictors[i].Split(' ');
                hashedPredictors.AddRange(ListExtensions.CartesianProduct(splittedElt.Where(c => c.Length > 2).ToList()));

            }
            return new Tuple<int, List<string>>(answer, hashedPredictors);
        }

        private static Tuple<int, List<string>> phiInteract2(string line, string header,
StringTransform sf, PriceTransform pt)
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

        private static Tuple<int, List<string>> phiInteract3(string line, string header,
StringTransform sf, PriceTransform pt)
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
                hashedPredictors.AddRange(ListExtensions.CartesianProduct(splittedElt.Where(c => c.Length > 2).Distinct().ToList()));
            }
            hashedPredictors.Add(brandHash);
            hashedPredictors.Add(priceHash);
            hashedPredictors.Add(brandHash + priceHash);
            return new Tuple<int, List<string>>(answer, hashedPredictors);
        }


        private static Tuple<int, List<string>> phiInteract4(string line, string header,
StringTransform sf, PriceTransform pt)
        {
            line = line.ToLower();
            string[] predictors = (sf(line)).Split(';');
            string[] headerElements = header.Split(';');

            List<string> hashedPredictors = new List<string>();
            int answer = 0;
            string priceHash = "";
            string brandHash = "";

            FrenchStemmer fs = new FrenchStemmer();

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

                for (int k = 0; k < splittedElt.Length; k++)
                    splittedElt[k] = fs.Stem(splittedElt[k]);

                hashedPredictors.AddRange(ListExtensions.CartesianProduct(splittedElt.Where(c => c.Length > 2).Distinct().ToList()));
            }
            hashedPredictors.Add(brandHash);
            hashedPredictors.Add(priceHash);
            hashedPredictors.Add(brandHash + priceHash);
            return new Tuple<int, List<string>>(answer, hashedPredictors);
        }


        public static Tuple<int, List<string>> Stacker(string line, string header)
        {
            string[] predictors = (line).Split(';'),
                headerElements = header.Split(';');

            List<string> hashedPredictors = new List<string>();
            int answer = 0;

            for (int i = 0; i < headerElements.Length; i++)
            {
                string currentHeaderElt = headerElements[i];
                if (currentHeaderElt == "Categorie3")
                {
                    answer = Convert.ToInt32(predictors[i]);
                    continue;
                }
                hashedPredictors.Add(headerElements[i] + "_" + predictors[i]);
            }
            return new Tuple<int, List<string>>(answer, hashedPredictors);
        }

        public static Tuple<int, List<string>> phi12(string line, string header)
        {
            string newLine = Regex.Replace(line, "<br*>", "");

            return phiSmart(newLine, header, StringCleaner.RemoveMorePunctuationAndAccents2,
                3, 20, 2, PriceTransforms.LogPrice);
        }

        public static Tuple<int, List<string>> phi13(string line, string header)
        {
            string newLine = Regex.Replace(line, "<br*>", "");

            return phiSmart(newLine, header, StringCleaner.RemoveMorePunctuationAndAccents2,
                2, 20, 2, PriceTransforms.LogPrice);
        }

        public static Tuple<int, List<string>> phi14(string line, string header)
        {
            return phiSmart(line, header, StringCleaner.RemoveMorePunctuationAndAccents3,
                2, 20, 2, PriceTransforms.LogPrice);

        }

        public static Tuple<int, List<string>> phi15(string line, string header)
        {
            string newLine = Regex.Replace(line, "<br*>", "");
            return phiSmart2(line, header, StringCleaner.RemoveMorePunctuationAndAccents2,
                2, 20, 2, PriceTransforms.LogPrice);

        }

        public static Tuple<int, List<string>> phi16(string line, string header)
        {
            return phiInteract(line, header, StringCleaner.RemoveMorePunctuationAndAccents3, PriceTransforms.LogPrice);
        }

        public static Tuple<int, List<string>> phi17(string line, string header)
        {
            return phiInteract2(line, header, StringCleaner.RemoveMorePunctuationAndAccents3, PriceTransforms.LogPrice);
        }

        public static Tuple<int, List<string>> phi18(string line, string header)
        {
            return phiInteract2(line, header, StringCleaner.RemoveMorePunctuationAndAccents4, PriceTransforms.LogPrice);
        }


        public static Tuple<int, List<string>> phi19(string line, string header)
        {
            return phiInteract3(line, header, StringCleaner.RemoveMorePunctuationAndAccents4, PriceTransforms.LogPrice);
        }


        public static Tuple<int, List<string>> phi20(string line, string header)
        {
            return phiInteract4(line, header, StringCleaner.RemoveMorePunctuationAndAccents5, PriceTransforms.LogPrice);
        }

    }
}
