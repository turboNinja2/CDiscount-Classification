using System.Collections.Generic;
using NDSB.Models.Streaming.Phis;

namespace DataScienceECom.Models
{
    public static class ModelGenerators
    {
        public static IEnumerable<IStreamingModel<int,int>> Entropia6()
        {
            yield return new GMEntropia(0.5, 4, 6, 500000);
            yield return new GMEntropia(0.6, 4, 6, 500000);
            yield return new GMEntropia(0.7, 4, 6, 500000);
            yield return new GMEntropia(0.5, 4, 7, 500000);
            yield return new GMEntropia(0.6, 4, 7, 500000);
            yield return new GMEntropia(0.7, 4, 7, 500000);
        }

        public static IEnumerable<IStreamingModel<Hierarchy, int>> HEntropia()
        {
            yield return new HierarchicalSGD(0.5, 4, 6);
        }
    }
}
