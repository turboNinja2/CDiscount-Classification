using System;
using System.Collections.Generic;

namespace NDSB
{
    using Point = Dictionary<string, double>;

    public static class CSRHelper
    {
        /// <summary>
        /// Imports a complete .csr file to a Dictionary<string, double>[]
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public static Point[] ImportPoints(string inputFilePath, bool header = true, int prealloc = 1000000)
        {
            List<Dictionary<string, double>> points = new List<Dictionary<string, double>>(prealloc);
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
        public static Point SparsePointFromString(string current)
        {
            Point sparseRepresentation = new Dictionary<string, double>(20);
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
