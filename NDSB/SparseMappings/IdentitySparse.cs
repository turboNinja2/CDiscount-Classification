using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDSB.SparseMappings
{
    public class IdentitySparse : IMapping<Dictionary<string, double>>
    {
        public Dictionary<string, double> Map(Dictionary<string, double> point)
        {
            return point;
        }
    }
}
