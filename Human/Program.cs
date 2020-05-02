using System;
using System.Collections.Generic;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human h1 = new Human("John");
            Human h2 = new Human("Paul");
            h1.Attack(h2);
        }
    }
}
