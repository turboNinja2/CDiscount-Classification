using System;
using System.Collections.Generic;
using System.Linq;

namespace NDSB.Models.SparseModels
{
    /// <summary>
    /// Implements various helpers to access data.
    /// </summary>
    public static class SmartIndexes
    {
        /// <summary>
        /// Returns an inverted dictionnary of the keys.
        /// </summary>
        /// <param name="sample"></param>
        public static Dictionary<T, int[]> InverseKeys<T>(Dictionary<T, double>[] sample, double minValue, int preAlloc1 = 1000000, int preAlloc2 = 100)
        {
            Dictionary<T, List<int>> invertedIndexes = new Dictionary<T, List<int>>(preAlloc1);
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
                        invertedIndexes.Add(currentKey, new List<int>(preAlloc2));
                        invertedIndexes[currentKey].Add(i);
                    }
                }
            }

            Dictionary<T, int[]> invertedIndexesArray = new Dictionary<T, int[]>(invertedIndexes.Count); // this dictionnary enjoys a better pre-allocation
            for (int i = 0; i < invertedIndexes.Count; i++)
                invertedIndexesArray.Add(invertedIndexes.ElementAt(i).Key, invertedIndexes.ElementAt(i).Value.ToArray());

            return invertedIndexesArray;
        }

        public static Dictionary<T, int[]> InverseKeysAndSort<T>(Dictionary<T, double>[] sample, double minValue = 0, int preAlloc1 = 1000000, int preAlloc2 = 100)
        {
            Dictionary<T, int[]> invertedIndexes = InverseKeys<T>(sample, minValue, preAlloc1, preAlloc2);
            for (int i = 0; i < invertedIndexes.Count; i++)
                Array.Sort(invertedIndexes[invertedIndexes.Keys.ElementAt(i)]);
            return invertedIndexes;
        }

        /// <summary>
        /// Returns the indexes of the inversed pairs. Note that the inverted dictionary<T,int[]> 
        /// needs to have his values sorted.
        /// </summary>
        /// <typeparam name="T">The type of the keys</typeparam>
        /// <param name="invertedIndexes"></param>
        /// <param name="minOccurences">The minimum number of occurences expected for each pair.</param>
        /// <returns></returns>
        public static Dictionary<List<T>, int[]> InversePairs<T>(Dictionary<T, int[]> invertedIndexes, int minOccurences = 0)
        {
            Dictionary<List<T>, int[]> bags = new Dictionary<List<T>, int[]>();
            foreach (KeyValuePair<T, int[]> entry1 in invertedIndexes)
                foreach (KeyValuePair<T, int[]> entry2 in invertedIndexes)
                {
                    if (entry1.Key.Equals(entry2.Key)) break;
                    if (entry2.Value.Length < minOccurences) continue;

                    int[] intersectedIndexes = IntersectSortedIntUnsafe(entry1.Value, entry2.Value);
                    if (intersectedIndexes.Length > minOccurences)
                    {
                        List<T> keys = new List<T>() { entry1.Key, entry2.Key };
                        keys.Sort();

                        bags.Add(keys, intersectedIndexes);
                    }
                }
            return bags;
        }

        /// <summary>
        /// Fast function to intersect two sorted arrays of integers.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static unsafe int[] IntersectSortedIntUnsafe(int[] source, int[] target)
        {
            var ints = new List<int>(Math.Min(source.Length, target.Length));

            fixed (int* ptSrc = source)
            {
                var maxSrcAdr = ptSrc + source.Length;

                fixed (int* ptTar = target)
                {
                    var maxTarAdr = ptTar + target.Length;

                    var currSrc = ptSrc;
                    var currTar = ptTar;

                    while (currSrc < maxSrcAdr && currTar < maxTarAdr)
                    {
                        switch ((*currSrc).CompareTo(*currTar))
                        {
                            case -1:
                                currSrc++;
                                continue;
                            case 1:
                                currTar++;
                                continue;
                            default:
                                ints.Add(*currSrc);
                                currSrc++;
                                currTar++;
                                continue;
                        }
                    }
                }
            }
            return ints.ToArray();
        }

        /// <summary>
        /// Returns the elements at the specified indexes. 
        /// </summary>
        /// <typeparam name="T">Type of the elements</typeparam>
        /// <param name="source">The array to retrieve the data from</param>
        /// <param name="indexes">The indexes to look up</param>
        /// <returns>The extraction T_indexes_i</returns>
        public static T[] GetElementsAt<T>(T[] source, int[] indexes)
        {
            T[] result = new T[indexes.Length];
            for (int i = 0; i < indexes.Length; i++)
                result[i] = source[indexes[i]];
            return result;
        }
    }
}
