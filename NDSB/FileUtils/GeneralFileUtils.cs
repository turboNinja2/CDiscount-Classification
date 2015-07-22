namespace NDSB.FileUtils
{
    public static class GeneralFileUtils
    {
        public static int NumberOfLines(string file)
        {
            int numberOfLines = 0;
            foreach (string line in LinesEnumerator.YieldLines(file))
                numberOfLines++;
            return numberOfLines;
        }
    }
}
