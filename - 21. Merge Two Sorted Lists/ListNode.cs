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

    public static ListNode ListNodeFromArray(int[] values) {
        ListNode head = new ListNode(values[0]);
        ListNode current = head;
        if(values.Length > 1) {
            current.next = ListNodeFromArray(values.Skip(1).ToArray());
        }

        return head;
    }

    public static bool CompareList(ListNode list1, ListNode list2) {
        if(list1 == null && list2 == null) {
            return true;
        } else if(list1 == null || list2 == null) {
            return false;
        } else if(list1.val != list2.val) {
            return false;
        } else {
            return CompareList(list1.next, list2.next);
        }
    }

    public static void PrintList(ListNode list) {
        if(list == null) {
            Console.WriteLine("null");
        } else {
            Console.Write(list.val + " -> ");
            PrintList(list.next);
        }
    }

    public static string ToString(ListNode list) {
        if(list == null) {
            return "null";
        } else {
            return list.val + " -> " + ToString(list.next);
        }
    }
}