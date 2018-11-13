using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class ViewController
    {

        public void ConsoleSudokuDisplay(int rows, int columns, int[,] sudokuarray)
        {
            for (int i = 0; i < rows; i++)
                for (int f = 0; f < columns; f++)
                {
                    int value = sudokuarray[i, f];

                    if (f != 9 - 1)
                    {
                        if (value == 0)
                        {
                            Console.Write(" ");
                        }
                        else
                            Console.Write(value);
                        Console.Write('|');
                    }
                    else
                    {
                        if (value == 0)
                        {
                            Console.Write(" ");
                        }
                        else
                            Console.Write(value);
                        Console.WriteLine();
                    }
                }
            Console.WriteLine();
        }

        internal void UpdateValues(int rows, int columns, Sudokulist sl, int[,] sudokuarray)
        {
            for (int i = 0; i < rows; i++)
                for (int f = 0; f < columns; f++)
                {
                    int value = sudokuarray[i, f];
                    if (value > 0)
                    {
                        sl.Sudokus.Find(x => x.Number == value).AddValues(value, i, f);
                    }
                }
        }


    }
}
