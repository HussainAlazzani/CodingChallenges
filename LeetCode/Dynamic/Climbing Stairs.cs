using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpPractice
{
    public class Program
    {
        static void Main()
        {
            int n = 3;
            System.Console.WriteLine(ClimbStairsR(n));
            System.Console.WriteLine(ClimbStairsM(n));
            System.Console.WriteLine(ClimbStairsDP(n));
        }
		// Dynamic programming approach.
        public static int ClimbStairsDP(int n)
        {
            if(n<=0) return 0;
            if(n==1) return 1;
            if(n==2) return 2;

            int a = 3;
            int b = 2;
            int c = 1;

            for (int i = 3; i < n; i++)
            {
                c = b;
                b = a;
                a = b + c;
            }
            return a;
        }
		// Memoization approach.
        public static int ClimbStairsM(int n)
        {
            int[] memo = new int[n + 1];
            return ClimbStairsM(n, memo);
        }
        public static int ClimbStairsM(int n, int[] memo)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;

            if (memo[n] == 0)
            {
                memo[n] = ClimbStairsM(n - 2, memo) + ClimbStairsM(n - 1, memo);
            }

            return memo[n];
        }
		// Recursive approach.
        public static int ClimbStairsR(int n)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;

            return ClimbStairsR(n - 2) + ClimbStairsR(n - 1);
        }

    }
}