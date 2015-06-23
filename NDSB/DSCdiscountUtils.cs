using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDSB
{
    public static class DSCdiscountUtils
    {
        public static string GetLabel(string input)
        {
            return input.Split(';')[3];
        }

    }
}
