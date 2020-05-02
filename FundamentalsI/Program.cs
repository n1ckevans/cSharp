using System;

namespace FundamentalsI
{
  class Program
  {
    static void Main(string[] args)
    {

      for (int i = 1; i < 256; i++)
      {
        Console.WriteLine(i);
      }


      for (int i = 1; i < 101; i++)
      {
        if (i % 3 == 0 && i % 5 == 0)
        {
          continue;
        }
        else if (i % 3 == 0 || i % 5 == 0)
        {
          Console.WriteLine(i);
        }
      }

      for (int i = 1; i < 101; i++)
      {
        if (i % 3 == 0 && i % 5 == 0)
        {
          Console.WriteLine("FizzBuzz");
        }
        else if (i % 3 == 0)
        {
          Console.WriteLine("Fizz");
        }
        else if (i % 5 == 0)
        {
          Console.WriteLine("Buzz");
        }
        else
        {
          Console.WriteLine(i);
        }

      }


      int j = 1;
      while (j < 256)
      {
        Console.WriteLine(j);
        j++;
      }


      int k = 1;
      while (k < 101)
      {
        if (k % 3 == 0 && k % 5 == 0)
        {
          k++;
        }
        else if (k % 3 == 0 || k % 5 == 0)
        {
          Console.WriteLine(k);
          k++;
        }
      }

      int l = 1;
      while (l < 101)
      {
        if (l % 3 == 0 && l % 5 == 0)
        {
          Console.WriteLine("FizzBuzz");
          l++;
        }
        else if (l % 3 == 0)
        {
          Console.WriteLine("Fizz");
          l++;
        }
        else if (l % 5 == 0)
        {
          Console.WriteLine("Buzz");
          l++;
        }
        else
        {
          Console.WriteLine(l);
          l++;
        }
      }
    }
  }
}
