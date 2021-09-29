using System;
using System.Collections.Generic;
using System.Linq;

namespace _60_Interview_Questions
{
    public partial class Program
    {
        public static int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int[] dp = new int[nums.Length + 1];
            dp[0] = 0;
            dp[1] = nums[0];

            for (int i = 2; i <= nums.Length; i++)
            {
                dp[i] = Math.Max(nums[i - 1] + dp[i - 2], dp[i - 1]);
            }

            return dp[dp.Length - 1];
        }
        // Since we can't have the first element and the last element, compare two arrays,
        // 1st array without last element, 2nd array without first element.
        // Eg. n = {4,3,6,1,9}  = Max between n1 = {4,3,6,1} and n2 = {3,6,1,9}.
        public static int RobCircular(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];

            // I could use a separate method to implement the dynamic programming on both arrays.
            int[] dp1 = new int[nums.Length];
            dp1[0] = 0;
            dp1[1] = nums[0];
            for (int i = 2; i < dp1.Length; i++)
            {
                dp1[i] = Math.Max(dp1[i - 1], nums[i - 1] + dp1[i - 2]);
            }
            int[] dp2 = new int[nums.Length];
            dp2[0] = 0;
            dp2[1] = nums[1];
            for (int i = 2; i < dp2.Length; i++)
            {
                dp2[i] = Math.Max(dp2[i - 1], nums[i] + dp2[i - 2]);
            }

            return Math.Max(dp1[dp1.Length - 1], dp2[dp2.Length - 1]);
        }
    }
}