using System;
using System.Collections.Generic;
//using System.Linq;

class Program {
    public static void Main(string[] args) {
        char[][] board1 = new char[][] {
            new char[] {'5','3','.','.','7','.','.','.','.'},
            new char[] {'6','.','.','1','9','5','.','.','.'},
            new char[] {'.','9','8','.','.','.','.','6','.'},
            new char[] {'8','.','.','.','6','.','.','.','3'},
            new char[] {'4','.','.','8','.','3','.','.','1'},
            new char[] {'7','.','.','.','2','.','.','.','6'},
            new char[] {'.','6','.','.','.','.','2','8','.'},
            new char[] {'.','.','.','4','1','9','.','.','5'},
            new char[] {'.','.','.','.','8','.','.','7','9'}
        };

        char[][] board2 = new char[][] {
            new char[] {'8','3','.','.','7','.','.','.','.'},
            new char[] {'6','.','.','1','9','5','.','.','.'},
            new char[] {'.','9','8','.','.','.','.','6','.'},
            new char[] {'8','.','.','.','6','.','.','.','3'},
            new char[] {'4','.','.','8','.','3','.','.','1'},
            new char[] {'7','.','.','.','2','.','.','.','6'},
            new char[] {'.','6','.','.','.','.','2','8','.'},
            new char[] {'.','.','.','4','1','9','.','.','5'},
            new char[] {'.','.','.','.','8','.','.','7','9'}
        };

        char[][] board3 = new char[][] {
            new char[] {'.','8','7','6','5','4','3','2','1'},
            new char[] {'2','.','.','.','.','.','.','.','.'},
            new char[] {'3','.','.','.','.','.','.','.','.'},
            new char[] {'4','.','.','.','.','.','.','.','.'},
            new char[] {'5','.','.','.','.','.','.','.','.'},
            new char[] {'6','.','.','.','.','.','.','.','.'},
            new char[] {'7','.','.','.','.','.','.','.','.'},
            new char[] {'8','.','.','.','.','.','.','.','.'},
            new char[] {'9','.','.','.','.','.','.','.','.'}
        };

        char[][] board4 = new char[][] {
            new char[] {'.','.','4','.','.','.','6','3','.'},
            new char[] {'.','.','.','.','.','.','.','.','.'},
            new char[] {'5','.','.','.','.','.','.','9','.'},
            new char[] {'.','.','.','5','6','.','.','.','.'},
            new char[] {'4','.','3','.','.','.','.','.','1'},
            new char[] {'.','.','.','7','.','.','.','.','.'},
            new char[] {'.','.','.','5','.','.','.','.','.'},
            new char[] {'.','.','.','.','.','.','.','.','.'},
            new char[] {'.','.','.','.','.','.','.','.','.'}
        };



        Test.Evaluate<char[][]>(board1, true, "Should work");
        Test.Evaluate<char[][]>(board2, false, "Should not work");
        Test.Evaluate<char[][]>(board3, true, "Should work");
        Test.Evaluate<char[][]>(board4, false, "Should not work");
    }
    
    public static bool Solution(char[][] board) {
        // for(int i = 0; i < board.Length; i++) {
        //     for(int j = 0; j < board[0].Length; j++) {
        //         if(board[i][j] != '.') {
        //             if(!IsValid(board, i, j)) {
        //                 return false;
        //             }
        //         }
        //     }
        // }

        // Check Rows
        for(int row = 0; row < board.Length; row++) {
            if (CheckRow(board[row]) == false) {
                //Console.WriteLine("Row " + row + " is invalid");
                return false;
            }
        }

        // Check Columns
        for(int column = 0; column < board[0].Length; column++) {
            if (CheckColumn(board, column) == false) {
                //Console.WriteLine("Column " + column + " is invalid");
                return false;
            }
        }

        // Check 3x3 boxes
        return CheckSquares(board);
    }

    public static bool CheckRow(char[] row) {
        List<char> list = new List<char>();
        foreach(char c in row) {
            if(c != '.') {
                if(list.Contains(c)) {
                    return false;
                } else {
                    list.Add(c);
                }
            }
        }

        return true;
    }

    public static bool CheckColumn(char[][] board, int column) {
        List<char> list = new List<char>();

        for(int i = 0; i < board.Length; i++) {
            if(board[i][column] != '.') {
                if(list.Contains(board[i][column])) {
                    return false;
                } else {
                    list.Add(board[i][column]);
                }
            }
        }

        return true;
    }

    public static bool CheckSquares(char[][] board) {
        int multiplyerX = 1;
        int multiplyerY = 1;
        while(multiplyerX <= 3 && multiplyerY <= 3) {
            List<char> list = new List<char>();
            for(int i = 0; i < 3; i++) {
                for(int j = 0; j < 3; j++) {
                    if(board[i + (3 * (multiplyerX - 1))][j + (3 * (multiplyerY - 1))] != '.') {
                        if(list.Contains(board[i + (3 * (multiplyerX - 1))][j + (3 * (multiplyerY - 1))])) {
                            return false;
                        } else {
                            list.Add(board[i + (3 * (multiplyerX - 1))][j + (3 * (multiplyerY - 1))]);
                        }
                    }
                }
            }
            if(multiplyerX < 3) {
                multiplyerX++;
            } else {
                multiplyerX = 1;
                multiplyerY++;
            }
        }
        return true;
    }
}