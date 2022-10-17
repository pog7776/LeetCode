using System;
using System.Collections.Generic;
//using System.Linq;

class Program {
    public static void Main(string[] args) {
        Evaluate<int[]>(new int[]{1,2,0}, 3, "3 elements with excluded");
        Evaluate<int[]>(new int[]{3,4,-1,1}, 2, "Has negative");
        Evaluate<int[]>(new int[]{7,8,9,11,12}, 1, "Starts beyond 1");
        Evaluate<int[]>(new int[]{1}, 2, "[1]");
        Evaluate<int[]>(new int[]{1,2,0}, 3, "Non Positive");
        Evaluate<int[]>(new int[]{0,2,2,1,1}, 3, "Duplicates");
        Evaluate<int[]>(new int[]{1,2,3,4,5,6}, 7, "No Missing");
        Evaluate<int[]>(new int[]{-1,0,1,2,3,4,5,6}, 7, "No Missing with negative");
    }
    
    public static int Solution(int[] nums) {
        Array.Sort(nums);
        int current = 1;
        int exclude = 0;
        for(int i = 0; i < nums.Length; i++) {
            if(nums[i] < 1) {
                exclude++;
                continue;
            }

            if(i != 0 && nums[i] == nums[i - 1]) {
                exclude++;
                continue;
            }

            if(nums[i] != current) {
                return current;
            }
            current++;
        }
        return (nums.Length+1)-exclude;
    }

    public static bool Evaluate<T>(T input, int expected, string description = "") {
        Console.WriteLine("=====" + description + "=====");
        var result = Solution(input as dynamic);

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