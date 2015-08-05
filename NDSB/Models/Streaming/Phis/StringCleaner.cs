using System.Text.RegularExpressions;

namespace DataScienceECom.Phis
{
    public static class StringCleaner
    {
        public static string None(string input)
        {
            return input;
        }

        public static string RemoveSomePunctuationAndAccents(string input)
        {
            input = input.Replace(":", "");
            input = input.Replace(".", "");

            input = input.Replace("é", "e");
            input = input.Replace("è", "e");
            input = input.Replace("ê", "e");
            input = input.Replace("à", "a");

            return input;
        }

        public static string RemoveMorePunctuationAndAccents(string input)
        {
            input = RemoveSomePunctuationAndAccents(input);

            input = input.Replace("?", "");
            input = input.Replace("!", "");
            input = input.Replace("*", "");

            return input;
        }

        public static string RemoveMorePunctuationAndAccents2(string input)
        {
            input = RemoveSomePunctuationAndAccents(input);

            input = input.Replace("?", "");
            input = input.Replace("!", "");
            input = input.Replace("*", "");
            input = input.Replace(".", "");

            return input;
        }

        public static string RemoveMorePunctuationAndAccents3(string input)
        {
            input = input.Replace(":", "");
            input = input.Replace(".", "");

            input = input.Replace("é", "e");
            input = input.Replace("è", "e");
            input = input.Replace("ê", "e");
            input = input.Replace("à", "a");

            input = input.Replace("?", "");
            input = input.Replace("!", "");
            input = input.Replace("*", "");
            input = input.Replace(".", "");

            input = input.Replace("/", "");
            input = input.Replace("-", "");
            input = Regex.Replace(input, "<br*>", "");

            return input;
        }
    }
}
