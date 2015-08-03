namespace DataScienceECom
{
    public interface IStreamingModel
    {
        void Update(int y, string[] predictors);

        int Predict(string[] predictors);

        int Refresh { get; }

        void GarbageCollect();

        void ClearModel();

        string ToString();
    }
}
