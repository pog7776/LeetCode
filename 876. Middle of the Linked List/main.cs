using System;
using System.Diagnostics;

class Program
{
    public static void Main(string[] args)
    {
        ListNode six = new ListNode(6);
        ListNode five = new ListNode(5, six);
        ListNode four = new ListNode(4, five);
        ListNode three = new ListNode(3, four);
        ListNode two = new ListNode(2, three);
        ListNode one = new ListNode(1, two);

        ListNode answer = MiddleNode(one);
    }

    public static ListNode MiddleNode(ListNode head)
    {
        int count = 1;
        ListNode current = head;
        while (current != null)
        {
            count++;
            current = current.next;
        }

        double midpoint = Math.Ceiling((count) / 2.0);
        ListNode output = head;
        
        for (int i = 1; i < midpoint; i++) {
            output = output.next;
        }

        //Console.WriteLine(output.val);

        return output;
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}