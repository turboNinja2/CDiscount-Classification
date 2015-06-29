using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDSB.SparseMappings
{
    public class IdentitySparse<T> : IMapping<T>
    {
        public T Map(T point)
        {
            return point;
        }
    }
}
