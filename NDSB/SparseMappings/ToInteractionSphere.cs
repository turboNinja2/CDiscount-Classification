using System.Collections.Generic;

namespace NDSB.SparseMappings
{
    public class ToInteractionSphere : IMapping<Dictionary<string, double>>
    {
        private static ToSphere _map1 = new ToSphere();
        private static PureInteractions _map2 = new PureInteractions(2, 20);

        public Dictionary<string, double> Map(Dictionary<string, double> input)
        {
            return _map1.Map(_map2.Map(input));
        }

        public string Description()
        {
            return "ToInteractionSphere";
        }
    }
}
