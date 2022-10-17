using System;
using System.Collections.Generic;
//using System.Linq;

class Program {
    public static void Main(string[] args) {
        int[][] matrix = new int[][] {new int[]{1,3,5,7},new int[] {10,11,16,20}, new int[] {23,30,34,60}};
        Test.Evaluate(matrix, 3, true, "Target exists");

        int[][] matrix2 = new int[][] {new int[]{1,3,5,7},new int[] {10,11,16,20}, new int[] {23,30,34,60}};
        Test.Evaluate(matrix2, 13, false, "Target does not exist");
    }
    
    public static bool Solution(int[][] matrix, int target) {
        for(int i = matrix.Length-1; i >= 0; i--) {
            if(matrix[i][0] <= target) {
                for(int j = 0; j < matrix[i].Length; j++) {
                    if(matrix[i][j] == target) {
                        return true;
                    }
                    if(matrix[i][j] > target) {
                        break;
                    }
                }
            }
        }
        return false;
    }
}