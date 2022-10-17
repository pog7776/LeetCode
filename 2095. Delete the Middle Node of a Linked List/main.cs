using System;
using System.Collections.Generic;
//using System.Linq;

class Program {
    public static void Main(string[] args) {
        ListNode even = Solution(new ListNode(new int[]{1,3,4,7,1,2,6}));
        Test.Evaluate(even, new ListNode(new int[]{1,3,4,1,2,6}), "Remove from 7");

        ListNode odd = Solution(new ListNode(new int[]{1,2,3,4}));
        Test.Evaluate(odd, new ListNode(new int[]{1,2,4}), "Remove from 4");

        ListNode small = Solution(new ListNode(new int[]{1,2}));
        Test.Evaluate(small, new ListNode(new int[]{1}), "Remove from 2");

        ListNode reverse = Solution(new ListNode(new int[]{2,1}));
        Test.Evaluate(reverse, new ListNode(new int[]{2}), "Remove from 2 - reverse");

        ListNode single = Solution(new ListNode(new int[]{1}));
        Test.Evaluate(single, null, "Remove from 1");
    }
    
    public static ListNode Solution(ListNode head) {
        ListNode slow = head;
        ListNode fast = head;

        if(head.next == null) {
            return null;
        }

        if(head.next.next == null) {
            head.next = null;
            return head;
        }

        while(fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        slow.val = slow.next.val;
        slow.next = slow.next.next;

        return head;
    }
}