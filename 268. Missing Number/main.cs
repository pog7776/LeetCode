using System;
using System.Collections.Generic;
//using System.Linq;

class Program {
    public static void Main(string[] args) {
        Evaluate(new int[]{3,0,1}, 2, "Test 1");
        Evaluate(new int[]{0,1}, 2, "Test 2");
        Evaluate(new int[]{9,6,4,2,3,5,7,0,1}, 8, "Test 3");
    }

    public static int MissingNumber(int[] nums) {
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] != i) {
                return i;
            }
        }        
        return nums.Length;
    }

    public static bool Evaluate<T>(T input, int expected, string description = "") {
        Console.WriteLine("=====" + description + "=====");
        var result = MissingNumber(input as int[]);
        if (result.Equals(expected)) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PASS");
            Console.ResetColor();
            Console.WriteLine("Expected: " + expected);
            Console.WriteLine("Result: " + result + "\n");
            return true;
        } else {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("FAIL");
            Console.ResetColor();
            Console.WriteLine("Expected: " + expected);
            Console.WriteLine("Result: " + result + "\n");
            return false;
        }
    }
}