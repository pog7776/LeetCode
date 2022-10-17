using System;
using System.Collections.Generic;
//using System.Linq;

class Program
{
    public static void Main(string[] args) {
        Console.WriteLine(SingleNumber(new int[]{4,1,2,1,2}));

    }

    public static int SingleNumber(int[] nums) {
        //int result = nums.GroupBy(x => x).Where(x => x.Count() == 1).Select(x => x.Key).FirstOrDefault();

        Dictionary<int, int> occurences = new Dictionary<int, int>();

        foreach(int val in nums) {
            if(occurences.ContainsKey(val)) {
                occurences[val]++;
            } else {
                occurences.Add(val, 1);
            }
        }

        int highestCount = int.MaxValue;
        int highestCountKey = 0;

        foreach(KeyValuePair<int, int> count in occurences) {
            if(count.Value < highestCount) {
                highestCount = count.Value;
                highestCountKey = count.Key;
            }
        }
        
        return highestCountKey;
    }
}