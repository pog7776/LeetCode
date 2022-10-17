using System;

class Test {
    public static bool Evaluate(double x, int n, double expected, string description = "") {
        Console.WriteLine("=====" + description + "=====");
        double result = Program.Solution(x,n);

        if (result == expected) {
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