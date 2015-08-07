using System.Collections.Generic;

namespace DataScienceECom
{
    public interface IStreamingModel<T, U>
    {
        void Update(T info, IList<string> predictors);

        U Predict(IList<string> predictors);

        int Refresh { get; }

        string Description();

        void GarbageCollect();

        void ClearModel();
    }
}
