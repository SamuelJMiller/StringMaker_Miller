using System;

// Samuel Miller
// IT113
// NOTES: none
// BEHAVIORS NOT IMPLIMENTED AND WHY: none

namespace StringMaker_Miller
{
    class Program
    {
        static void wr(string s)
        {
            Console.WriteLine(s);
        }

        static void Main(string[] args)
        {
            StringManager sm = new StringManager();

            wr("'Sunbeam Tiger' reversed without case location preservation: " + sm.reverse("Sunbeam Tiger"));

            wr("'Sunbeam Tiger' reversed with case location preservation: " + sm.reverse("Sunbeam Tiger", true));
        }
    }
}
