using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

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
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null && lineNumber < maxLines)
            {
                lineNumber++;
                yield return line;
            }
            file.Close();
        }
    }
}
