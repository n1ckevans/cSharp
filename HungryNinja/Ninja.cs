using System;
using System.Collections.Generic;

namespace HungryNinja
{

  class Ninja
  {
    private int calorieIntake;

    public List<Food> FoodHistory;

    public bool IsFull
    {
      get
      {
        if (calorieIntake > 1200)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    public Ninja()
    {
      calorieIntake = 0;
      FoodHistory = new List<Food>() { };
    }


    public void Eat(Food item)
    {
      if (IsFull)
      {
        Console.WriteLine("The Ninja is too full and can't eat anymore");
      }
      else
      {
        Console.WriteLine($"The Ninja is eating {item.Name}");
        Console.WriteLine($"Is {item.Name} spicy?: {item.IsSpicy}");
        Console.WriteLine($"Is {item.Name} spicy?: {item.IsSweet}");
        FoodHistory.Add(item);
        calorieIntake += item.Calories;
      }

    }
  }

}