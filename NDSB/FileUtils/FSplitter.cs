using System;
using System.Collections.Generic;
using System.IO;

namespace NDSB.FileUtils
{
    public static class FSplitter
    {
        public static void Split(string file, int linesToSplit, int bufferSize = 1000000)
        {
            int numberOfLines = 0;
            bool header = true;

            string trainFile = Path.GetDirectoryName(file) + "\\" +
                Path.GetFileNameWithoutExtension(file) + "_tr" +
                Path.GetExtension(file);

            string validationFile = Path.GetDirectoryName(file) + "\\" +
                Path.GetFileNameWithoutExtension(file) + "_val" +
                Path.GetExtension(file);

            List<string> buffer = new List<string>();

            foreach (string line in LinesEnumerator.YieldLines(file))
            {
                if (header)
                {
                    File.WriteAllText(trainFile, line + Environment.NewLine);
                    File.WriteAllText(validationFile, line + Environment.NewLine);
                    header = false;
                    continue;
                }

                numberOfLines++;
                buffer.Add(line);

                if (numberOfLines % bufferSize == 0 || numberOfLines == linesToSplit)
                {
                    File.AppendAllLines(trainFile, buffer);
                    buffer = new List<string>();
                }
            }
            File.AppendAllLines(validationFile, buffer);
        }

    }
}
