using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;


namespace NDSB
{
    public static class FileUtils
    {
        public static IEnumerable<float[]> LineYielder(string path)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                string[] res = line.Split(Globals.Separator);
                int n = res.Length;
                float[] currentLine = new float[n];
                for (int i = 0; i < n; i++)
                    currentLine[i] = float.Parse(res[i], CultureInfo.InvariantCulture);
                yield return currentLine;
            }
            file.Close();
        }

        public static IEnumerable<string> LineYielderBasic(string path, int maxLines = Int32.MaxValue)
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

        public static int CountLines(string path)
        {
            string line;
            int ctr = 0;
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null) ctr++;
            file.Close();
            return ctr;
        }

        public static int CountCols(string path)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            line = file.ReadLine();
            string[] res = line.Split(Globals.Separator);
            int nCols = res.Length;
            file.Close();
            return nCols;
        }

        
    }
}
