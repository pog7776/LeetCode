using System;
using System.Collections.Generic;
//using System.Linq;

class Program {
    public static void Main(string[] args) {
        Test.Evaluate<int>(1,1,"Should work");
        Test.Evaluate<int>(1,2,"Should not work");
    }
    
    public static int Solution(int a) {
        return a;
    }
}