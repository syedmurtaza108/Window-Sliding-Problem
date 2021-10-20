using System;
using System.Collections.Generic;

namespace Window_Sliding_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(MaxSumSubArray(new int[] { 4, 2, 1, 7, 8, 1, 2, 8, 1, 0 }, 3));
            //Console.WriteLine(SmallestSubArrayGivenSum(new int[] { 4, 2, 2, 7, 8, 1, 2, 8, 1, 0 }, 8));
            //Console.WriteLine(SmallestSubArrayGivenSum(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }, 11));
            Console.WriteLine(LongestSubStringGivenDistinctCharacter("aabacbebebe", 3));
            Console.WriteLine(LongestSubStringGivenDistinctCharacter("aaaa", 3));
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

            int max = -1;
            Dictionary<char, int> list = new Dictionary<char, int>();
            int start = 0;

            for (int i = 0; i < s.Length; i++)
            {
                list[s[i]] = list.GetValueOrDefault(s[i], 0) + 1;

                while (list.Count > k)
                {
                    char leftChar = s[start];

                    list[leftChar] = list.GetValueOrDefault(leftChar) - 1;
                    if (list.GetValueOrDefault(leftChar) == 0)
                    {
                        list.Remove(leftChar);
                    }

                    start++;                
                }

                if (list.Count == k)
                {
                    max = Math.Max(max, i - start + 1);
                }
            }

            return max;
        }
    }
}