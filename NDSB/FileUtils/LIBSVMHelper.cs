using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NDSB.FileUtils
{
    public static class LIBSVMHelper
    {
        public delegate string GetLabel(string input);

        public static string Convert(string inputFilePath, GetLabel gl, bool header = true)
        {
            string outputFilePath = Path.GetDirectoryName(inputFilePath) + "\\" + Path.GetFileNameWithoutExtension(inputFilePath) + ".libsvm";
            List<string> toWrite = new List<string>();

            foreach (string line in LinesEnumerator.YieldLinesOfFile(inputFilePath))
            {
                if (header)
                {
                    header = false;
                    continue;
                }
                int[] hashes = TFIDF.Tokenize(line).Select(c => Math.Abs(c.GetHashCode())).Distinct().ToArray();
                Array.Sort(hashes);
                toWrite.Add(gl(line) + " " + String.Join(":1 ", hashes) + ":1");
            }

            File.WriteAllLines(outputFilePath, toWrite);
            return outputFilePath;
        }

    }
}
