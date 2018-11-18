using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{

    class Possibilities
    {
        public int Number { get; set; }
        public int[,] Values { get; set; }

        public Possibilities(int nr)
        {
            Values = new int[9, 9];
            Number = nr;
        }


    }
}
