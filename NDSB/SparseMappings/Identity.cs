namespace NDSB.SparseMappings
{
    public class Identity<T> : IMapping<T>
    {
        public T Map(T point)
        {
            return point;
        }
    }
}
