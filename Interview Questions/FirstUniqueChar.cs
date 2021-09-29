using System;
using System.Collections.Generic;
using System.Linq;

namespace _60_Interview_Questions
{
    public partial class Program
    {
        // It's better to create your own hashtable, i.e. array of 26 letters.
        public static int FirstUniqChar(string s)
        {
            Dictionary<char, int> d = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!d.ContainsKey(s[i]))
                {
                    d.Add(s[i], 1);
                }
                else
                {
                    d[s[i]]++;
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (d[s[i]] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}