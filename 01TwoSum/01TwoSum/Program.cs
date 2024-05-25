using System;

// https://leetcode.com/problems/two-sum/

namespace _01TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] caseOne = TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            int[] caseTwo = TwoSum(new int[] { 3, 2, 4 }, 6);
            int[] caseThree = TwoSum(new int[] { 3, 3 }, 6);

            PrintArray(caseOne);
            PrintArray(caseTwo);
            PrintArray(caseThree);

            Console.ReadKey();
        }

        static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { };
        }

        static void PrintArray(int[] array)
        {
            string stringifiedArray = String.Join(",", array);
            Console.WriteLine($"[{stringifiedArray}]");
        }
    }
}
