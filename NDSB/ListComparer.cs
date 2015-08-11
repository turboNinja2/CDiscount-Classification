using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDSB
{
    public class ListComparer<T> : IEqualityComparer<List<T>>
    {
        /// <summary>
        /// Credits goes to : http://stackoverflow.com/questions/10020541/c-sharp-list-as-dictionary-key
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(List<T> x, List<T> y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode(List<T> objs)
        {
            int hashcode = 0;
            foreach (T obj in objs)
            {
                hashcode ^= obj.GetHashCode();
            }
            return hashcode;
        }
    }
}
