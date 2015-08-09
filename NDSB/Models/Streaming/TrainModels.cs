using System;
using System.Collections.Generic;
using DataScienceECom.Phis;
using NDSB;

namespace DataScienceECom
{
    public class TrainModels
    {
        public static void TrainStreamingModel<T, U>(IStreamingModel<T, U> model, Phi<T> phi, string file)
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

                Tuple<T, List<string>> received = phi(line, header);
                model.Update(received.Item1, received.Item2);
            }
            model.GarbageCollect();
        }

        public static List<U> Predict<T, U>(IStreamingModel<T, U> model, Phi<T> phi, string testFile)
        {
            int currentLine = 0;
            string header = "";
            List<U> result = new List<U>();
            foreach (string line in LinesEnumerator.YieldLines(testFile))
            {
                currentLine++;
                if (currentLine == 1)
                {
                    header = line;
                    continue;
                }

                Tuple<T, List<string>> received = phi(line, header);
                U predicted = model.Predict(received.Item2);
                result.Add(predicted);
            }
            return result;
        }


    }
}
