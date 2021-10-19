using System;

namespace Window_Sliding_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxSumSubArray(new int[] { 4, 2, 1, 7, 8, 1, 2, 8, 1, 0 }, 3));
            Console.WriteLine(SmallestSubArrayGivenSum(new int[] { 4, 2, 2, 7, 8, 1, 2, 8, 1, 0 }, 8));
            Console.WriteLine(SmallestSubArrayGivenSum(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }, 11));
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
            for (int i = 0; i < array.Length; )
            {
                currentSum += array[i];
                if(currentSum >= targetSum)
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
    }
}
