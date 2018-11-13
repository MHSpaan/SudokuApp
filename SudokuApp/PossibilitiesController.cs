﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class PossibilitiesController
    {
        internal List<int[,]> sudokuarrays = new List<int[,]>();
        ViewController vc = new ViewController();
        public Possibilities PossibilityFinder(int[,] array, Sudokunumber number)
        {
            Possibilities Possibilitiesarray = new Possibilities(number.Number);
            var row = array.GetLength(0);
            var column = array.GetLength(1);
            for (int i = 0; i < row; i++)
                for (int f = 0; f < column; f++)
                {
                    if (array[i, f] > 0)
                    {
                        Possibilitiesarray.Values[i, f] = 0;
                    }
                    else
                    {

                        bool ispresent = false;
                        foreach (var nr in number.Rows.Find(x => x.Number == i + 1).Values)
                        {
                            if (nr == number.Number)
                            {
                                ispresent = true;
                                break;
                            }
                        }

                        if (!ispresent)
                        {
                            foreach (var nr in number.Columns.Find(x => x.Number == f + 1).Values)
                            {
                                if (nr == number.Number)
                                {
                                    ispresent = true;
                                    break;
                                }
                            }

                            #region(decide fieldnumber)
                            int fieldnumber;
                            if (f < 3)
                                if (i < 3)
                                    fieldnumber = 1;
                                else if (i > 5)
                                    fieldnumber = 7;
                                else
                                    fieldnumber = 4;

                            else if (f > 5)
                                if (i < 3)
                                    fieldnumber = 3;
                                else if (i > 5)
                                    fieldnumber = 9;
                                else
                                    fieldnumber = 6;

                            else
                                if (i < 3)
                                fieldnumber = 2;
                            else if (i > 5)
                                fieldnumber = 8;
                            else
                                fieldnumber = 5;
                            #endregion

                            foreach (var nr in number.Fields.Find(x => x.Number == fieldnumber).Values)
                            {
                                if (nr == number.Number)
                                {
                                    ispresent = true;
                                    break;
                                }
                            }
                        }

                        if (ispresent)
                        {
                            Possibilitiesarray.Values[i, f] = 0;
                        }
                        else
                        {
                            Possibilitiesarray.Values[i, f] = 1;
                        }

                    }
                }
            return Possibilitiesarray;
        }

        internal int[,] FillArray1Option(Sudokunumber sn, int[,] sudokuarray, int possibillities)
        {
            PossibilityFinder(sudokuarray, sn);
            var possibilitiesarray = sn.Possibilitiesarray;

            sn.FillFieldsonRows(sudokuarray, possibilitiesarray, possibillities);
            sn.FillFieldsonColumns(sudokuarray, possibilitiesarray);
            sn.FillFieldsonFields(sudokuarray, possibilitiesarray);
            return possibilitiesarray.Values;
        }

        internal int[,] FillArray2Options(Sudokunumber sn, int[,] sudokuarray, int possibillities)
        {
            PossibilityFinder(sudokuarray, sn);
            var possibilitiesarray = sn.Possibilitiesarray;
            List<int[,]> sudokus = new List<int[,]>();
            sudokus = sn.FillFieldsonRows(sudokuarray, possibilitiesarray, possibillities);
            foreach (var item in sudokus)
            {
                sudokuarrays.Add(item);

                vc.ConsoleSudokuDisplay(9, 9, item);
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