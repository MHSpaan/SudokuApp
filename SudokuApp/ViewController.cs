using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class ViewController
    {
        internal List<int[,]> sudokuarrays = new List<int[,]>();
        public void ConsoleSudokuDisplay(int rows, int columns, int[,] sudokuarray)
        {
            for (int i = 0; i < rows; i++)
                for (int f = 0; f < columns; f++)
                {
                    int value = sudokuarray[i, f];

                    if (f != 9 - 1)
                    {
                        if (value == 0)
                        {
                            Console.Write(" ");
                        }
                        else
                            Console.Write(value);
                        Console.Write('|');
                    }
                    else
                    {
                        if (value == 0)
                        {
                            Console.Write(" ");
                        }
                        else
                            Console.Write(value);
                        Console.WriteLine();
                    }
                }
            Console.WriteLine();
        }

        internal void UpdateValues(int rows, int columns, Sudokulist sl, int[,] sudokuarray)
        {
            for (int i = 0; i < rows; i++)
                for (int f = 0; f < columns; f++)
                {
                    int value = sudokuarray[i, f];
                    if (value > 0)
                    {
                        sl.Sudokus.Find(x => x.Number == value).AddValues(value, i, f);
                    }
                }
        }

        internal int[,] FillArray1Option(Sudokunumber sn, int[,] sudokuarray, int possibillities)
        {
            sn.PossibilityFinder(sudokuarray, sn);
            var possibilitiesarray = sn.Possibilitiesarray;
            List<int[,]> tmplist = sn.FillFieldsonRows(sudokuarray, possibilitiesarray, possibillities);
            if (tmplist.Count != 0)
            {
                sudokuarray = tmplist[0];
            }
            sudokuarray = sn.FillFieldsonColumns(sudokuarray, possibilitiesarray);
            sudokuarray = sn.FillFieldsonFields(sudokuarray, possibilitiesarray);
            return possibilitiesarray.Values;
        }

        internal int[,] FillArray2Options(Sudokunumber sn, int[,] sudokuarray, int possibillities)
        {
            sn.PossibilityFinder(sudokuarray, sn);
            var possibilitiesarray = sn.Possibilitiesarray;
            List<int[,]> sudokus = new List<int[,]>();
            sudokus = sn.FillFieldsonRows(sudokuarray, possibilitiesarray, possibillities);
            foreach (var item in sudokus)
            {
                sudokuarrays.Add(item);

                ConsoleSudokuDisplay(9, 9, item);
            }
            sudokuarray = sn.FillFieldsonColumns(sudokuarray, possibilitiesarray);
            sudokuarray = sn.FillFieldsonFields(sudokuarray, possibilitiesarray);
            return possibilitiesarray.Values;
        }

        internal int CountPossibilities(int[,] PossibilityArrayValues)
        {
            int counter = 0;
            foreach (var item in PossibilityArrayValues)
            {
                counter += item;
            }
            return counter;
        }
    }
}
