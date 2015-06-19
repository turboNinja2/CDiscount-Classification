using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NDSB
{
    class FileTransform
    {
        public static void TextToSparseData(string inputFilePath, int maxLines)
        {
            string outputFilePath = Path.GetDirectoryName(inputFilePath) + "\\" + Path.GetFileNameWithoutExtension(inputFilePath) + "_sparse.txt";
            int currentLine = 0;
            foreach (var cd in TFIDF.Transform2(FileUtils.LineYielderBasic(inputFilePath, maxLines)))
            {
                if (currentLine > maxLines) return;
                List<string> res = cd.Select(kvp => kvp.Key + ":" + Math.Round(kvp.Value, 3)).ToList();
                string toWrite = String.Join(" ", res);
                File.AppendAllText(outputFilePath, toWrite + Environment.NewLine);
                currentLine++;
            }
        }

        public static void ExtractLabels(string inputFilePath, int maxLines)
        {
            string outputFilePath = Path.GetDirectoryName(inputFilePath) + "\\" + Path.GetFileNameWithoutExtension(inputFilePath) + "_labels.txt";
            int currentLine = 0;
            string toWrite = "";
            foreach (string line in FileUtils.LineYielderBasic(inputFilePath, 1000000))
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
            foreach (string line in FileUtils.LineYielderBasic(inputFilePath))
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

        public static Dictionary<string, double>[] ImportPoints(string inputFilePath, bool header = true)
        {
            List<Dictionary<string, double>> points = new List<Dictionary<string, double>>(1000000);

            foreach (string line in FileUtils.LineYielderBasic(inputFilePath))
                points.Add(SparsePointFromString(line));
            if (header)
                points.RemoveAt(0);
            return points.ToArray();
        }

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
