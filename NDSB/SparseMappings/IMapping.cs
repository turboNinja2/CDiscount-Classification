using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDSB.SparseMappings
{
    public interface IMapping<T>
    {
        T Map(T inputElement);
    }
}
