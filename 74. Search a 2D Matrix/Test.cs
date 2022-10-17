using System;

class Test {
    public static bool Evaluate(int[][] matrix, int target, bool expected, string description = "") {
        Console.WriteLine("=====" + description + "=====");
        bool result = Program.Solution(matrix, target);

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