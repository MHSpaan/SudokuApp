using System;
using System.Collections.Generic;
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

        public static List<int[,]> temparraylist = new List<int[,]>();
        public static List<int[,]> temparraylist2 = new List<int[,]>();
        public static int[,] temparray = new int[size, size];
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
        //                              {5,7,0,0,4,0,0,0,0 },
        //                              {1,0,3,0,0,8,4,0,0 },
        //                              {0,0,0,0,0,0,0,0,5 },
        //                              {0,6,0,0,0,0,0,0,4 },
        //                              {0,9,0,2,1,0,0,5,0 },
        //                              {0,0,0,0,9,3,0,0,0 },
        //                              {0,0,0,8,3,1,2,0,0 },
        //                              {0,0,4,0,0,0,0,0,3 },
        //                              {0,0,0,7,0,0,0,0,6 }
        //                };

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
                                    {3,0,0,0,4,0,0,1,0 },
                                    {0,0,0,0,5,0,0,0,0 }
                      };

        // Very Hard
        //  public static int[,] sudokuarray =
        //{
        //                          {4,2,0,7,0,0,0,3,5 },
        //                          {1,0,8,2,0,0,0,0,0 },
        //                          {0,0,0,6,0,0,0,0,1 },
        //                          {3,0,0,1,0,9,0,4,0 },
        //                          {0,0,0,0,4,0,0,2,0 },
        //                          {0,0,9,0,0,7,8,0,6 },
        //                          {0,7,0,8,5,0,0,0,0 },
        //                          {0,0,5,0,0,1,0,9,0 },
        //                          {6,0,1,0,0,0,4,0,3 }
        //            };
        #endregion

        static void Main(string[] args)
        {
            var rows = sudokuarray.GetLength(0);
            var columns = sudokuarray.GetLength(1);

            #region(Create Lists,rows, columns and fields)
            Sudokulist sl = new Sudokulist();
            for (int i = 1; i <= size; i++)
            {
                sl.Sudokus.Add(new Sudokunumber(i));
                for (int j = 1; j <= size; j++)
                {

                    sl.Sudokus.Find(x => x.Number == i).Rows.Add(new Row(j, rows));
                    sl.Sudokus.Find(x => x.Number == i).Columns.Add(new Column(j, columns));
                    sl.Sudokus.Find(x => x.Number == i).Fields.Add(new Field(j));
                }
            }
            #endregion
            for (int i = 1; i <= size; i++)
            {
                sn = sl.Sudokus.Find(x => x.Number == i);
                uc.UpdateValues(sudokuarray, sn);
            }


            vc.ConsoleSudokuDisplay(sudokuarray);
            Console.ReadLine();
            
            bool solved = false;
            
            solved = uc.Filling(sl, sudokuarray);
            if (solved)
            {
                goto end;
            }
            vc.ConsoleSudokuDisplay(sudokuarray);
            Console.ReadLine();
            for (int i = 1; i <= size; i++)
            {
                sn = sl.Sudokus.Find(x => x.Number == i);
                uc.UpdateValues(sudokuarray, sn);
            }

            Console.WriteLine("no more 100% options");

            //vc.ConsoleSudokuDisplay(sudokuarray);
            //Console.ReadLine();
            for (int i = 1; i <= size; i++)
            {
                sn = sl.Sudokus.Find(x => x.Number == i);
                var arraylist = uc.FillArray2Options(sn, sudokuarray, 2);
                foreach (var item in arraylist)
                {
                    temparraylist.Add(item);
                }
            }

            foreach (var item in temparraylist)
            {
                temparray = new int[size, size];

                for (int h = 0; h < 9; h++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        temparray[k, h] = item[k, h];
                    }
                }
                for (int i = 1; i <= size; i++)
                {
                    sn = sl.Sudokus.Find(x => x.Number == i);
                    uc.UpdateValues(temparray, sn);
                }
                solved = uc.Filling(sl, temparray);
                if (solved)
                {
                    goto end;
                }

                Console.WriteLine("no more 100% options");

                vc.ConsoleSudokuDisplay(temparray);
                Console.ReadLine();
                for (int i = 1; i <= size; i++)
                {
                    sn = sl.Sudokus.Find(x => x.Number == i);
                    var arraylist = uc.FillArray2Options(sn, temparray, 2);
                    foreach (var array in arraylist)
                    {
                        temparraylist2.Add(array);
                    }
                }
                foreach (var array in temparraylist2)
                {
                    temparray = new int[size, size];

                    for (int h = 0; h < 9; h++)
                    {
                        for (int k = 0; k < 9; k++)
                        {
                            temparray[k, h] = array[k, h];
                        }
                    }

                    solved = uc.Filling(sl, temparray);
                    if (solved)
                    {
                        goto end;
                    }
                    //vc.ConsoleSudokuDisplay(temparray);
                    //Console.ReadLine();

                }
            }
            end:
            vc.ConsoleSudokuDisplay(temparray);
            Console.ReadLine();
        }
    }
}

