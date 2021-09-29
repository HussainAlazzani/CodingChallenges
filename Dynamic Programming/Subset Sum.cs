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
            int[] set = { 1, 2, 5, 9, 4 };
            int w = 18;
            List<List<int>> subsets = FindSubsets(set, w);
            foreach (var items in subsets)
            {
                foreach (var item in items)
                {
                    System.Console.Write(item + " ");
                }
                System.Console.WriteLine();
            }

        }
        private static List<List<int>> FindSubsets(int[] set, int w)
        {
            List<List<int>> subsets = new List<List<int>>();
            FindSubsets(set, w, subsets, new List<int>(), -1);
            return subsets;
        }
        // Recursive approach
        private static void FindSubsets(int[] set, int w, List<List<int>> subsets, List<int> sub, int index)
        {
            if (w == 0)
            {
                List<int> subNew = new List<int>(sub);
                subsets.Add(subNew);
                return;
            }
            if (index >= set.Length - 1 || w < 0) return;

            // Go left: Don't add an element from the set.
            FindSubsets(set, w, subsets, sub, index + 1);
            // Go right: Add an element from the set.
            sub.Add(set[index + 1]);
            FindSubsets(set, w - set[index + 1], subsets, sub, index + 1);
            sub.Remove(set[index + 1]);
        }

    }
    // Dynamic approach
    // private static int FindSubsets(int[] coins, int amount)
    // {

    // }
}