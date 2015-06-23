using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NDSB
{
    class FileTransform
    {
        public static void TextToSparseData(string inputFilePath, int maxLines = int.MaxValue)
        {
            string outputFilePath = Path.GetDirectoryName(inputFilePath) + "\\" + Path.GetFileNameWithoutExtension(inputFilePath) + "_sparse.txt";
            int currentLine = 0;
            foreach (var cd in TFIDF.Transform2(LinesEnumerator.YieldLinesOfFile(inputFilePath, maxLines)))
            {
                if (currentLine > maxLines) return;
                List<string> res = cd.Select(kvp => kvp.Key + ":" + Math.Round(kvp.Value, 3)).ToList();
                string toWrite = String.Join(" ", res);
                File.AppendAllText(outputFilePath, toWrite + Environment.NewLine);
                currentLine++;
            }
        }

        public static void ExtractLabels(string inputFilePath, int maxLines = int.MaxValue)
        {
            string outputFilePath = Path.GetDirectoryName(inputFilePath) + "\\" + Path.GetFileNameWithoutExtension(inputFilePath) + "_labels.txt";
            int currentLine = 0;
            string toWrite = "";
            foreach (string line in LinesEnumerator.YieldLinesOfFile(inputFilePath, 1000000))
            {
                if (currentLine > maxLines) break;
                toWrite += line.Split(Globals.Separator)[3] + Environment.NewLine;
                currentLine++;
            }
            File.AppendAllText(outputFilePath, toWrite + Environment.NewLine);
        }

        public static int[] ImportLabels(string inputFilePath, bool header = true)
        {
            List<int> labels = new List<int>(1000000);
            foreach (string line in LinesEnumerator.YieldLinesOfFile(inputFilePath))
            {
                if (header)
                {
                    header = false;
                    continue;
                }
                int label = Convert.ToInt32(line);
                labels.Add(label);
            }
            return labels.ToArray();
        }

        /// <summary>
        /// Imports a complete .csr file to a Dictionary<string, double>[]
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public static Dictionary<string, double>[] ImportPoints(string inputFilePath, bool header = true)
        {
            List<Dictionary<string, double>> points = new List<Dictionary<string, double>>(1000000);
            foreach (string line in LinesEnumerator.YieldLinesOfFile(inputFilePath))
                points.Add(SparsePointFromString(line));
            if (header)
                points.RemoveAt(0);
            return points.ToArray();
        }

        /// <summary>
        /// Imports a line from a .csr file to a Dictionary<string,double>
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public static Dictionary<string, double> SparsePointFromString(string current)
        {
            Dictionary<string, double> sparseRepresentation = new Dictionary<string, double>(20);
            if (current.Length == 0) return sparseRepresentation;
            string[] splitted = current.Split(' ');

            foreach (string elt in splitted)
            {
                string[] res = elt.Split(':');
                sparseRepresentation.Add(res[0], Convert.ToDouble(res[1]));
            }
            return sparseRepresentation;
        }
    }
}
