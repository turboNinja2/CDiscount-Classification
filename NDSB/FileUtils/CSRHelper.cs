using System;
using System.Collections.Generic;

namespace NDSB
{
    public static class CSRHelper
    {
        /// <summary>
        /// Imports a complete .csr file to a Dictionary<string, double>[]
        /// </summary>
        public static Dictionary<string, double>[] ImportPointsAsStrings(string inputFilePath, bool header = true, int prealloc = 1000000)
        {
            List<Dictionary<string, double>> points = new List<Dictionary<string, double>>(prealloc);
            foreach (string line in LinesEnumerator.YieldLines(inputFilePath))
                points.Add(SparsePointFromString(line));
            if (header)
                points.RemoveAt(0);
            return points.ToArray();
        }

        /// <summary>
        /// Imports a complete .csr file to a Dictionary<int, double>[]
        /// </summary>
        public static Dictionary<int, double>[] ImportPointsAsInts(string inputFilePath, bool header = true, int prealloc = 1000000)
        {
            List<Dictionary<int, double>> points = new List<Dictionary<int, double>>(prealloc);
            foreach (string line in LinesEnumerator.YieldLines(inputFilePath))
                points.Add(SparsePointFromStringInt(line));
            if (header)
                points.RemoveAt(0);
            return points.ToArray();
        }

        #region Private methods
        
        /// <summary>
        /// Imports a line from a .csr file to a Dictionary<string,double>
        /// </summary>
        private static Dictionary<string, double> SparsePointFromString(string current)
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

        /// <summary>
        /// Imports a line from a .csr file to a Dictionary<int,double>, using a hash.
        /// </summary>
        private static Dictionary<int, double> SparsePointFromStringInt(string current)
        {
            Dictionary<int, double> sparseRepresentation = new Dictionary<int, double>(20);
            if (current.Length == 0) return sparseRepresentation;
            string[] splitted = current.Split(' ');

            foreach (string elt in splitted)
            {
                string[] res = elt.Split(':');
                sparseRepresentation.Add(res[0].GetHashCode(), Convert.ToDouble(res[1]));
            }
            return sparseRepresentation;
        }

        #endregion
    }
}
