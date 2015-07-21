using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NDSB.FileUtils
{
    public static class Splitter
    {
        public static void Split(string file, int linesToSplit, int bufferSize = 1000000)
        {
            int numberOfLines = 0;
            bool header = true;

            string outFile = Path.GetDirectoryName(file) + "\\" +
                Path.GetFileNameWithoutExtension(file) + "_tr" +
                Path.GetExtension(file);

            string outFileVal = Path.GetDirectoryName(file) + "\\" +
                Path.GetFileNameWithoutExtension(file) + "_val" +
                Path.GetExtension(file);

            List<string> buffer = new List<string>();

            foreach (string line in LinesEnumerator.YieldLinesOfFile(file))
            {
                if (header)
                {
                    File.WriteAllText(outFile, line + Environment.NewLine);
                    File.WriteAllText(outFileVal, line + Environment.NewLine);
                    header = false;
                    continue;
                }

                numberOfLines++;
                buffer.Add(line);

                if (numberOfLines % bufferSize == 0 || numberOfLines == linesToSplit)
                {
                    File.AppendAllLines(outFile, buffer);
                    buffer = new List<string>();
                }
            }
            File.AppendAllLines(outFileVal, buffer);
        }

    }
}
