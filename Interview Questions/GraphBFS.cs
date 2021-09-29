using System;
using System.Collections.Generic;
using System.Linq;

namespace _60_Interview_Questions
{
    // solution NOT accepted. Times Out
    public partial class Program
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            List<int> list = new List<int>();
            LadderLength(beginWord, endWord, wordList, new HashSet<string>(), list, 0);
            foreach (var item in list)
            {
                System.Console.Write(item + " ");
            }
            return list.Any() ? list.Min() + 1 : 0;

        }
        public void LadderLength(string beginWord, string endWord, IList<string> wordList, HashSet<string> h, List<int> list, int count)
        {
            System.Console.WriteLine(beginWord);
            // might need to clear hashset.
            if (beginWord == endWord)
            {
                System.Console.WriteLine($"{beginWord} == {endWord} : Count = {count}");
                list.Add(count);
                return;
            }
            // if difference between beginWord and endWord is one.
            foreach (var word in wordList)
            {
                int difference = 0;

                if (!h.Contains(word))
                {
                    for (int i = 0; i < beginWord.Length; i++)
                    {
                        if (beginWord[i] != word[i])
                        {
                            difference++;
                        }
                    }
                    if (difference == 1)
                    {
                        h.Add(word);
                        LadderLength(word, endWord, wordList, h, list, count + 1);
                        h.Remove(word);
                        System.Console.WriteLine(beginWord + " " + word);
                    }
                }
            }
            return;
        }
    }
}