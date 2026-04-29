using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class SudokuSolver2
    {
        private int[,] puzzle;

        public SudokuSolver2(int[,] intPuzzle)
        {
            puzzle = intPuzzle;
        }

        public bool Solve()
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (puzzle[r, c] == 0)
                    {
                        for (int num = 1; num <= 9; num++)
                        {
                            if (IsValid(r, c, num))
                            {
                                puzzle[r, c] = num; //set
                                if (Solve())
                                    return true;
                                puzzle[r, c] = 0; //reset
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsValid(int r, int c, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (puzzle[r, i] == num)
                {
                    return false;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (puzzle[i, c] == num)
                {
                    return false;
                }
            }

            int startR = r - r % 3;
            int startC = c - c % 3;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (puzzle[startR + i, startC + j] == num)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void PuzzlePrint()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(puzzle[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
