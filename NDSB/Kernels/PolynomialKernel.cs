using System;
using System.Collections.Generic;
using NDSB.SparseMethods;
using NDSB.Kernels;

namespace NDSB.SparseSpaces
{
    public class PoynomialKernel : ISparseKernel
    {
        private int _degree;

        private static double poly(double res, int degree)
        {
            return Math.Pow(1 + res, degree);
        }

        public PoynomialKernel(int degree)
        {
            _degree = degree;
        }

        public double Dot(Dictionary<string, double> sp1, Dictionary<string, double> sp2)
        {
            return poly(HilbertSpace.DotProduct(sp1, sp2), _degree);
        }

        public double Dot(Dictionary<string, double> sp1)
        {
            return poly(HilbertSpace.DotProduct(sp1, sp1), _degree);
        }
    }
}
