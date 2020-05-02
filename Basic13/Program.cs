using System;
using System.Collections.Generic;

namespace Basic13 {
  class Program {
    public static void PrintNumbers () {

      for (var i = 1; i < 256; i++) {
        Console.WriteLine (i);
      }
    }

    public static void PrintOdds () {

      for (var i = 1; i < 256; i++) {
        if (i % 2 == 1) {
          Console.WriteLine (i);
        }
      }

    }
    public static void PrintSum () {
      int sum = 0;
      for (var i = 0; i < 256; i++) {
        sum += i;
        Console.WriteLine ("New number: " + i + " Sum: " + sum);
      }
    }

    public static void LoopArray (int[] numbers) {
      // Write a function that would iterate through each item of the given integer array and 
      // print each value to the console. 
      for (var idx = 0; idx < numbers.Length; idx++) {
        Console.WriteLine (numbers[idx]);
      }
    }

    public static int FindMax (int[] numbers) {
      var max = numbers[0];
      for (var idx = 1; idx < numbers.Length; idx++) {
        if (numbers[idx] > max) {
          max = numbers[idx];
        }
      }
      Console.WriteLine (max);
      return max;
    }

    public static void GetAverage (int[] numbers) {
      int sum = 0;
      for (var i = 0; i < numbers.Length; i++) {
        sum += numbers[i];
      }
      int avg = sum / numbers.Length;
      Console.WriteLine (avg);

    }

    public static int[] OddArray () {
      int[] numArray = new int[128];
      for (int i = 0; i < numArray.Length; i++) {
        numArray[i] = i * 2 + 1;
        Console.WriteLine (numArray[i]);
      }

      return numArray;
    }

    public static int GreaterThanY (int[] numbers, int y) {
      int check = y;
      int count = 0;
      for (int i = 0; i < numbers.Length; i++) {
        if (numbers[i] > check) {
          count += 1;
        }

      }
      Console.WriteLine (count);
      return count;
    }

    public static void SquareArrayValues (int[] numbers) {
      int[] storage = numbers;
      for (int i = 0; i < numbers.Length; i++) {
        int mult = numbers[i];
        storage[i] *= mult;
        Console.WriteLine (storage[i]);
      }
    }

    public static void EliminateNegatives (int[] numbers) {

      for (int i = 0; i < numbers.Length; i++) {
        if (numbers[i] < 0) {
          numbers[i] = 0;
        }
        Console.WriteLine (numbers[i]);
      }
    }

    public static void MinMaxAverage (int[] numbers) {
      int min = numbers[0];
      int max = numbers[0];
      int sum = 0;
      for (int i = 0; i < numbers.Length; i++) {
        if (numbers[i] < min) {
          min = numbers[i];
        } else if (numbers[i] > max) {
          max = numbers[i];
        }
        sum += numbers[i];
      }
      int avg = sum / numbers.Length;

      Console.WriteLine (min);
      Console.WriteLine (max);
      Console.WriteLine (avg);

    }

    public static void ShiftValues (int[] numbers) {
      for (int i = 0; i < numbers.Length; i++) {
        if (numbers[i] == numbers[numbers.Length - 1]) {
          numbers[i] = 0;
        } else {
          numbers[i] = numbers[i + 1];
        }
      }

    }

    public static object[] NumToString (int[] numbers) {
      object[] holder = new object[numbers.Length];

      for (int i = 0; i < numbers.Length; i++) {
        object newVal = numbers[i];
        if (numbers[i] < 0) {
          newVal = "dojo";
        }

        holder[i] = newVal;
        Console.WriteLine (holder[i]);
      }

      return holder;
    }

    static void Main (string[] args) {
      int[] arr = new int[] { 1, 2, 3, 4, 5, -1, -2, -3, -4, -5 };
      PrintNumbers();
      PrintOdds();
      PrintSum();
      LoopArray(arr);
      FindMax(arr);
      GetAverage(arr);
      OddArray();
      GreaterThanY(arr, 2);
      SquareArrayValues(arr);
      EliminateNegatives(arr);
      MinMaxAverage(arr);
      ShiftValues(arr);
      NumToString (arr);
    }
  }
}