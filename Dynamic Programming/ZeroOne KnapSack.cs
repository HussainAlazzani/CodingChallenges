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
            int[] w = { 2, 3, 3, 4 };
            int[] v = { 1, 2, 5, 9 };
            int index = w.Length;

            int c = 7;
            System.Console.WriteLine(KnapSack(w, v, c, -1));
            System.Console.WriteLine(KnapSackDP(w, v, c));

        }
        // Dynamic programming approach.
        static int KnapSackDP(int[] wt, int[] v, int c)
        {
            if (c == 0 || wt.Length == 0) return 0;

            int i = 0;
            int j = 0;
            int[, ] t = new int[wt.Length + 1, c + 1];

            for (i = 0; i < t.GetLength(0); i++)
            {
                for (j = 0; j < t.GetLength(1); j++)
                {
                    if (i == 0 || j == 0)
                    {
                        t[i, j] = 0;
                        System.Console.Write(t[i, j] + " ");
                    }
                    else if (wt[i - 1] > j)
                    {
                        t[i, j] = t[i - 1, j];
                        System.Console.Write(t[i, j] + " ");
                    }
                    else
                    {
                        t[i, j] = Math.Max(t[i - 1, j], v[i - 1] + t[i - 1, j - wt[i - 1]]);
                        System.Console.Write(t[i, j] + " ");
                    }
                }
                System.Console.WriteLine();
            }
            return t[i - 1, j - 1];

        }
        // Recursive approach.
        static int KnapSack(int[] wt, int[] v, int c, int index)
        {
            if (index == wt.Length - 1) return 0;

            int left = KnapSack(wt, v, c, index + 1);
            int right;

            if (c - wt[index + 1] < 0)
            {
                right = 0;
            }
            else
            {
                right = KnapSack(wt, v, c - wt[index + 1], index + 1) + v[index + 1];
            }
            return Math.Max(left, right);
        }
       
    }
}