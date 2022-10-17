using System;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        // ListNode six = new ListNode(6);
        // ListNode five = new ListNode(5, six);
        // ListNode four = new ListNode(4, five);
        // ListNode three = new ListNode(3, four);
        // ListNode two = new ListNode(2, three);
        
        // ListNode list1 = ListNodeFromArray(new int[]{2,4,3});
        // ListNode list2 = ListNodeFromArray(new int[]{5,6,4});

        ListNode list1 = ListNodeFromArray(new int[]{9,9,9,9,9,9,9});
        ListNode list2 = ListNodeFromArray(new int[]{9,9,9,9});

        //Console.WriteLine(AddTwoNumbers(list1, list2).val);
        AddTwoNumbers(list1, list2);

        // while(l1 != null) {
        //     Console.WriteLine("-" + l1.val);
        //     l1 = l1.next;
        // }
    }

    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode current1 = l1;
        ListNode current2 = l2;

        while(current1 != null && current2 != null) {
            if(current1.next == null && current2.next != null) {
                current1.next = new ListNode(0);
            }

            if(current2.next == null && current1.next != null) {
                current2.next = new ListNode(0);
            }

            current1 = current1.next;
            current2 = current2.next;
        }

        current1 = l1;
        current2 = l2;
        int carry = 0;

        while(current1 != null) {
            if(current1.val + current2.val + carry > 9) {
                current1.val = (current1.val + current2.val + carry) % 10;
                carry = 1;
            } else {
                current1.val = current1.val + current2.val + carry;
                carry = 0;
            }
            if(current1 != null) {
                //Console.WriteLine(current1.val);
            }

            if(carry > 0 && current1.next == null) {
                current1.next = new ListNode(carry);
                //Console.WriteLine(current1.next.val);
                break;
            }
            
            current1 = current1.next;
            current2 = current2.next;
        }

        return l1;
    }

    public static ListNode ListNodeFromArray(int[] values) {
        ListNode head = new ListNode(values[0]);
        ListNode current = head;
        if(values.Length > 1) {
            current.next = ListNodeFromArray(values.Skip(1).ToArray());
        }

        return head;
    }
}