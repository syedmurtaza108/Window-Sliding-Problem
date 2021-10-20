using System;
using System.Collections.Generic;

namespace Window_Sliding_Problem
{
    class Program
    {
        static Dictionary<char, int> list = new Dictionary<char, int>();
        static void Main(string[] args)
        {
            //Console.WriteLine(MaxSumSubArray(new int[] { 4, 2, 1, 7, 8, 1, 2, 8, 1, 0 }, 3));
            //Console.WriteLine(SmallestSubArrayGivenSum(new int[] { 4, 2, 2, 7, 8, 1, 2, 8, 1, 0 }, 8));
            //Console.WriteLine(SmallestSubArrayGivenSum(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }, 11));
            Console.WriteLine(LongestSubStringGivenDistinctCharacter("aabacbebebe", 3));
            //AAAHHIBC
        }

        static int MaxSumSubArray(int[] array, int k)
        {
            int currentSum = 0;
            int maxSum = -1;
            for (int i = 0; i < array.Length; i++)
            {
                currentSum += array[i];
                if (i >= k - 1)
                {
                    maxSum = Math.Max(currentSum, maxSum);
                    currentSum -= array[i - k + 1];
                }
            }
            return maxSum;
        }

        static int SmallestSubArrayGivenSum(int[] array, int targetSum)
        {
            int currentSum = 0;
            int startIndex = 0, size = int.MaxValue;
            for (int i = 0; i < array.Length;)
            {
                currentSum += array[i];
                if (currentSum >= targetSum)
                {
                    size = Math.Min(i - startIndex + 1, size);
                    currentSum -= array[startIndex];
                    currentSum -= array[i];
                    startIndex++;
                    continue;
                }
                i++;
            }
            return size == int.MaxValue ? 0 : size;
        }

        static int LongestSubStringGivenDistinctCharacter(string s, int k)
        {
            for (int i = 0; i < s.Length + 1; )
            {
                if (list.Count == k + 1)
                {
                    if (list.GetValueOrDefault(s[i], 1) == 1) list.RemoveAt(0);
                    else
                    {
                        list.Insert(0, KeyValuePair.Create(s[0], list[0].Value - 1));
                        list.RemoveAt(1);
                    }
                    continue;
                }

                if(i < s.Length)
                {
                    bool added = false;
                    list.get
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j].Key == s[i])
                        {
                            added = true;
                            list.Insert(j, KeyValuePair.Create(s[i], list[j].Value + 1));
                            list.RemoveAt(j + 1);
                        }
                    }

                    if (!added) list.Add(KeyValuePair.Create(s[i], 1));
                }
                i++;
            }

            int totalLenght = 0;
            for (int i = 0; i < list.Count; i++)
            {
                totalLenght += list[i].Value;
            }
            return totalLenght;
        }
    }
}
