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

        char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        string[] num_words = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

        Stack<char> stack = new Stack<char>();
        Queue<int> queue = new Queue<int>();

        public string reverse(string s)
        {
            current_input = s;

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
            current_input = s;

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
            current_input = s;

            return (s == reverse(s)); // *Applause sounds*
        }

        public override string ToString()
        {
            int ascii_sum = 0;

            if (current_input == string.Empty)
            {
                return "Negative One";
            } else
            {
                char[] array = current_input.ToCharArray();

                for ( int i = 0; i < array.Length; ++i )
                {
                    ascii_sum += array[i];
                }

                return vocalize_int(ascii_sum);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is string)
            {
                return ((string)obj == current_input);
            } else
            {
                return false;
            }
        }

        private string vocalize_int(int num)
        {
            string final = string.Empty;
            string num_string = num.ToString();

            char[] array = num_string.ToCharArray();

            for ( int i = 0; i < array.Length; ++i )
            {
                final += num_words[Array.IndexOf(digits, array[i])] + ' ';
            }

            return final;
        }
    }
}
