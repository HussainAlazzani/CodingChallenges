using System;
using System.Collections.Generic;

namespace _60_Interview_Questions
{
    public partial class Program
    {
        public static bool isValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '{' || s[i] == '[')
                {
                    stack.Push(s[i]);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    char prev = stack.Peek();
                    if (prev == '(' && s[i] == ')')
                    {
                        stack.Pop();
                    }
                    else if (prev == '{' && s[i] == '}')
                    {
                        stack.Pop();
                    }
                    else if (prev == '[' && s[i] == ']')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (stack.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}