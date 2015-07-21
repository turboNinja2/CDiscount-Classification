using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NDSB.FileUtils
{
    public static class Shuffler
    {
        public static int NumberOfLines(string file)
        {
            int numberOfLines = 0;
            foreach (string line in LinesEnumerator.YieldLinesOfFile(file))
                numberOfLines++;
            return numberOfLines;
        }

        public static List<string> ReadLinesWithIndex(string file, List<int> indexes)
        {
            indexes.Sort();
            List<string> result = new List<string>();
            if (indexes.Count == 0) return result;
            int numberOfLinesRead = 0;

            int targetIndex = 0;

            foreach (string line in LinesEnumerator.YieldLinesOfFile(file))
            {
                if (numberOfLinesRead == indexes[targetIndex])
                {
                    result.Add(line);
                    targetIndex++;
                    if (targetIndex == indexes.Count) break;
                }
                numberOfLinesRead++;
            }
            return result;
        }

        public static string Shuffle(string file, int seed)
        {
            int numberOfLines = NumberOfLines(file);

            List<int> indexes = new List<int>();
            for (int i = 1; i < numberOfLines; i++)
                indexes.Add(i);

            Random rnd = new Random(seed);
            indexes = indexes.OrderBy(c => rnd.Next()).ToList();

            List<List<int>> indexesSplitted = splitList<int>(indexes, 1000000);

            string outFile = Path.GetDirectoryName(file) + "\\" +
                Path.GetFileNameWithoutExtension(file) + "_sh_seed_" + seed +
                Path.GetExtension(file);

            string header = ReadLinesWithIndex(file, new List<int> { 0 }).First();
            File.AppendAllText(outFile, header + Environment.NewLine);

            for (int i = 0; i < indexesSplitted.Count; i++)
            {
                List<string> selectedLines = ReadLinesWithIndex(file, indexesSplitted[i]);
                selectedLines = selectedLines.OrderBy(x => rnd.Next()).ToList();
                File.AppendAllText(outFile, String.Join(Environment.NewLine, selectedLines));
                if (i < indexesSplitted.Count - 1)
                    File.AppendAllText(outFile, Environment.NewLine);
            }

            return outFile;
        }

        public static List<List<T>> splitList<T>(List<T> mainList, int bufferSize)
        {
            List<List<T>> result = new List<List<T>>();
            for (int i = 0; i < mainList.Count; i += bufferSize)
                result.Add(mainList.GetRange(i, Math.Min(bufferSize, mainList.Count - i)));
            return result;
        }

    }
}
