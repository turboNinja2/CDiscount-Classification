using System.Collections.Generic;
using System.Linq;

namespace NDSB.Models.SparseModels
{
    public static class DataIndexer
    {
        /// <summary>
        /// Returns an inverted dictionnary of the keys.
        /// </summary>
        /// <param name="sample"></param>
        public static Dictionary<T, List<int>> InverseKeys<T>(Dictionary<T, double>[] sample, double minValue, int preAlloc = 1000000)
        {
            Dictionary<T, List<int>> invertedIndexes = new Dictionary<T, List<int>>(preAlloc);
            for (int i = 0; i < sample.Length; i++)
            {
                Dictionary<T, double> sparsePoint = sample[i];
                foreach (KeyValuePair<T, double> kvp in sparsePoint)
                {
                    T currentKey = kvp.Key;
                    if (kvp.Value < minValue) continue;
                    if (invertedIndexes.ContainsKey(currentKey))
                        invertedIndexes[currentKey].Add(i);
                    else
                    {
                        invertedIndexes.Add(currentKey, new List<int>(100));
                        invertedIndexes[currentKey].Add(i);
                    }
                }
            }
            return invertedIndexes;
        }

        public static Dictionary<T, List<int>> InverseKeysAndSort<T>(Dictionary<T, double>[] sample, double minValue, int preAlloc = 1000000)
        {
            Dictionary<T, List<int>> invertedIndexes = InverseKeys<T>(sample, minValue, preAlloc);
            for (int i = 0; i < invertedIndexes.Count; i++)
                invertedIndexes[invertedIndexes.Keys.ElementAt(i)].Sort();
            return invertedIndexes;
        }

        public static IEnumerable<T> IntersectSorted<T>(IEnumerable<T> sequence1, IEnumerable<T> sequence2, IComparer<T> comparer)
        {
            using (var cursor1 = sequence1.GetEnumerator())
            using (var cursor2 = sequence2.GetEnumerator())
            {
                if (!cursor1.MoveNext() || !cursor2.MoveNext())
                {
                    yield break;
                }
                var value1 = cursor1.Current;
                var value2 = cursor2.Current;

                while (true)
                {
                    int comparison = comparer.Compare(value1, value2);
                    if (comparison < 0)
                    {
                        if (!cursor1.MoveNext())
                        {
                            yield break;
                        }
                        value1 = cursor1.Current;
                    }
                    else if (comparison > 0)
                    {
                        if (!cursor2.MoveNext())
                        {
                            yield break;
                        }
                        value2 = cursor2.Current;
                    }
                    else
                    {
                        yield return value1;
                        if (!cursor1.MoveNext() || !cursor2.MoveNext())
                        {
                            yield break;
                        }
                        value1 = cursor1.Current;
                        value2 = cursor2.Current;
                    }
                }
            }
        }

   
    }
}
