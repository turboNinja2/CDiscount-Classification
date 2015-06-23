using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NDSB
{
    public static class DownSample
    {

        public delegate string GetLabel(string input);

        public static void Run(string inputFilePath, int maxElementsPerClass, GetLabel gl)
        {
            string outputFilePath = Path.GetDirectoryName(inputFilePath) + "\\" + Path.GetFileNameWithoutExtension(inputFilePath) + "_down_sampled" + Path.GetExtension(inputFilePath);

            Dictionary<string, int> counter = new Dictionary<string, int>();
            bool header = true;

            foreach (string line in FileUtils.LineYielderBasic(inputFilePath))
            {
                if (header)
                {
                    File.AppendAllText(outputFilePath, line + Environment.NewLine);
                    header = false;
                }

                string currentLabel = gl(line);
                if (counter.ContainsKey(currentLabel))
                    counter[currentLabel]++;
                else
                    counter.Add(currentLabel, 1);

                if(counter[currentLabel]< maxElementsPerClass)
                    File.AppendAllText(outputFilePath, line + Environment.NewLine);
            }

        }
    }
}
