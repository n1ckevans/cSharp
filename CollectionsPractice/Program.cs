using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] numArray = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            string [] strArray = {"Tim", "Martin", "Nikki", "Sara"};
            bool [] boolArray = {true, false, true, false, true, false, true, false, true, false};

            List<string> flavors = new List<string>();
            flavors.Add("Chocolate");
            flavors.Add("Vanilla");
            flavors.Add("Rocky Road");
            flavors.Add("Neopolitan");
            flavors.Add("Strawberry");
            Console.WriteLine(flavors.Count);
            Console.WriteLine(flavors[2]);
            flavors.Remove(flavors[2]);
            Console.WriteLine(flavors[2]);
            Console.WriteLine(flavors.Count);

            Dictionary<string,string> user = new Dictionary<string,string>();
            user.Add(strArray[0], flavors[0]);
            user.Add(strArray[1], flavors[1]);
            user.Add(strArray[2], flavors[2]);
            user.Add(strArray[3], flavors[3]);

            foreach (KeyValuePair<string,string> entry in user)
            {
            Console.WriteLine(entry.Key + ": " + entry.Value);
            }

        }
    }
}
