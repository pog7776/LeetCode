using System;
using System.Collections.Generic;
//using System.Linq;

class Program {
    public static void Main(string[] args) {
        Test.Evaluate<string>("abcabcbb",3,"abcabcbb");
        Test.Evaluate<string>("bbbbb",1,"bbbbb");
        Test.Evaluate<string>("pwwkew",3,"pwwkew");
    }
    
    // I DIDNT WRITE THIS
    public static int Solution(string s) {
        // Nothing to check
        if (s.Length==0) return 0;

        // Count all the characters
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        int max=0;
        for (int i = 0, j = 0; i < s.Length; ++i){
            if (charCount.ContainsKey(s[i])){
                j = (int)MathF.Max(j,charCount[s[i]]+1);
            }
            charCount[s[i]] = i;
            max = (int)MathF.Max(max,i-j+1);
        }
        return max;

        return 0;
    }
}