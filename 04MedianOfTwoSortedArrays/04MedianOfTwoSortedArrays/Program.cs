using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04MedianOfTwoSortedArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double median = FindMedianSortedArrays(new int[] {1, 2, 6, 7, 8}, new int[] {3,3});
            Console.WriteLine(median);
            Console.ReadKey();
        }

        static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] sortedArray = new int[nums1.Length + nums2.Length];

            int i = 0, j = 0, k = 0;
            while (i < nums1.Length && j < nums2.Length)
            {
                int lowestNumber = nums1[i] < nums2[j] ? nums1[i++] : nums2[j++];
                sortedArray[k++] = lowestNumber;
            }

            if (i < nums1.Length)
            {
                for (; i < nums1.Length; i++)
                {
                    sortedArray[k++] = nums1[i];
                }
            }
            else
            {
                for (; j < nums2.Length; j++)
                {
                    sortedArray[k++] = nums2[j];
                }
            }

            int middleIndex = sortedArray.Length / 2;
            double median = sortedArray.Length % 2 == 0
                ? (sortedArray[middleIndex] + sortedArray[middleIndex - 1]) / 2d
                : sortedArray[middleIndex];

            return median;
        }
    }
}
