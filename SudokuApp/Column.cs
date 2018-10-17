using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class Column
    {
        public int Number { get; set; }
        public int[] Values { get; set; }

        public Column(int nr, int size)
        {
            Values = new int[size];
            Number = nr;
        }
    }
}
