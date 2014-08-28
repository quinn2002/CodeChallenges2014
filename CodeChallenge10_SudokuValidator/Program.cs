using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
Week 10

This weeks challenge will not include any extra credit.  The problem itself is fairly simple but will definitely make you think about the right way to tackle it this week.
Sudoku Background

Sudoku is a game played on a 9x9 grid. The goal of the game is to fill all cells of the grid with digits from 1 to 9, so that each column, each row, and each of the nine 3x3 sub-grids (also known as blocks) contain all of the digits from 1 to 9. 
(More info at: http://en.wikipedia.org/wiki/Sudoku)

Sudoku Solution Validator

Write a function validSolution that accepts a 2D array representing a Sudoku board, and returns true if it is a valid solution, or false otherwise. The cells of the sudoku board may also contain 0's, which will represent empty cells. Boards containing one or more zeroes are considered to be invalid solutions.
Examples: 

validSolution([[5, 3, 4, 6, 7, 8, 9, 1, 2], 
               [6, 7, 2, 1, 9, 5, 3, 4, 8],
               [1, 9, 8, 3, 4, 2, 5, 6, 7],
               [8, 5, 9, 7, 6, 1, 4, 2, 3],
               [4, 2, 6, 8, 5, 3, 7, 9, 1],
               [7, 1, 3, 9, 2, 4, 8, 5, 6],
               [9, 6, 1, 5, 3, 7, 2, 8, 4],
               [2, 8, 7, 4, 1, 9, 6, 3, 5],
               [3, 4, 5, 2, 8, 6, 1, 7, 9]])
//Example 1 should return true

validSolution([[5, 3, 4, 6, 7, 8, 9, 1, 2], 
               [6, 7, 2, 1, 9, 0, 3, 4, 8],
               [1, 0, 0, 3, 4, 2, 5, 6, 0],
               [8, 5, 9, 7, 6, 1, 0, 2, 0],
               [4, 2, 6, 8, 5, 3, 7, 9, 1],
               [7, 1, 3, 9, 2, 4, 8, 5, 6],
               [9, 0, 1, 5, 3, 7, 2, 1, 4],
               [2, 8, 7, 4, 1, 9, 6, 3, 5],
               [3, 0, 0, 4, 8, 1, 1, 7, 9]])
//Example 2 should returns false
 */

namespace CodeChallenge10_SudokuValidator
{
    class Program
    {
        public const int SUDOKU_GRID_SIZE = 9; // 9x9 (sudoku grids MUST have equal number of rows/columns)
        
        // sample subgrid counts/sizes (NOTE: total number of subgrids generated MUST equal the SUDOKU_GRID_SIZE):
        /*
            4x4 grid => 4 2x2 subgrids
            9x9 grid => 9 3x3 subgrids
            6x6 grid => 6 2x3 subgrids (i.e. 2 columns, 3 rows)
            12x12 grid => 12 4x3 subgrids
         */
        public const int SUDOKU_SUBGRID_ROW_SIZE = 3;
        public const int SUDOKU_SUBGRID_COL_SIZE = 3;

        static void Main(string[] args)
        {
            string userInput;
            int rowCount = 0;
            var grid = new int[SUDOKU_GRID_SIZE, SUDOKU_GRID_SIZE];
            do
            {
                Console.WriteLine("\nEnter {0} numbers for row {1} of {0} (optionally separate nums by space or comma), followed by Enter key; after {0} rows have been entered, the sudouku validator will execute.", SUDOKU_GRID_SIZE, rowCount + 1);
                userInput = Console.ReadLine();
                List<int> row = BuildSudokuSet(userInput);
                if (IsValidSudokuSet(row))
                {
                    for (int i = 0; i < row.Count; i++)
                    {
                        grid[rowCount, i] = row[i];
                    }
                    rowCount++;
                }
                else
                {
                    Console.WriteLine("Invalid row numbers found.  Please try again.  Make sure there are only {0} numbers ranging from 1 to {0} with optional spaces or commas between", SUDOKU_GRID_SIZE);
                }

                // reset sudoku board after printing validation result
                if (rowCount == SUDOKU_GRID_SIZE)
                {
                    Console.WriteLine("\nSudoku Validation Result: \n{0}\n{1}", PrintGrid(grid), Convert.ToBoolean(ValidateSudokuSolution(grid)));
                    rowCount = 0;
                    grid = new int[SUDOKU_GRID_SIZE, SUDOKU_GRID_SIZE];
                }
            } while (userInput != "q");
        }

        // actual validation of the set is handled in the isValidSudokuSet() function
        public static List<int> BuildSudokuSet(string input)
        {
            var nums = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                string currentChar = input[i].ToString();
                if (IsValidSudokuDigit(currentChar))
                {
                    nums.Add(Convert.ToInt32(currentChar));
                }
                else if (currentChar == "," || currentChar == " ")
                {
                    continue; // allow comma or space delimiter
                }
                else
                {
                    nums = new List<int>();
                    break; // invalid input detected
                }
            }
            return nums;
        }

        // is valid digit 1-9 (9 being the SUDOKU_GRID_SIZE)
        public static bool IsValidSudokuDigit(string currentChar)
        {
            int currentNum;
            return (
                Int32.TryParse(currentChar, out currentNum) &&
                currentNum > 0 &&
                currentNum <= SUDOKU_GRID_SIZE
            );
        }

        // has valid digits 1-9 (9 being the SUDOKU_GRID_SIZE) with no repeats
        public static bool IsValidSudokuSet(List<int> nums)
        {
            foreach (int num in nums)
            {
                if (num <= 0 || num > SUDOKU_GRID_SIZE)
                {
                    return false;
                }
            }
            int numCount = nums.Count;
            bool isUnique = nums.Distinct().Count() == numCount;
            return numCount == SUDOKU_GRID_SIZE && isUnique;
        }

        public static bool ValidateSudokuSolution(int[,] grid)
        {
            bool isValidGridSize = grid.GetLength(0) == SUDOKU_GRID_SIZE && grid.GetLength(1) == SUDOKU_GRID_SIZE;
            bool isValidGrid = isValidGridSize && ValidateSudokuGrid(grid) && ValidateSudokuSubgrids(grid);
            return isValidGrid;
        }

        public static bool ValidateSudokuGrid(int[,] grid)
        {
            bool isValidGrid = ValidateSudokuRows(grid) && ValidateSudokuColumns(grid);
            return isValidGrid;
        }

        public static bool ValidateSudokuRows(int[,] grid)
        {
            bool isValidGrid = true;
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                var nums = new List<int>();
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    nums.Add(grid[row, col]);
                }
                if (!IsValidSudokuSet(nums))
                {
                    isValidGrid = false;
                    return isValidGrid;
                }
            }
            return isValidGrid;
        }

        public static bool ValidateSudokuColumns(int[,] grid)
        {
            bool isValidGrid = true;
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                var nums = new List<int>();
                for (int row = 0; row < grid.GetLength(0); row++)
                {
                    nums.Add(grid[col, row]);
                }
                if (!IsValidSudokuSet(nums))
                {
                    isValidGrid = false;
                    return isValidGrid;
                }
            }
            return isValidGrid;
        }

        public static bool ValidateSudokuSubgrids(int[,] grid)
        {
            bool isValidGrid = true;
            int rowShiftOffset = 0;
            int colShiftOffset = 0;
            for (int i = 0; i < SUDOKU_GRID_SIZE; i++) // 9x9 grid = 9 subgrids, 6x6 grid = 6 subgrids, etc.
            {
                var subgridNums = new List<int>();
                colShiftOffset = (i * SUDOKU_SUBGRID_COL_SIZE) % SUDOKU_GRID_SIZE; // move over to next set of columns with each subgrid iteration
                if (colShiftOffset == 0 && i > 0)
                {
                    rowShiftOffset += SUDOKU_SUBGRID_ROW_SIZE; // move down to the next set of rows if we run out of columns during each subgrid iteration
                }
                for (int row = 0; row < SUDOKU_SUBGRID_ROW_SIZE; row++)
                {
                    for (int col = 0; col < SUDOKU_SUBGRID_COL_SIZE; col++)
                    {
                        subgridNums.Add(grid[rowShiftOffset + row, colShiftOffset + col]);
                    }
                }
                if (!IsValidSudokuSet(subgridNums))
                {
                    isValidGrid = false;
                    return isValidGrid;
                }
            }
            return isValidGrid;
        }

        public static string PrintGrid(int[,] grid)
        {
            var sb = new StringBuilder();
            sb.Append("\n");
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    sb.Append(grid[row, col] + " ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
