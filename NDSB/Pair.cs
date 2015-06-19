using System;

namespace NDSB
{
    /// <summary>
    ///  Implements a templates for a Pair class.
    /// </summary>
    /// <typeparam name="T">Type of the first element of the pair</typeparam>
    /// <typeparam name="U">Type of the second element of the pair</typeparam>
    public sealed class Pair<T, U> : IEquatable<Pair<T, U>>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }

        public bool Equals(Pair<T, U> other)
        {
            return First.Equals(other.First) && Second.Equals(other.Second);
        }
    }
}
