using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDSB.SparseMethods
{
    public class SparsePegasos
    {
        private Dictionary<string, double> _w;

        public double Predict(Dictionary<string,double> point)
        {
            return SparseHilbert.DotProduct(point, _w);
        }

        private void Update(Dictionary<string, double> xt, double yt, double etat, double y)
        {


        }

    }
}
