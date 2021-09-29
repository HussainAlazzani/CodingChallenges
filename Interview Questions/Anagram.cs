using System;
using System.Collections.Generic;
using System.Linq;

namespace _60_Interview_Questions
{
    public partial class Program
    {
        public static IList<IList<string>> GroupAnagrams(string[] array)
        {
            char[][] words = new char[array.Length][];
            Dictionary<string, IList<string>> d = new Dictionary<string, IList<string>>();
            for (int i = 0; i < array.Length; i++)
            {
                words[i] = array[i].ToCharArray();
                Array.Sort(words[i]);
                String s = new String(words[i]);
                if (!d.ContainsKey(s))
                {
                    var anagrams = new List<string>();
                    anagrams.Add(array[i]);
                    d.Add(s, anagrams);
                }
                else
                {
                    var anagrams = d[s];
                    anagrams.Add(array[i]);
                }
            }

            return d.Values.ToList();
        }

    }
}