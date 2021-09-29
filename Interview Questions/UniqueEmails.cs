using System;
using System.Collections.Generic;
using System.Linq;

namespace _60_Interview_Questions
{
    public partial class Program
    {
        public static int NumUniqueEmails(string[] emails)
        {
            HashSet<string> h = new HashSet<string>();
            for (int i = 0; i < emails.Length; i++)
            {
                string[] twoStrings = emails[i].Split('@');

                int indexOfPlus = twoStrings[0].IndexOf('+');
                string temp;
                if (indexOfPlus < 0)
                {
                    temp = twoStrings[0].Replace(".", "");
                }
                else
                {
                    temp = twoStrings[0].Remove(indexOfPlus).Replace(".", "");
                }

                string temp2 = temp + "@" + twoStrings[1];
                System.Console.WriteLine(temp2);
                if (!h.Contains(temp2))
                {
                    h.Add(temp2);
                }
            }

            return h.Count;
        }
    }
}