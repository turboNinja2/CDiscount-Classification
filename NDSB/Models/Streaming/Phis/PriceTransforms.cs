using System;

namespace DataScienceECom.Phis
{
    public delegate int PriceTransform(double price);

    public static class PriceTransforms
    {
        public static int LogPrice(double price)
        {
            if (price > 0)
                return Convert.ToInt32(Math.Log(price));
            else
                return -1;
        }
    }
}
