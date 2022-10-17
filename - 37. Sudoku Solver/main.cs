using System;
using System.Collections.Generic;
using System.Linq;
//using System.Linq;

class Program {
    public static void Main(string[] args) {
        char[][] inputBoard = new char[][] {
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

        char[][] inputBoard2 = new char[][] {
            new char[] {'.','.','9','7','4','8','.','.','.'},
            new char[] {'7','.','.','.','.','.','.','.','.'},
            new char[] {'.','2','.','1','.','9','.','.','.'},
            new char[] {'.','.','7','.','.','.','2','4','.'},
            new char[] {'.','6','4','.','1','.','5','9','.'},
            new char[] {'.','9','8','.','.','.','3','.','.'},
            new char[] {'.','.','.','8','.','3','.','2','.'},
            new char[] {'.','.','.','.','.','.','.','.','6'},
            new char[] {'.','.','.','2','7','5','9','.','.'}
        };

        char[][] outputBoard = new char[][] {
            new char[] {'5','3','4','6','7','8','9','1','2'},
            new char[] {'6','7','2','1','9','5','3','4','8'},
            new char[] {'1','9','8','3','4','2','5','6','7'},
            new char[] {'8','5','9','7','6','1','4','2','3'},
            new char[] {'4','2','6','8','5','3','7','9','1'},
            new char[] {'7','1','3','9','2','4','8','5','6'},
            new char[] {'9','6','1','5','3','7','2','8','4'},
            new char[] {'2','8','7','4','1','9','6','3','5'},
            new char[] {'3','4','5','2','8','6','1','7','9'}
        };

        Test.Evaluate<char[][]>(inputBoard, outputBoard, "Test 1");

        Test.Evaluate<char[][]>(inputBoard2, inputBoard2, "Test 2");
    }
    
    public static char[][] Solution(char[][] board) {
        // Create boxes
        Board boardObj = new Board(new Dictionary<int, Box>());

        PopulateBoxes(boardObj, board);

        // Init columns and rows
        for(int i = 0; i < 9; i++) {
            boardObj.rows[i] = GetRowVals(board, i);
            boardObj.columns[i] = GetColumnVals(board, i);
        }
        
        int cycle = 0;
        while(boardObj.remainingCells > 0) {
            foreach(KeyValuePair<int, Box> box in boardObj.boxes) {
                
                // Total count of each possibility value
                Dictionary<char, int> possibilityCounts = box.Value.TotalPossibilities();
                // Remove occurences > 1
                possibilityCounts.Where(x => x.Value > 1)
                .ToList()
                .ForEach(poss => possibilityCounts.Remove(poss.Key));

                //foreach(Cell cell in box.Value.EmptyCells) {
                for(int i = 0; i < box.Value.EmptyCells.Count; i++) {
                    if(box.Value.EmptyCells.Count == 0) {
                        break;
                    }
                    if(box.Value.EmptyCells[i].CheckPossible(boardObj, box.Key) && box.Value.EmptyCells[i].possibleValues.Count > 0) {
                        boardObj.remainingCells--;
                        box.Value.PopulatedCells.Add(box.Value.EmptyCells[i]);
                        box.Value.EmptyCells.Remove(box.Value.EmptyCells[i]);
                        i = 0;
                    }

                    foreach(KeyValuePair<char, int> character in possibilityCounts) {
                        if(box.Value.EmptyCells[i].possibleValues.Contains(character.Key)) {
                            // box.Value.EmptyCells[i].Value = character.Key;
                            // box.Value.EmptyCells[i].possibleValues.Clear();
                            // box.Value.PopulatedCells.Add(box.Value.EmptyCells[i]);
                            // box.Value.EmptyCells.Remove(box.Value.EmptyCells[i]);
                            // boardObj.remainingCells--;
                            // i = 0;
                            box.Value.EmptyCells[i].possibleValues.Clear();
                            box.Value.EmptyCells[i].possibleValues.Add(character.Key);
                        }
                    }
                }
            }

            //Console.WriteLine("Remaining cells: " + boardObj.remainingCells);
            boardObj.PrintBoard();
            //break;
            cycle++;
            if(cycle > 100) {
                break;
            }
        }

        // foreach(KeyValuePair<int, List<char>> row in boardObj.rows) {
        //     foreach(char character in row.Value) {
        //         Console.Write(character + " | ");
        //     }
        // }

        int rowIndex = 0;
        foreach(KeyValuePair<int, List<char>> row in boardObj.rows) {
            for(int i = 0; i < row.Value.Count; i++) {
                board[rowIndex][i] = row.Value[i];
            }
            rowIndex++;
        }

        return board;
    }

    //public static void PopulateBoxes(Dictionary<int, Box> boxes, char[][] board) {
    public static void PopulateBoxes(Board boardObj, char[][] board) {
        int multiplyerX = 1;
        int multiplyerY = 1;

        // Which box we in son
        int index = 1;
        while(multiplyerX <= 3 && multiplyerY <= 3) {
            // Create curernt box
            Box currentBox = new Box(index);

            // Cell in Box row
            for(int row = 0; row < 3; row++) {
                // Cell in Box column
                for(int column = 0; column < 3; column++) {
                    //board[row + (3 * (multiplyerX - 1))][column + (3 * (multiplyerY - 1))]
                    char cellVal = board[row + (3 * (multiplyerX - 1))][column + (3 * (multiplyerY - 1))];
                    int cellRow = row + (3 * (multiplyerX - 1));
                    int cellCol = column + (3 * (multiplyerY - 1));
                    currentBox.Add(new Cell(cellVal, cellRow, cellCol));
                }
            }

            // Increment the entire box working on
            // if finished all the cells in the box
            if(multiplyerY < 3) {
                multiplyerY++;
            } else {
                multiplyerY = 1;
                multiplyerX++;
            }

            // Add the box to the dictionary
            boardObj.AddBox(index, currentBox);

            // Remove possible values from cells based on
            // what's in the box
            currentBox.CullPossible();

            //currentBox.PrintBox();

            // Increment the box index
            index++;
        }
    }

    public static List<char> GetColumnVals(char[][] board, int column) {
        List<char> columnVals = new List<char>();
        for(int row = 0; row < 9; row++) {
            columnVals.Add(board[row][column]);
        }
        return columnVals;
    }

    public static List<char> GetRowVals(char[][] board, int row) => board[row].ToList();

    public class Cell {
        private char value;
        public char Value
        {
            get { return value; }
            set { this.value = value; }
        }
        
        public List<char> possibleValues;
        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public int Column => position.x;
        public int Row => position.y;
        public Cell(char value, int row, int column)
        {
            this.value = value;
            this.position = new Vector2(column, row);
            if(value == '.') {
                this.possibleValues = new List<char>() {'1','2','3','4','5','6','7','8','9'};
            }
        }

        public bool CheckPossible(Board board, int boxIndex) {
            Console.WriteLine("========== Cell: " + position.x + ", " + position.y + " ==========");
            //foreach(char pValue in possibleValues) {
            for(int i = 0; i < possibleValues.Count; i++) {

                //Console.WriteLine("Cell: " + position.x + ", " + position.y + " Possible: " + possibleValues[i]);
                // Check Rows
                if(board.rows[Row].Contains(possibleValues[i])) {
                    // Console.WriteLine("Row " + Row + " contains " + possibleValues[i]);
                    // Console.WriteLine("Removing " + possibleValues[i] + " from possible values");
                    possibleValues.Remove(possibleValues[i]);
                    i=0;
                }
                // Check columns
                if(board.columns[Column].Contains(possibleValues[i])) {
                    Console.WriteLine("Column " + Column + " contains " + possibleValues[i]);
                    Console.WriteLine("Removing " + possibleValues[i] + " from possible values");
                    possibleValues.Remove(possibleValues[i]);
                    i=0;
                }
                // Check square
                foreach(KeyValuePair<Vector2, Cell> cell in board.boxes[boxIndex].cells) {
                    if(cell.Value.Value == possibleValues[i]) {
                        Console.WriteLine("Box " + boxIndex + " contains " + possibleValues[i]);
                        Console.WriteLine("Removing " + possibleValues[i] + " from possible values");
                        possibleValues.Remove(possibleValues[i]);
                        i=0;
                    }
                }

                if(possibleValues.Count == 1) {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Only one possible value left: " + possibleValues[0]);
                    Console.ResetColor();
                    Value = possibleValues[0];
                    possibleValues.Clear();
                    board.rows[Row][Column] = Value;
                    board.columns[Column][Row] = Value;
                    return true;
                }
            }
            return false;
        }
    }

    public class Box {
        public int boxNumber;
        public Dictionary<Vector2,Cell> cells;

        private List<Cell> _emptyCells;
        public List<Cell> EmptyCells
        {
            get {
                if(_emptyCells == null) {
                    _emptyCells = new List<Cell>();
                    foreach(Cell cell in cells.Values) {
                        if(cell.Value == '.') {
                            _emptyCells.Add(cell);
                        }
                    }
                }

                return _emptyCells;
            }
        }

        private List<Cell> _populatedCells;
        public List<Cell> PopulatedCells
        {
            get {
                if(_populatedCells == null) {
                    _populatedCells = new List<Cell>();
                    foreach(Cell cell in cells.Values) {
                        if(cell.Value != '.') {
                            _populatedCells.Add(cell);
                        }
                    }
                }

                return _populatedCells;
            }
        }

        public Box(int boxNumber)
        {
            this.boxNumber = boxNumber;
            this.cells = new Dictionary<Vector2, Cell>();
        }

        public void Add(Cell cell) {
            this.cells.Add(cell.Position, cell);
        }

        public void PrintBox() {
            Console.WriteLine("Box: " + boxNumber);
            int index = 1;
            foreach(KeyValuePair<Vector2, Cell> cell in cells) {
                if(index % 3 == 0) {
                    Console.WriteLine(cell.Value.Value);
                } else {
                    Console.Write(cell.Value.Value);
                }
                index++;
            }
        }

        public bool Contains(char value) {
            foreach(Cell cell in PopulatedCells) {
                if(cell.Value == value) {
                    return true;
                }
            }
            return false;
        }

        public void CullPossible() {
            if(cells != null && cells.Count > 0) {
                foreach(Cell cell in EmptyCells) {
                    if(cell.Value == '.') {
                        for(int i = 1; i < 10; i++) {
                        //foreach(char value in cell.possibleValues) {
                            // // ('0' + i) turns it into 1 instad of unicode i
                            char val = (char)('0' + i);
                            if(this.Contains(val)) {
                                cell.possibleValues.Remove(val);
                            }
                        }
                    }
                }
            }
        }

            // foreach(Cell cell in EmptyCells) {
            //     foreach(char value in values) {
            //         if(cell.possibleValues.Contains(value)) {
            //             cell.possibleValues.Remove(value);
            //         }
            //     }

            //     if(cell.possibleValues.Count == 1) {
            //         cell.Value = cell.possibleValues[0];
            //         cell.possibleValues = null;
            //         _emptyCells.Remove(cell);
            //         _populatedCells.Add(cell);
            //     }
            // }

        public Dictionary<char, int> TotalPossibilities() {
            Dictionary<char, int> pTotals = new Dictionary<char, int>();
            foreach(Cell cell in _emptyCells) {
                foreach(char character in cell.possibleValues) {
                    if(pTotals.ContainsKey(character)) {
                        pTotals[character]++;
                    } else {
                        pTotals.Add(character, 1);
                    }
                }
            }
            return pTotals;
        }
    }

    public class Board {
        public int remainingCells;
        public Dictionary<int, Box> boxes;
        public Dictionary<int, List<char>> rows;
        public Dictionary<int, List<char>> columns;

        public Board(Dictionary<int, Box> boxes) {
            this.boxes = boxes;
            this.rows = new Dictionary<int, List<char>>();
            this.columns = new Dictionary<int, List<char>>();
            remainingCells = 81;
        }

        public void AddBox(int index, Box box) {
            this.boxes.Add(index, box);
            remainingCells -= box.PopulatedCells.Count;
        }

        public void PrintBoard() {
            foreach(KeyValuePair<int, List<char>> row in rows) {
                foreach(char character in row.Value) {
                    Console.Write(character + " | ");
                }
                Console.WriteLine("\n-----------------------------------\n");
            }
        }
    }

    public class Vector2 {
        public int x;
        public int y;
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}