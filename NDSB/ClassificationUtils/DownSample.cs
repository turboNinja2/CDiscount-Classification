using System;
using System.Collections.Generic;
using System.IO;

namespace NDSB
{
    public static class DownSample
    {
        public delegate string GetLabel(string input);

        public static void Split(string inputFilePath, int maxElementsPerClass, GetLabel gl)
        {
            string downSampledFilePath = Path.GetDirectoryName(inputFilePath) + "\\" + Path.GetFileNameWithoutExtension(inputFilePath) + "_down_sampled" + Path.GetExtension(inputFilePath);

            Random rnd = new Random(1);

            Dictionary<string, int> counter = new Dictionary<string, int>();
            bool header = true;

            List<string> downSampled = new List<string>();

            foreach (string line in LinesEnumerator.YieldLinesOfFile(inputFilePath))
            {
                if (header)
                {
                    downSampled.Add(line);
                    header = false;
                    continue;
                }
                string currentLabel = gl(line);
                if (counter.ContainsKey(currentLabel))
                    counter[currentLabel]++;
                else
                    counter.Add(currentLabel, 1);

                if(counter[currentLabel]< maxElementsPerClass)
                    downSampled.Add(line);
                    
            }
            File.WriteAllLines(downSampledFilePath, downSampled);
        }
    }
}
