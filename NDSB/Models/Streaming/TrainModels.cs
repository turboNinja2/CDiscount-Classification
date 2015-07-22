using System;
using System.Collections.Generic;
using DataScienceECom.Phis;
using NDSB;

namespace DataScienceECom
{
    public class TrainModels
    {
        public static void TrainStreamingModel(IStreamingModel model, Phi phi, string file)
        {
            int currentLine = 0;
            string header = "";

            foreach (string line in LinesEnumerator.YieldLines(file))
            {
                currentLine++;
                if (currentLine == 1)
                {
                    header = line;
                    continue;
                }

                if (currentLine % model.Refresh == 0)
                    model.GarbageCollect();

                Tuple<int, List<string>> received = phi(line, header);
                model.Update(received.Item1, received.Item2.ToArray());

            }
            model.GarbageCollect();
        }

        public static List<int> Predict(IStreamingModel model, Phi phi, string testFile)
        {
            int currentLine = 0;
            string header = "";
            List<int> result = new List<int>();
            foreach (string line in LinesEnumerator.YieldLines(testFile))
            {
                currentLine++;
                if (currentLine == 1)
                {
                    header = line;
                    continue;
                }

                Tuple<int, List<string>> received = phi(line, header);
                int predicted = model.Predict(received.Item2.ToArray());
                result.Add(predicted);
            }
            return result;
        }

        public static Tuple<List<int>, double> Validate(IStreamingModel model, Phi phi, string testFile)
        {
            int currentLine = 0;
            string header = "";
            List<int> result = new List<int>();

            double error = 0;

            foreach (string line in LinesEnumerator.YieldLines(testFile))
            {
                currentLine++;
                if (currentLine == 1)
                {
                    header = line;
                    continue;
                }

                Tuple<int, List<string>> received = phi(line, header);
                int predicted = model.Predict(received.Item2.ToArray());
                result.Add(predicted);

                if (predicted != received.Item1)
                    error++;
            }

            return new Tuple<List<int>, double>(result, error / currentLine);
        }
    }
}
