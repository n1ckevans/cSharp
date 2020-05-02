using System;
using System.Collections.Generic;

namespace Human
{
  public class Human
  {

    public string Name;
    public int Strength;
    public int Intelligence;
    public int Dexterity;
    private int _health;

    public int Health
    {
      get { return _health; }
      set { _health = value; }
    }


    public Human(string name)
    {
      Name = name;
      Strength = 3;
      Intelligence = 3;
      Dexterity = 3;
      _health = 100;
    }

    public Human(string name, int strength, int intelligence, int dexterity, int health)
    {
      Name = name;
      Strength = strength;
      Intelligence = intelligence;
      Dexterity = dexterity;
      Health = health;
    }

    public int Attack(Human target)
    {
      target.Health -= 5 * Strength;
      Console.WriteLine(target.Health);
      return target.Health;
    }

  }
}