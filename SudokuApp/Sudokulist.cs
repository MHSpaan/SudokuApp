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
    }
}
