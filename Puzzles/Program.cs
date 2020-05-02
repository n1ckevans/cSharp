using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles
{
  class Program
  {


    public static void RandomArray()
    {
      int[] random = new int[10];
      int min = random[0];
      int max = random[0];
      int sum = 0;



      for (int i = 0; i < random.Length; i++)
      {
        Random rand = new Random();
        random[i] = rand.Next(5, 25);

        if (random[i] > max)
        {
          max = random[i];
        }

        if (random[i] < min)
        {
          min = random[i];
        }

        sum += random[i];

      }
      Console.WriteLine(min);
      Console.WriteLine(max);
      Console.WriteLine(sum);
    }


    public static int CoinToss()
    {
      Console.WriteLine("Tossing a Coin!");

      Random rand = new Random();
      int result = rand.Next(0, 2);

      if (result == 1)
      {
        Console.WriteLine("Heads!");
      }
      else
      {
        Console.WriteLine("Tails!");
      }
      return result;
    }


    public static double TossMultipleCoins(int num)
    {
      int[] result = new int[num];

      int headSum = 0;

      for (int i = 0; i < num; i++)
      {
        result[i] = CoinToss();
        if (result[i] == 1)
        {
          headSum++;
        }
      }
      Console.WriteLine((double)headSum / num);
      return (double)headSum / num;

    }


    public static void ShuffleNames()
    {

      List<string> names = new List<string>();
      names.Add("Todd");
      names.Add("Tiffany");
      names.Add("Charlie");
      names.Add("Geneva");
      names.Add("Sydney");

    Random rand = new Random();
  var randName = names.OrderBy(c => rand.Next());

  foreach (string x in randName)
  {
    Console.WriteLine(x);
  }


    }




  



  static void Main(string[] args)
  {
    RandomArray();
    CoinToss();
    TossMultipleCoins(8);
    ShuffleNames();
  }
}
}