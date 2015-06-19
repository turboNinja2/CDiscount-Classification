using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NDSB
{
    public static class CrowdFlowerFormatting
    {
        public static void CleanFile(string inputFilePath, double maxVariance = double.MaxValue)
        {
            string outputFilePath = Path.GetDirectoryName(inputFilePath) + "\\" + Path.GetFileNameWithoutExtension(inputFilePath) + "_clean.csv";
            string toWrite = "";
            string currentElement = "";

            bool header = true;

            int previousIndex = -1;
            
            foreach (string line in FileUtils.LineYielderBasic(inputFilePath))
            {
                if (header)
                {
                    toWrite += line + Environment.NewLine;
                    header = false;
                    continue;
                }

                int currentIndex = 0;
                string[] splittedLine = line.Split(',');
                bool parseSucceeded = int.TryParse(splittedLine[0], out currentIndex);


                if (parseSucceeded)
                {
                    toWrite += line + Environment.NewLine;
                    currentElement = "";
                    previousIndex = currentIndex;
                }
            }

            toWrite += currentElement;

            File.AppendAllText(outputFilePath, toWrite);
        }


        public static void ExtractLabels(string inputFilePath)
        {
            string outputFilePath = Path.GetDirectoryName(inputFilePath) + "\\" + Path.GetFileNameWithoutExtension(inputFilePath) + "_clean.csv";
            string toWrite = "";

            bool header = true;


            foreach (string line in FileUtils.LineYielderBasic(inputFilePath))
            {
                if (header)
                {
                    toWrite += line + Environment.NewLine;
                    header = false;
                    continue;
                }

                string[] splittedLine = line.Split(',');

                toWrite += splittedLine[splittedLine.Length - 2].ToString();

            }


            File.AppendAllText(outputFilePath, toWrite);
        }

    }
}
