using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class Field
    {
        public int Number { get; set; }
        public int[,] Values { get; set; }

        public Field(int nr)
        {
            Values = new int[3,3];
            Number = nr;
        }
    }
}
