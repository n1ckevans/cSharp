using System;
using System.Collections.Generic;


namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
          List<object> box = new List<object>();
          box.Add(7);
          box.Add(28);
          box.Add(-1);
          box.Add(true);
          box.Add("chair");

        int sum = 0;
          for (var idx = 0; idx < box.Count; idx++){
            Console.WriteLine(box[idx]);

        
            if (box[idx] is int){
             sum += Convert.ToInt32(box[idx]);
            
            }

          }
          Console.WriteLine(sum);

        }
    }
}
