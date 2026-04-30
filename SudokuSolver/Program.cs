using SudokuSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {

        int[,] puzzle = new int[9, 9];

        Console.WriteLine("Enter Sudoku row by row (use spaces, 0 for blanks):");

        for (int row = 0; row < 9; row++)
        {
            while (true)
            {
                Console.Write($"Row {row + 1}: ");
                string input = Console.ReadLine();

                string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 9)
                {
                    Console.WriteLine("Each row must have exactly 9 numbers.");
                    continue;
                }

                bool valid = true;

                for (int col = 0; col < 9; col++)
                {
                    if (int.TryParse(parts[col], out int value))
                    {
                        puzzle[row, col] = value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number detected. Try again.");
                        valid = false;
                        break;
                    }
                }

                if (valid)
                    break;
            }
        }

        /// test sudoku puzzle (passed check)
        ///
        ///    {9, 0, 0, 5, 0, 8, 0, 0, 7},
        ///    {0, 8, 0, 3, 0, 2, 9, 0, 5},
        ///    {0, 5, 4, 0, 0, 0, 0, 8, 0},
        ///    {0, 7, 0, 6, 8, 0, 0, 3, 2},
        ///    {1, 0, 0, 0, 0, 4, 0, 0, 8},
        ///   {5, 0, 0, 2, 1, 9, 0, 6, 0},
        ///    {0, 0, 0, 9, 0, 6, 0, 0, 1},
        ///    {7, 2, 6, 0, 0, 1, 0, 4, 0},
        ///    {0, 0, 1, 4, 7, 0, 0, 5, 6}
        ///};

        SudokuSolver2 solver = new SudokuSolver2(puzzle);

        if(solver.Solve())
        {
            Console.WriteLine("Solved.");
            solver.PuzzlePrint();
        }
        else
        {
            Console.WriteLine("No solution found. Re-enter your values.");
        }
    }
}
