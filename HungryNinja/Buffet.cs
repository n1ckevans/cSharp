using System;
using System.Collections.Generic;

namespace HungryNinja
{
  public class Buffet
  {
    public List<Food> Menu;

    
    public Buffet()
    {
      Menu = new List<Food>()
        {
            new Food("Chicken", 1000, false, false),
            new Food("Steak", 1200, false, false),
            new Food("Rice", 100, false, false),
            new Food("Jalapenos", 50, true, false),
            new Food("Tortilla", 100, false, false),
            new Food("Beans", 200, false, false),
            new Food("Cheese", 200, false, true)
        };
    }

    public Food Serve()
    {
      Random rand = new Random();
      int index = rand.Next(Menu.Count);
      return Menu[index];
    }




  }
}