using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class Sudokulist
    {

        public List<Sudokunumber> Sudokus { get; set; }

        public Sudokulist()
        {
            Sudokus = new List<Sudokunumber>();
        }

        internal void UpdateValues(int[,] sudokuarray)
        {
            for (int i = 0; i < sudokuarray.GetLength(0); i++)
                for (int f = 0; f < sudokuarray.GetLength(1); f++)
                {
                    int value = sudokuarray[i, f];
                    if (value > 0)
                    {
                        Sudokus.Find(x => x.Number == value).AddValues(value, i, f);
                    }
                }
        }
    }
}
