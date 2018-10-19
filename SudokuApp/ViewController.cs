using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class ViewController
    {

        public void WriteandAdd(Sudokulist sl, int value, int i, int f, bool possible)
        {
            if (value > 0 && possible)
            {
                sl.Sudokus.Find(x => x.number == value).AddValues(value, i, f);
            }
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
    }
}
