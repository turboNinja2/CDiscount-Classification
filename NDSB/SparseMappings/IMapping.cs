using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDSB.SparseMappings
{
    /// <summary>
    /// Maps an object to another object of the same type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMapping<T>
    {
        T Map(T inputElement);
    }
}
