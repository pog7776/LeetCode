using System;
using System.Collections.Generic;
//using System.Linq;

class Program {
    public static void Main(string[] args) {
        Test.Evaluate<int>(123, 321, "Basic 123");
        Test.Evaluate<int>(-123, -321, "Negative basic");
        Test.Evaluate<int>(120, 21, "Drop leading 0");
        Test.Evaluate<int>(2147483647, 0, "Greater than the 32 bit integer limit");
        Test.Evaluate<int>(-2147483648, 0, "Less than the 32 bit integer limit");
        
    }
    
    public static int Solution(int x) {
        int reversed = 0;

        while(x != 0) {
            int pop = x % 10;
            x /= 10;

            if(reversed > int.MaxValue/10 || (reversed == int.MaxValue / 10 && pop > 7)) return 0;
            if(reversed < int.MinValue/10 || (reversed == int.MinValue / 10 && pop < -8)) return 0;

            int temp = reversed * 10 + pop;
            reversed = temp;
        }

        return reversed;
    }
}