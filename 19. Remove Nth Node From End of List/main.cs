using System;
using System.Collections.Generic;
//using System.Linq;

class Program {
    public static void Main(string[] args) {
        ListNode basic = Solution(new ListNode(new int[]{1,2,3,4,5}), 2);
        Test.Evaluate(basic, new ListNode(new int[]{1,2,3,5}), "1 - 5");

        ListNode small = Solution(new ListNode(new int[]{1,2}), 1);
        Test.Evaluate(small, new ListNode(new int[]{1}), "Small List");

        ListNode small2 = Solution(new ListNode(new int[]{1,2}), 2);
        Test.Evaluate(small2, new ListNode(new int[]{2}), "Small List2");

        ListNode single = Solution(new ListNode(new int[]{1}), 1);
        Test.Evaluate(single, null, "Single List");
    }

    // public static ListNode Solution(ListNode head, int n) {
    //     ListNode current = head;
    //     ListNode previous = null;
    //     int count = 0;
        
    //     while(current != null) {
    //         count++;
    //         current = current.next;
    //     }
    //     current = head;

        


        
    //     return head;
    // }
    
    public static ListNode Solution(ListNode head, int n) {
        int index = 0;
        int count = 0;
        ListNode current = head;
        // Count the number of nodes
        while(current != null) {
            count++;
            current = current.next;
        }

        // Handle the case where the list is only 1 node long
        if(count == 1) {
            return null;
        }

        if(count == n) {
            return head.next;
        }

        // Go to the node before the one we want to remove
        // current = head;
        // while(index < count - (n + 1)) {
        //     current = current.next;
        //     index++;
        // }
        //current.next = current.next.next;

        // Go to the node we want to remove
        // current = head;
        // while(index < count - n) {
        //     current = current.next;
        //     index++;
        // }

        // if(current.next != null) {
        //     current.val = current.next.val;
        //     current.next = current.next.next;
        // } else {
        //     current = null;
        // }
        // current.val = current.next.val;
        // current.next = current.next.next;

        // Go to the node before the one we want to remove
        current = head;
        while(index < count - (n + 1)) {
            current = current.next;
            index++;
        }

        current.next = current.next.next;

        return head;
    }

    // public static void PrintList(ListNode head) {
    //     while(head != null && head.next != null) {
    //         Console.WriteLine(head.val);
    //         head = head.next;
    //     }
    // }

    // public static void CompareList(ListNode head, ListNode expected) {
    //     while(head != null && head.next != null) {
    //         Console.Write(head.val);
    //         head = head.next;
    //     }
    //     Console.WriteLine("");
    //     while(expected != null && expected.next != null) {
    //         Console.Write(expected.val);
    //         expected = expected.next;
    //     }
    // }
}