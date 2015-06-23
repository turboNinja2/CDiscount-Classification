namespace NDSB
{
    public static class DSCdiscountUtils
    {
        public static string GetLabel(string input)
        {
            return input.Split(';')[3];
        }
    }
}
