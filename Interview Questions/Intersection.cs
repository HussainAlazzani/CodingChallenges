using System;
using System.Collections.Generic;
using System.Linq;

namespace _60_Interview_Questions
{
    public partial class Program
    {
        public static int[] Intersection(int[] a, int[] b)
        {
            if (a.Length < b.Length)
            {
                return IntersectionHelper(a, b);
            }
            else
            {
                return IntersectionHelper(b, a);
            }
        }
        private static int[] IntersectionHelper(int[] shortArray, int[] longArray)
        {
            List<int> list = new List<int>();
            HashSet<int> h = new HashSet<int>();
            for (int i = 0; i < shortArray.Length; i++)
            {
                h.Add(shortArray[i]);
            }
            for (int i = 0; i < longArray.Length; i++)
            {
                if (h.Contains(longArray[i]) && !list.Contains(longArray[i]))
                {
                    list.Add(longArray[i]);
                }
            }
            return list.ToArray();
        }

        public static int[] Intersection2(int[] a, int[] b)
        {
            if (a.Length == 0 || b.Length == 0)
            {
                return new int[] { };
            }
            Array.Sort(a);
            Array.Sort(b);

            if (a.Length < b.Length)
            {
                return Loop(a, b);
            }
            else
            {
                return Loop(b, a);
            }
        }
        private static int[] Loop(int[] shortArray, int[] longArray)
        {
            int index = 0;
            List<int> list = new List<int>();
            for (int i = 0; i < longArray.Length; i++)
            {
                if (longArray[i] == shortArray[index])
                {
                    if (!list.Contains(longArray[i]))
                    {
                        list.Add(longArray[i]);
                    }
                    index++;
                }
                else if (longArray[i] > shortArray[index])
                {
                    index++;
                    i--;
                }
                if (index == shortArray.Length)
                {
                    break;
                }
            }
            return list.ToArray();
        }
    }
}