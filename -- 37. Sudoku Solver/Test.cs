using System;

class Test {
    public static bool Evaluate<T>(T input, T expected, string description = "") {
        Console.WriteLine("=====" + description + "=====");
        var result = BoardToString(Program.Solution(input as dynamic));
        string expectedString = BoardToString(expected as dynamic);

        if (result.Equals(expectedString)) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PASS");
            Console.ResetColor();
            Console.WriteLine("Expected: \n" + expectedString);
            Console.WriteLine("Result: \n" + result + "\n");
            return true;
        } else {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("FAIL");
            Console.ResetColor();
            Console.WriteLine("Expected: \n" + expectedString);
            Console.WriteLine("Result: \n" + result + "\n");
            return false;
        }
    }

    public static string BoardToString(char[][] board) {
        string result = "";
        foreach (var row in board) {
            result += "[";
            foreach (var cell in row) {
                result += cell + ", ";
            }
            result = result.Substring(0, result.Length - 2);
            result += "],\n";
        }
        result = result.Substring(0, result.Length - 2);
        return result;
    }
}