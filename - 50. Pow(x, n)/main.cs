using System;
using System.Collections.Generic;
//using System.Linq;

class Program {
    public static void Main(string[] args) {
        Test.Evaluate(2.00, 10, 1024, "2^10");
        Test.Evaluate(2.1, 3, 9.26100, "2.1^3");
        Test.Evaluate(2.00, -2, 0.25000, "2^-2");
    }
    
    //FIXME TOO SLOW
    public static double Solution(double x, double n) {
        if(n == 0) return 1;

        double result = 1;
        for(int i = 1; i <= Math.Abs(n); i++) {
            result *= x;
        }

        if(n < 0) {
            return 1 / result;
        }
        return result;
    }
}