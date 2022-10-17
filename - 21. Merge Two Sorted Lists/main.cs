using System;
using System.Collections.Generic;
//using System.Linq;

class Program {
    public static void Main(string[] args) {
        Evaluate<ListNode>(
            ListNode.ListNodeFromArray(new int[] {1,2,4}),
            ListNode.ListNodeFromArray(new int[] {1,3,4}),
            ListNode.ListNodeFromArray(new int[] {1,1,2,3,4,4}),
            "Compare"
        );
        //Test.Evaluate<ListNode>(1,2,"Should not work");
    }
    
    public static ListNode Solution(ListNode list1, ListNode list2) {
        
        return list1;
    }

    public static bool Evaluate<T>(T input, T input2, T expected, string description = "") {
        Console.WriteLine("=====" + description + "=====");
        var result = Program.Solution(input as dynamic, input2 as dynamic);

        if (ListNode.CompareList(result, expected as dynamic)) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PASS");
            Console.ResetColor();
            Console.WriteLine("Expected:\t" + ListNode.ToString(expected as dynamic));
            Console.WriteLine("Result:\t\t" + ListNode.ToString(result) + "\n");
            return true;
        } else {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("FAIL");
            Console.ResetColor();
            Console.WriteLine("Expected:\t" + ListNode.ToString(expected as dynamic));
            Console.WriteLine("Result:\t\t" + ListNode.ToString(result) + "\n");
            return false;
        }
    }
}