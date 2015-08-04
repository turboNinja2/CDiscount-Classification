using System;

namespace DataScienceECom.Phis
{
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
