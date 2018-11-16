using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class UpdateController
    {
        static List<int[,]> sudokuarrays;
        PossibilitiesController pc = new PossibilitiesController();
        ViewController vc = new ViewController();

        internal void FillArray1Option(Sudokunumber sn, int[,] sudokuarray, int possibillities)
        {
            var possibilitiesarray = sn.Possibilitiesarray;

            sn.Possibilitiesarray.FillFieldsonRows(sudokuarray, possibillities);
            sn.Possibilitiesarray.FillFieldsonColumns(sudokuarray, possibillities);
            sn.Possibilitiesarray.FillFieldsonFields(sudokuarray, possibillities);
            pc.PossibilityFinder(sudokuarray, sn);
        }

        internal int[,] FillArray2Options(Sudokunumber sn, int[,] sudokuarray, int possibillities)
        {
            var possibilitiesarray = sn.Possibilitiesarray;
            List<int[,]> sudokus = new List<int[,]>();
            sudokus = sn.Possibilitiesarray.FillFieldsonRows(sudokuarray, possibillities);
            foreach (var item in sudokus)
            {
                sudokuarrays.Add(item);

                vc.ConsoleSudokuDisplay(item);
            }
            sudokus = sn.Possibilitiesarray.FillFieldsonColumns(sudokuarray, possibillities);
            sudokuarray = sn.Possibilitiesarray.FillFieldsonFields(sudokuarray, possibillities);
            return possibilitiesarray.Values;
        }
    }
}
