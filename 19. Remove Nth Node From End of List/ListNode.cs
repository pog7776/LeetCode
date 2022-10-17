using System;
using System.Linq;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public ListNode(int[] values) {
        this.val = values[0];
        if(values.Length > 1) {
            this.next = new ListNode(values.Skip(1).ToArray());
        }
    }

    // public static ListNode ListNodeFromArray(int[] values) {
    //     ListNode head = new ListNode(values[0]);
    //     ListNode current = head;
    //     if(values.Length > 1) {
    //         current.next = ListNodeFromArray(values.Skip(1).ToArray());
    //     }

    //     return head;
    // }
}