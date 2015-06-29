using System.Collections.Generic;

namespace NDSB.Kernels
{
    interface ISparseKernel
    {
        double Dot(Dictionary<string, double> sp1, Dictionary<string, double> sp2);
    }
}
