using System;


namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
        
            Buffet buffet = new Buffet();
          

            Ninja n1 = new Ninja();
            while(!n1.IsFull)
            {
              n1.Eat(buffet.Serve());
            }
              n1.Eat(buffet.Serve());
        }

    }
}
