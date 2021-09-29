using System;
using System.Collections.Generic;
using System.Linq;

namespace _60_Interview_Questions
{
    public partial class Program
    {
        // static void Main(string[] args)
        // {
        //     int[] a = { 10, 9, 2, 5, 3, 7, 101, 18 };
        //     int[] b = { 1, 2, 12, 2, 8, 4 };
        //     System.Console.WriteLine(LengthOfLIS(b));
        // }
        
        // Longest subsequence means:
        // [10, 9, 2, 5, 3, 7, 101, 18] longest subsequence = [2,5,7,101] or [2,3,7,101]. Answer = 4.
        public static int LengthOfLIS(int[] a)
        {
            if (a.Length == 0) return 0;

            int[] n = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (a[i] > a[j])
                    {
                        n[i] = Math.Max(n[i], n[j]);
                    }
                }
                n[i]++;
            }

            return n.Max();
        }

    }

}