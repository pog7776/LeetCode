using System;
using System.Linq;

class Program2
{
    public static void Main2(string[] args)
    {
        // ListNode six = new ListNode(6);
        // ListNode five = new ListNode(5, six);
        // ListNode four = new ListNode(4, five);
        // ListNode three = new ListNode(3, four);
        // ListNode two = new ListNode(2, three);
        ListNode list1 = ListNodeFromArray(new int[]{2,4,3});
        ListNode list2 = ListNodeFromArray(new int[]{5,6,4});

        Console.WriteLine(AddTwoNumbers(list1, list2).val);
    }

    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        int int1 = ConvertToInt(l1);
        int int2 = ConvertToInt(l2);

        int sum = int1 + int2;
        Console.WriteLine(sum);

        string sumString = sum.ToString();
        int[] sumArray = new int[sumString.Length];
        int j = 0;
        for(int i = 0; i < sumString.Length; i++) {
            sumArray[j] = int.Parse(sumString[i].ToString());
            j++;
        }

        return ListNodeFromArray(sumArray);
    }

    public static int ConvertToInt(ListNode list) {
        int total = 0;
        int multiplier = 1;
        while(list != null) {
            total += (list.val * multiplier);
            multiplier *= 10;
            list = list.next;
        }

        return total;
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