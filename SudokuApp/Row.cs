using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class Row
    {
        public int Number { get; set; }
        public int[] Values { get; set; }



        public Row(int nr,int size)
        {
            Values = new int[size];
            Number = nr;
        }
    }
}
