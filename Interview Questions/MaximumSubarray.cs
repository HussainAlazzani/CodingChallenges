using System;
using System.Collections.Generic;
using System.Linq;

namespace _60_Interview_Questions
{
    public partial class Program
    {
        public static int MaxSubArray(int[] a)
        {
            int[] n = new int[a.Length];
            n[0] = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] + n[i - 1] >= a[i])
                {
                    n[i] = a[i] + n[i - 1];
                }
                else
                {
                    n[i] = a[i];
                }
            }
            return n.Max();
        }
    }
}