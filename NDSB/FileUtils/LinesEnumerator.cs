using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;

namespace NDSB
{
    public static class LinesEnumerator
    {
        /// <summary>
        /// Enumerates the lines of a file.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <param name="maxLines">The maximum number of lines to read.</param>
        /// <returns></returns>
        public static IEnumerable<string> YieldLinesOfFile(string path, int maxLines = Int32.MaxValue)
        {
            string line;
            int lineNumber = 0;

            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                while ((line = sr.ReadLine()) != null && lineNumber < maxLines)
                {
                    lineNumber++;
                    yield return line;
                }
            }
        }
    }
}
