﻿using System;

namespace SudokuApp
{
    class Program
    {
        static PossibilitiesController pc = new PossibilitiesController();
        static ViewController vc = new ViewController();
        static readonly int size = 9;
        #region(Sudoku Array)
        //Very Easy
        public static int[,] sudokuarray =
              {
                    {0,0,7,0,8,0,4,0,9 },
                    {0,5,1,0,0,2,0,6,0 },
                    {8,0,0,3,1,0,7,0,0 },
                    {0,0,0,4,0,8,0,9,0 },
                    {0,6,2,9,0,0,1,0,3 },
                    {3,0,9,6,0,0,5,7,4 },
                    {0,1,0,0,9,0,0,3,0 },
                    {7,0,0,0,0,5,8,0,2 },
                    {6,2,4,0,7,3,0,5,0 }
              };

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
        //                        {5,7,0,0,4,0,0,0,0 },
        //                        {1,0,3,0,0,8,4,0,0 },
        //                        {0,0,0,0,0,0,0,0,5 },
        //                        {0,6,0,0,0,0,0,0,4 },
        //                        {0,9,0,2,1,0,0,5,0 },
        //                        {0,0,0,0,9,3,0,0,0 },
        //                        {0,0,0,8,3,1,2,0,0 },
        //                        {0,0,4,0,0,0,0,0,3 },
        //                        {0,0,0,7,0,0,0,0,6 }
        //          };

        // Hard
        //  public static int[,] sudokuarray =
        //{
        //                          {7,0,9,0,8,5,0,0,1 },
        //                          {0,0,0,0,0,0,0,0,0 },
        //                          {1,0,3,0,0,0,6,0,0 },
        //                          {0,0,0,2,6,0,0,0,0 },
        //                          {0,0,7,0,0,0,0,8,5 },
        //                          {0,0,0,0,0,4,0,3,0 },
        //                          {0,8,4,6,9,0,0,0,0 },
        //                          {3,0,0,0,4,0,0,1,0 },
        //                          {0,0,0,0,5,0,0,0,0 }
        //            };

        // Very Hard
        //  public static int[,] sudokuarray =
        //{
        //                        {4,2,0,7,0,0,0,3,5 },
        //                        {1,0,8,2,0,0,0,0,0 },
        //                        {0,0,0,6,0,0,0,0,1 },
        //                        {3,0,0,1,0,9,0,4,0 },
        //                        {0,0,0,0,4,0,0,2,0 },
        //                        {0,0,9,0,0,7,8,0,6 },
        //                        {0,7,0,8,5,0,0,0,0 },
        //                        {0,0,5,0,0,1,0,9,0 },
        //                        {6,0,1,0,0,0,4,0,3 }
        //          };
        #endregion

        static void Main(string[] args)
        {
            int[,] PossibilityArrayValues;
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

            vc.UpdateValues(rows, columns, sl, sudokuarray);

            vc.ConsoleSudokuDisplay(rows, columns, sudokuarray);
            Console.ReadLine();

            Sudokunumber sn = new Sudokunumber() ;
            int counter = 0;
            bool solved = false;
            int tmpcounter = 0;

            while (!solved)
            {
                do
                {
                    tmpcounter = counter;
                    counter = 0;

                    for (int j = 1; j <= size; j++)
                    {
                        sn = sl.Sudokus.Find(x => x.Number == j);
                        sn.Possibilitiesarray = pc.PossibilityFinder(sudokuarray,sn);
                        PossibilityArrayValues = pc.FillArray1Option(sn, sudokuarray,1);

                        counter = pc.CountPossibilities(PossibilityArrayValues);

                        //vc.ConsoleSudokuDisplay(rows, columns, PossibilityArrayValues);
                        //Console.ReadLine();
                    }
                    vc.UpdateValues(rows, columns, sl, sudokuarray);
                    if (counter == 0)
                    {
                        solved = true;
                    }
                }
                while (counter != tmpcounter && !solved);
                if (counter != 0)
                {
                    Console.WriteLine("no more 100% options");

                    vc.ConsoleSudokuDisplay(rows, columns, sudokuarray);
                    Console.ReadLine();
                    PossibilityArrayValues = pc.FillArray2Options(sn, sudokuarray, 2);
                    

                }
            } 
            vc.ConsoleSudokuDisplay(rows, columns, sudokuarray);
            Console.ReadLine();
        }
    }
}
