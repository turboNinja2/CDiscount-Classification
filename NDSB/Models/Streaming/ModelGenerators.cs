using System.Collections.Generic;
using NDSB.Models.Streaming.Phis;

namespace DataScienceECom.Models
{
    public static class ModelGenerators
    {

        public static IEnumerable<IStreamingModel<int,int>> Entropia6()
        {
            yield return new GMEntropia(0.5, 4, 6, 500000);
        }

        public static IEnumerable<IStreamingModel<Hierarchy, int>> HEntropia()
        {
            yield return new HierarchicalSGD(0.5, 4, 8, 1000);
            yield return new HierarchicalSGD(0.5, 4, 8);
            yield return new HierarchicalSGD(0.7, 4, 8);
            yield return new HierarchicalSGD(0.9, 4, 8);
            yield return new HierarchicalSGD(0.5, 4, 6);
            yield return new HierarchicalSGD(0.7, 4, 6);
            yield return new HierarchicalSGD(0.9, 4, 6);
        }

    }
}
