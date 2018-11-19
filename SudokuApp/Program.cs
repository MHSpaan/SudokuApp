using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SudokuApp
{
    class Program
    {
        static PossibilitiesController pc = new PossibilitiesController();
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
        //  public static int[,] sudokuarray =
        //{
        //                                  {5,7,0,0,4,0,0,0,0 },
        //                                  {1,0,3,0,0,8,4,0,0 },
        //                                  {0,0,0,0,0,0,0,0,5 },
        //                                  {0,6,0,0,0,0,0,0,4 },
        //                                  {0,9,0,2,1,0,0,5,0 },
        //                                  {0,0,0,0,9,3,0,0,0 },
        //                                  {0,0,0,8,3,1,2,0,0 },
        //                                  {0,0,4,0,0,0,0,0,3 },
        //                                  {0,0,0,7,0,0,0,0,6 }
        //                    };

        // Hard
        public static int[,] sudokuarray =
      {
                                                {7,0,9,0,8,5,0,0,1 },
                                                {0,0,0,0,0,0,0,0,0 },
                                                {1,0,3,0,0,0,6,0,0 },
                                                {0,0,0,2,6,0,0,0,0 },
                                                {0,0,7,0,0,0,0,8,5 },
                                                {0,0,0,0,0,4,0,3,0 },
                                                {0,8,4,6,9,0,0,0,0 },
                                                {3,0,0,0,0,0,0,1,0 },
                                                {0,0,0,0,5,0,0,0,0 }
                                  };

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
        static OutcomeList arraylists = new OutcomeList(sudokuarray);
        static void Main(string[] args)
        {
            var rows = sudokuarray.GetLength(0);
            var columns = sudokuarray.GetLength(1);

            uc.CreateList(arraylists);

            for (int i = 1; i <= size; i++)
            {
                sn = arraylists.Sudokulist.Sudokus.Find(x => x.Number == i);
                uc.UpdateValues(arraylists.Outcomes, sn);
            }


            vc.ConsoleSudokuDisplay(arraylists.Outcomes);
            Console.ReadLine();

            bool solved = false;
            // 100%
            while (!solved)
            {

                solved = uc.Filling(arraylists);
                if (solved)
                {
                    sudokuarray = arraylists.Outcomes;
                    goto end;
                }

                for (int i = 1; i <= size; i++)
                {
                    sn = arraylists.Sudokulist.Sudokus.Find(x => x.Number == i);
                    uc.UpdateValues(arraylists.Outcomes, sn);
                    var arraylist = uc.FillArray2Options(sn, arraylists.Outcomes, 2);
                    foreach (var item in arraylist)
                    {
                        var outcomelist = new OutcomeList(item);
                        arraylists.OutcomesList.Add(outcomelist);
                    }
                }

                // first time 50%
                foreach (var item in arraylists.OutcomesList)
                {
                    sw.Start();
                    uc.CreateList(item);
                    for (int i = 1; i <= size; i++)
                    {
                        sn = item.Sudokulist.Sudokus.Find(x => x.Number == i);
                        uc.UpdateValues(item.Outcomes, sn);
                    }

                    solved = uc.Filling(item);

                    if (solved)
                    {
                        sudokuarray = item.Outcomes;
                        goto end;
                    }

                    for (int i = 1; i <= size; i++)
                    {
                        sn = item.Sudokulist.Sudokus.Find(x => x.Number == i);
                        uc.UpdateValues(item.Outcomes, sn);

                        var arraylist = uc.FillArray2Options(sn, item.Outcomes, 2);
                        foreach (var item2 in arraylist)
                        {
                            var outcomelist = new OutcomeList(item2);
                            item.OutcomesList.Add(outcomelist);
                        }

                    }
                    // second time 50%
                    foreach (var item2 in item.OutcomesList)
                    {
                        uc.CreateList(item2);
                        for (int i = 1; i <= size; i++)
                        {
                            sn = item2.Sudokulist.Sudokus.Find(x => x.Number == i);
                            uc.UpdateValues(item2.Outcomes, sn);
                        }

                        solved = uc.Filling(item2);
                        if (solved)
                        {
                            sudokuarray = item2.Outcomes;
                            goto end;
                        }

                        for (int i = 1; i <= size; i++)
                        {
                            sn = item2.Sudokulist.Sudokus.Find(x => x.Number == i);
                            uc.UpdateValues(item2.Outcomes, sn);
                            var arraylist = uc.FillArray2Options(sn, item2.Outcomes, 2);
                            foreach (var item3 in arraylist)
                            {
                                var outcomelist = new OutcomeList(item3);
                                item2.OutcomesList.Add(outcomelist);
                            }

                        }

                        // third time 50%
                        foreach (var item3 in item2.OutcomesList)
                        {
                            uc.CreateList(item3);
                            for (int i = 1; i <= size; i++)
                            {
                                sn = item3.Sudokulist.Sudokus.Find(x => x.Number == i);
                                uc.UpdateValues(item3.Outcomes, sn);
                            }

                            solved = uc.Filling(item3);
                            if (solved)
                            {
                                sudokuarray = item3.Outcomes;
                                goto end;
                            }

                            for (int i = 1; i <= size; i++)
                            {
                                sn = item3.Sudokulist.Sudokus.Find(x => x.Number == i);
                                uc.UpdateValues(item3.Outcomes, sn);

                            }
                            item3.Dispose();
                        }

                        item2.Dispose();
                    }
                    item.Dispose();
                    sw.Stop();
                    Console.WriteLine(sw.ElapsedMilliseconds);
                    sw.Reset();
                }
                if (!solved)
                {
                    Console.WriteLine("Not Possible");
                    Console.ReadLine();
                }
                end:;
            }
            vc.ConsoleSudokuDisplay(sudokuarray);
            Console.ReadLine();
        }
    }
}

