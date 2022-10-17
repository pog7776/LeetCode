using System;
using System.Collections.Generic;
//using System.Linq;

class Program {
    public static void Main(string[] args) {
        // Test.Evaluate<int>(1,1,"Should work");
        // Test.Evaluate<int>(1,2,"Should not work");

        Solution("PAYPALISHIRING", 4);

        // int rows = 1;
        // for(int i = 1; i <= rows; i++) {
        //     CalcJump(rows, i);
        // }
    }
    
    public static string Solution(string s, int numRows) {
        string output = s[0].ToString();
        int initial_jump = (numRows * 2) - 2;
        //int jump_len = initial_jump;

        //for(int i = 1; i < s.Length; i++) {
        int i = 1;
        while(output.Length < s.Length) {
            int[] jumps = CalcJump(numRows, i);
            int jumpLen = jumps[0];

            int index = 1;
            while(jumpLen < s.Length) {
                // if index is even
                if(index % 2 == 0) {
                    jumpLen = jumps[0] * index;
                } else {
                    jumpLen = jumps[1] * index;
                }

                jumpLen -= i-1;

                if(jumpLen >= s.Length) {
                    break;
                }

                output += s[jumpLen];
                Console.WriteLine(output);
                Console.WriteLine(jumpLen + " " + s[jumpLen]);
                index++;
            }
            //output += s[i];
            i++;
        }

        // while(true) {
        //     output += s[jump_len];

        //     if(jump_len != initial_jump) {
        //         jump_len = Math.Abs(initial_jump - jump_len);
        //     }
        //     else {
        //         jump_len += numRows + 1;
        //     }

        //     if(jump_len >= s.Length) {
        //         initial_jump = initial_jump - 2;
        //         jump_len = initial_jump;
        //     }

        //     if(output.Length == s.Length) {
        //         break;
        //     }
        // }

        // for(int i = 0; i < s.Length; i++) {
        //     while(jump_len < s.Length) {
        //         output += s[jump_len];
        //         jump_len += Math.Abs(jump_len * (i-1) - 1);
        //     }

        //     jump_len += numRows + 1;

        //     if(jump_len >= s.Length) {
        //         initial_jump = initial_jump - 2;
        //         jump_len = initial_jump;
        //     }
        // }

        Console.WriteLine(output);

        return output;
    }

    private static int[] CalcJump(int numRows, int row) {
        int originalJump = (numRows * 2) - 2;
        int[] jumps = new int[2];

        jumps[0] = (numRows*2) - (2*row);
        jumps[1] = originalJump - jumps[0];

        //Console.WriteLine("Fist Jump: " + jumps[0]);
        //Console.WriteLine("Second Jump: " + jumps[1]);

        // If one is zero, add them together

        if(jumps[0] == 0 || jumps[1] == 0) {
            int sum = jumps[0] + jumps[1];
            jumps[0] = sum;
            jumps[1] = sum;
        }

        return jumps;
    }
}