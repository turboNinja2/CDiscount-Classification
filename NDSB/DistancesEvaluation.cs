using System.Collections.Generic;
using Cudafy;
using Cudafy.Host;
using Cudafy.Atomics;
using Cudafy.Translator;
using System;
using System.Threading.Tasks;

namespace NDSB
{
    public static class Stats
    {
        private static CudafyModule _km;
        private static GPGPU _gpu;
        private static int _BLOCK_SIZE_ = 512;

        public static void Initialize()
        {
            if (_km == null)
            {
                // Translates this class to CUDA C and then compliles
                _km = CudafyTranslator.Cudafy(eArchitecture.sm_30);

                // Get the first GPU and load the module
                _gpu = CudafyHost.GetDevice(CudafyModes.Target);
                _gpu.LoadModule(_km);
            }
        }

        private static int[] LazyBubbleSort(int[] labels, float[] distances, int elementsToSort)
        {
            int[] labelsCopy = new int[labels.Length];
            float[] distancesCopy = new float[distances.Length];

            labels.CopyTo(labelsCopy, 0);
            distances.CopyTo(distancesCopy, 0);

            int n = labels.Length;
            for (int i = 0; i < elementsToSort; i++)
                for (int j = n; j > 1; j--)
                {
                    if (distancesCopy[i] > distancesCopy[i + 1])
                    {
                        float tmp = distancesCopy[i + 1];
                        distancesCopy[i + 1] = distancesCopy[i];
                        distancesCopy[i] = tmp;

                        int labelTmp = labelsCopy[i + 1];
                        labelsCopy[i + 1] = labelsCopy[i];
                        labelsCopy[i] = labelTmp;
                    }
                }
            int[] result = new int[elementsToSort];
            Array.Copy(labelsCopy, result, elementsToSort);
            return result;
        }


        public static void RunKNN(string trainPath, string testPath)
        {
            Initialize();

            Pair<float[,], int[]> pair = FileUtils.FileImporter(trainPath);
            float[,] trainData = pair.First;
            int[] labels = pair.Second;

            int nbTrainLines = trainData.GetLength(0),
                nbTrainCols = trainData.GetLength(1);

            IEnumerable<float[]> testDataEnumerator = FileUtils.LineYielder(testPath);
            float[,] gpuTrainData = _gpu.CopyToDevice(trainData);

            int[] gpuLabels = _gpu.CopyToDevice(labels);

            int ctr = 0;

            foreach (float[] element in testDataEnumerator)
            {
                float[] gpuElement = _gpu.CopyToDevice(element);
                float[] gpuResult = _gpu.CopyToDevice(new float[nbTrainLines]);

                _gpu.Launch((nbTrainLines + _BLOCK_SIZE_ + 1) / _BLOCK_SIZE_, _BLOCK_SIZE_, (Action<GThread, int, int, float[,], float[], float[]>)
                    (GetDistanceToClasses), nbTrainLines, nbTrainCols, gpuTrainData, gpuElement, gpuResult);

                _gpu.Free(gpuElement);
                float[] distancesToElement = new float[nbTrainLines];

                _gpu.CopyFromDevice(gpuResult, distancesToElement);
                _gpu.Free(gpuResult);

                ctr++;

                int[] res = LazyBubbleSort(labels, distancesToElement, 3);
                string a = res.ToString();
            }
        }

        [Cudafy]
        private static void GetDistanceToClasses(GThread thread, int n, int p, float[,] trainLines, float[] currentLine, float[] result)
        {
            int threadId = thread.threadIdx.x;
            int i = thread.blockIdx.x * thread.blockDim.x + threadId;

            if (i > n) return;

            float distance = 0;
            for (int j = 0; j < p; j++)
            {
                float t = trainLines[i, j];
                float c = currentLine[j];
                distance += (t - c) * (t - c);
            }
            result[i] = distance;
        }
    }
}
