using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDSB.Kernels;

namespace NDSB.SparseSpaces
{

    public static class RKHilbertSpace
    {
        public static double Distance(ISparseKernel kernel, Dictionary<string, double> p1, Dictionary<string, double> p2)
        {
            return (kernel.Dot(p1, p1) - 2 * kernel.Dot(p1, p2) + kernel.Dot(p2, p2));
        }
    }
}
