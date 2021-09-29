using System;
using System.Collections.Generic;
using System.Linq;

namespace _60_Interview_Questions
{
    public partial class Program
    {
        public static int SubarraySum(int[] a, int k)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                int sum = a[i];
                if (sum == k)
                {
                    count++;
                }
                for (int j = i + 1; j < a.Length; j++)
                {
                    sum += a[j];
                    if (sum == k)
                    {
                        count++;
                    }

                }
            }
            return count;
        }
        public static int SubarraySumBrute(int[] nums, int k)
        {
            int count = 0;
            for (int start = 0; start < nums.Length; start++)
            {
                for (int end = start + 1; end <= nums.Length; end++)
                {
                    int sum = 0;
                    for (int i = start; i < end; i++)
                    {
                        sum += nums[i];
                    }
                    if (sum == k)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}