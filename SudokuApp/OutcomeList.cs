using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    
    class OutcomeList: IDisposable
    {
        UpdateController uc = new UpdateController();

        public int[,] Outcomes { get; set; }
        public int amountofZeros { get; set; }
        public Sudokulist Sudokulist { get; set; }
        public List<OutcomeList> OutcomesList { get; set; }

        public OutcomeList(int[,] array)
        {
            amountofZeros = uc.CountZeros(array);
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
