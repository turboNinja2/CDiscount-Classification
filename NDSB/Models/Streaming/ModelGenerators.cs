using System.Collections.Generic;

namespace DataScienceECom.Models
{
    public static class ModelGenerators
    {

        public static IEnumerable<IStreamingModel<int,int>> Entropia5()
        {
            yield return new GMEntropia(0.5, 4, 6);
        }

        public static IEnumerable<IStreamingModel<int,int>> Entropia6()
        {
            yield return new GMEntropia(0.5, 4, 6, 500000);
        }


    }
}
