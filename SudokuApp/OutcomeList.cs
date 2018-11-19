using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class OutcomeList: IDisposable
    {
        public int[,] Outcomes { get; set; }
        public Sudokulist Sudokulist { get; set; }
        public List<OutcomeList> OutcomesList { get; set; }

        public OutcomeList(int[,] array)
        {
            Outcomes = array;
            OutcomesList = new List<OutcomeList>();
        }

        public void Dispose()
        {
            OutcomesList.Clear();
            Sudokulist.Dispose();
        }
    }
}
