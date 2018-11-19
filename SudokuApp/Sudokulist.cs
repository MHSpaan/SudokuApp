using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class Sudokulist:IDisposable
    {

        public List<Sudokunumber> Sudokus { get; set; }

        public Sudokulist()
        {
            Sudokus = new List<Sudokunumber>();
        }

        public void Dispose()
        {
            Sudokus.Clear();
        }
    }
}
