using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMaker_Miller
{
    class StringManager
    {
        string current_input = string.Empty;

        Stack<char> stack = new Stack<char>();
        Queue<int> queue = new Queue<int>();

        public string reverse(string s)
        {
            string final = string.Empty;

            char[] array = s.ToCharArray();

            for ( int i = 0; i < s.Length; ++i )
            {
                stack.Push(array[i]);
            }
            for ( int i = 0; i < array.Length; ++i )
            {
                final += stack.Pop();
            }

            return final;
        }

        public string reverse(string s, bool preserve_case)
        {
            if (preserve_case == true)
            {
                string final = string.Empty;

                char[] array = s.ToCharArray();

                for (int i = 0; i < array.Length; ++i)
                {
                    if (char.IsUpper(array[i]))
                    {
                        queue.Enqueue(i); // Store index of capitals
                    }
                    stack.Push(char.ToLower(array[i]));
                }
                for (int i = 0; i < array.Length; ++i)
                {
                    if (queue.Count > 0) // If queue has items
                    {
                        if ((stack.Peek() != ' ') && (queue.Peek() == i)) // Must peek to not remove items
                        {
                            final += char.ToUpper(stack.Pop());
                            queue.Dequeue();
                        }
                        else
                        {
                            final += stack.Pop();
                        }
                    }
                    else
                    {
                        final += stack.Pop();
                    }
                }

                return final;
            } else
            {
                return reverse(s); // If false, return regular funtion call
            }
        }

        public bool symmetric(string s)
        {
            return true;
        }

        public override string ToString()
        {
            return string.Empty;
        }

        public override bool Equals(object obj)
        {
            return true;
        }
    }
}
