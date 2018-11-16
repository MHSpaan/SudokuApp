using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class ViewController
    {

        public void ConsoleSudokuDisplay(int[,] sudokuarray)
        {
            for (int i = 0; i < sudokuarray.GetLength(0); i++)
                for (int f = 0; f < sudokuarray.GetLength(1); f++)
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

    }
}
