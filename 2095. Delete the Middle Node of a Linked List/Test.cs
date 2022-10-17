using System;

class Test {
    public static bool Evaluate(ListNode result, ListNode expected, string description = "") {
        Console.WriteLine("=====" + description + "=====");
        string resultString = ListToString(result);
        string expectedResult = ListToString(expected);

        if (resultString == expectedResult) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PASS");
            Console.ResetColor();
            Console.WriteLine("Expected: " + expectedResult);
            Console.WriteLine("Result: " + resultString + "\n");
            return true;
        } else {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("FAIL");
            Console.ResetColor();
            Console.WriteLine("Expected: " + expectedResult);
            Console.WriteLine("Result: " + resultString + "\n");
            return false;
        }
    }

    public static string ListToString(ListNode head) {
        string result = "";
        while(head != null) {
            result += head.val;
            head = head.next;
            if(head != null) {
                result += ", ";
            }
        }
        return result;
    }
}