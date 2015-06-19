
// NDSB.Stats
extern "C" __global__  void GetDistanceToClasses(int n, int p,  float* trainLines, int trainLinesLen0, int trainLinesLen1,  float* currentLine, int currentLineLen0,  float* result, int resultLen0);

// NDSB.Stats
extern "C" __global__  void GetDistanceToClasses(int n, int p,  float* trainLines, int trainLinesLen0, int trainLinesLen1,  float* currentLine, int currentLineLen0,  float* result, int resultLen0)
{
	int x = threadIdx.x;
	int num = blockIdx.x * blockDim.x + x;
	if (num > n)
	{
		return;
	}
	float num2 = 0.0f;
	for (int i = 0; i < p; i++)
	{
		float num3 = trainLines[(num) * trainLinesLen1 + ( i)];
		float num4 = currentLine[(i)];
		num2 += (num3 - num4) * (num3 - num4);
	}
	result[(num)] = num2;
}
