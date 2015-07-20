namespace NDSB
{
    public interface IModelClassification<T>
    {
        void Train(int[] labels, T[] points);

        int Predict(T point);
    }
}
