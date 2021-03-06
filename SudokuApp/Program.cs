﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuApp
{
    class Program
    {
        static ViewController vc = new ViewController();
        static UpdateController uc = new UpdateController();
        static Sudokunumber sn = new Sudokunumber();
        static readonly int size = 9;
        static Stopwatch sw = new Stopwatch();

        #region(Sudoku Array)
        //Very Easy
        //public static int[,] sudokuarray =
        //      {
        //            {0,0,7,0,8,0,4,0,9 },
        //            {0,5,1,0,0,2,0,6,0 },
        //            {8,0,0,3,1,0,7,0,0 },
        //            {0,0,0,4,0,8,0,9,0 },
        //            {0,6,2,9,0,0,1,0,3 },
        //            {3,0,9,6,0,0,5,7,4 },
        //            {0,1,0,0,9,0,0,3,0 },
        //            {7,0,0,0,0,5,8,0,2 },
        //            {6,2,4,0,7,3,0,5,0 }

        //      };

        // Easy
        //public static int[,] sudokuarray =
        //  {

        //                {4,2,0,7,0,0,0,3,5 },
        //                {1,0,8,2,0,0,0,0,0 },
        //                {0,0,0,6,0,0,0,0,1 },
        //                {3,0,0,1,0,9,0,4,0 },
        //                {0,0,0,0,4,0,0,2,0 },
        //                {0,0,9,0,0,7,8,0,6 },
        //                {0,7,0,8,5,0,0,0,0 },
        //                {0,0,5,0,0,1,0,9,0 },
        //                {6,0,1,0,0,0,4,0,3 }
        //      };

        // Intermediate
        public static int[,] sudokuarray =
      {

                                        {8,0,0,5,0,0,0,0,0 },
                                        {2,0,0,0,0,0,0,5,0 },
                                        {4,3,0,0,0,7,0,0,9 },
                                        {0,0,0,4,0,0,0,0,7 },
                                        {0,0,0,0,8,3,5,0,0 },
                                        {0,4,0,0,2,0,6,0,1 },
                                        {0,0,8,0,0,0,3,0,0 },
                                        {0,0,0,0,6,0,0,0,5 },
                                        {0,0,0,0,0,2,0,0,0 }
                          };

        // Hard
        //  public static int[,] sudokuarray =
        //{
        //                                            {7,0,9,0,8,5,0,0,1 },
        //                                            {0,0,0,0,0,0,0,0,0 },
        //                                            {1,0,3,0,0,0,6,0,0 },
        //                                            {0,0,0,2,6,0,0,0,0 },
        //                                            {0,0,7,0,0,0,0,8,5 },
        //                                            {0,0,0,0,0,4,0,3,0 },
        //                                            {0,8,4,6,9,0,0,0,0 },
        //                                            {3,0,0,0,0,0,0,1,0 },
        //                                            {0,0,0,0,0,0,0,0,0 }
        //                              };

        // Very Hard
        //  public static int[,] sudokuarray =
        //{
        //                              {4,2,0,7,0,0,0,3,5 },
        //                              {1,0,8,2,0,0,0,0,0 },
        //                              {0,0,0,6,0,0,0,0,1 },
        //                              {3,0,0,1,0,9,0,4,0 },
        //                              {0,0,0,0,4,0,0,2,0 },
        //                              {0,0,9,0,0,7,8,0,6 },
        //                              {0,7,0,8,5,0,0,0,0 },
        //                              {0,0,5,0,0,1,0,9,0 },
        //                              {6,0,1,0,0,0,4,0,3 }
        //                };

        //        public static int[,] sudokuarray =
        //{
        //                                                                {8,0,0,0,0,0,0,0,0 },
        //                                                                {0,0,3,6,0,0,0,0,0 },
        //                                                                {0,7,0,0,9,0,2,0,0 },
        //                                                                {0,5,0,0,0,7,0,0,0 },
        //                                                                {0,0,0,0,4,5,7,0,0 },
        //                                                                {0,0,0,1,0,0,0,3,0 },
        //                                                                {0,0,1,0,0,0,0,6,8 },
        //                                                                {0,0,8,5,0,0,0,1,0 },
        //                                                                {0,9,0,0,0,0,4,0,0 }
        //                                                  };
        #endregion
        static OutcomeList outcomearray = new OutcomeList(sudokuarray);
        static void Main(string[] args)
        {
            var rows = sudokuarray.GetLength(0);
            var columns = sudokuarray.GetLength(1);
            var sum = 0;

            vc.ConsoleSudokuDisplay(outcomearray.Outcomes);
            Console.ReadLine();




            uc.Filling(outcomearray);
            if (outcomearray.Solved)
            {
                sudokuarray = outcomearray.Outcomes;
            }
            else
            {
                uc.PreFilling(outcomearray);
                foreach (var item in outcomearray.OutcomesList)
                {
                    uc.Filling(item);

                    if (item.Solved)
                    {
                        sudokuarray = item.Outcomes;
                        goto end;
                    }
                    sum++;
                }
                outcomearray.OutcomesList = outcomearray.OutcomesList.OrderBy(x => x.amountofZeros).ToList();
                if (outcomearray.OutcomesList.Count > 2)
                {
                    outcomearray.OutcomesList.RemoveRange(5, outcomearray.OutcomesList.Count - 5);
                }
                foreach (var item in outcomearray.OutcomesList)
                {
                    uc.PreFilling(item);

                    foreach (var item2 in item.OutcomesList.OrderBy(x => x.amountofZeros))
                    {
                        uc.Filling(item2);

                        if (item2.Solved)
                        {

                            sudokuarray = item2.Outcomes;
                            goto end;
                        }
                        sum++;
                    }
                    item.OutcomesList = item.OutcomesList.OrderBy(x => x.amountofZeros).ToList();
                    if (item.OutcomesList.Count > 3)
                    {
                        item.OutcomesList.RemoveRange(5, item.OutcomesList.Count - 5);
                    }
                }


                foreach (var item in outcomearray.OutcomesList.OrderBy(x => x.amountofZeros))
                {

                    foreach (var item2 in item.OutcomesList.OrderBy(x => x.amountofZeros))
                    {
                        uc.PreFilling(item2);
                        foreach (var item3 in item2.OutcomesList.OrderBy(x => x.amountofZeros))
                        {
                            uc.Filling(item3);
                            if (item3.Solved)
                            {

                                sudokuarray = item3.Outcomes;
                                goto end;
                            }
                        }
                        item2.OutcomesList = item2.OutcomesList.OrderBy(x => x.amountofZeros).ToList();
                        if (item2.OutcomesList.Count > 4)
                        {
                            item2.OutcomesList.RemoveRange(5, item2.OutcomesList.Count - 5);

                        }
                        sum++;
                    }
                }

            }
            end:


            vc.ConsoleSudokuDisplay(sudokuarray);

            Console.ReadLine();
        }
    }
}

