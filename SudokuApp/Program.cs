using System;
using System.Text;

namespace SudokuApp
{
    class Program
    {
        static ViewController vc = new ViewController();
        //Very Easy
        //public static int[,] sudokarray =
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
        //public static int[,] sudokarray =
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
        public static int[,] sudokarray =
      {
                            {5,7,0,0,4,0,0,0,0 },
                            {1,0,3,0,0,8,4,0,0 },
                            {0,0,0,0,0,0,0,0,5 },
                            {0,6,0,0,0,0,0,0,4 },
                            {0,9,0,2,1,0,0,5,0 },
                            {0,0,0,0,9,3,0,0,0 },
                            {0,0,0,8,3,1,2,0,0 },
                            {0,0,4,0,0,0,0,0,3 },
                            {0,0,0,7,0,0,0,0,6 }
              };

        // Hard
        //  public static int[,] sudokarray =
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
        //  public static int[,] sudokarray =
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


        static void Main(string[] args)
        {
            int[,] posvalues;
            var rows = sudokarray.GetLength(0);
            var columns = sudokarray.GetLength(1);
            int value;

            #region(Create Lists,rows, columns and fields)
            Sudokulist sl = new Sudokulist();
            for (int i = 0; i < rows; i++)
            {
                sl.Sudokus.Add(new Sudokunumber(i + 1));
                for (int j = 0; j < rows; j++)
                {

                    sl.Sudokus.Find(x => x.number == i + 1).Rows.Add(new Row(j + 1, rows));
                    sl.Sudokus.Find(x => x.number == i + 1).Columns.Add(new Column(j + 1, columns));
                    sl.Sudokus.Find(x => x.number == i + 1).Fields.Add(new Field(j + 1));
                }
            }
            #endregion

            for (int i = 0; i < rows; i++)
                for (int f = 0; f < columns; f++)
                {
                    value = sudokarray[i, f];
                    vc.WriteandAdd(sl, value, i, f, true);
                }



            Console.ReadLine();


            int counter = 1;

            int[,] tmparray = new int[9, 9];
            bool solved = false;
            int tmpcounter = 0;

            while (!solved)
            {
                if (counter != tmpcounter)
                {
                    tmpcounter = counter;
                    counter = 0;

                    tmparray = sudokarray;

                    for (int j = 0; j < 9; j++)
                    {

                        sl.Sudokus.Find(x => x.number == j + 1).PossibilityFinder(sudokarray, sl.Sudokus.Find(x => x.number == j + 1));
                        var possibilitiesarray = sl.Sudokus.Find(x => x.number == j + 1).Possibilitiesarray;
                        sudokarray = sl.Sudokus.Find(x => x.number == j + 1).FillFieldsonRows(sudokarray, possibilitiesarray);
                        sudokarray = sl.Sudokus.Find(x => x.number == j + 1).FillFieldsonColumns(sudokarray, possibilitiesarray);
                        sudokarray = sl.Sudokus.Find(x => x.number == j + 1).FillFieldsonFields(sudokarray, possibilitiesarray);

                        posvalues = possibilitiesarray.Values;

                        for (int i = 0; i < rows; i++)
                            for (int f = 0; f < columns; f++)
                            {
                                value = posvalues[i, f];
                                if (value == 1)
                                {
                                    counter++;
                                }
                                //vc.WriteandAdd(sl, value, i, f, false);
                            }

                        //Console.ReadLine();
                    }

                    if (counter == 0)
                    {
                        solved = true;
                    }
                    for (int i = 0; i < rows; i++)
                        for (int f = 0; f < columns; f++)
                        {

                            value = sudokarray[i, f];
                            if (value > 0)
                            {
                                sl.Sudokus.Find(x => x.number == value).AddValues(value, i, f);
                            }
                            //vc.WriteandAdd(sl, value, i, f, true);
                        }

                    //Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("no more option");

                    for (int i = 0; i < rows; i++)
                        for (int f = 0; f < columns; f++)
                        {
                            value = sudokarray[i, f];
                            vc.WriteandAdd(sl, value, i, f, true);
                        }
                    Console.ReadLine();
                }
            }
            for (int i = 0; i < rows; i++)
                for (int f = 0; f < columns; f++)
                {
                    value = sudokarray[i, f];
                    vc.WriteandAdd(sl, value, i, f, true);
                }

            Console.ReadLine();
        }
    }
}
