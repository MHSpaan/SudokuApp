using System;

namespace SudokuApp
{
    class Program
    {
        static ViewController vc = new ViewController();
        public static int[,] sudokarray =
            {
                    {7,0,0,0,0,0,2,0,0 },
                    {4,0,2,0,0,0,0,0,3 },
                    {0,0,0,2,0,1,0,0,0 },
                    {3,0,0,1,8,0,0,9,7 },
                    {0,0,9,0,7,0,6,0,0 },
                    {6,5,0,0,3,2,0,0,1 },
                    {0,0,0,4,0,9,0,0,0 },
                    {5,0,0,0,0,0,1,0,6 },
                    {0,0,6,0,0,0,0,0,8 }
                };

        // Step 1
        //    public static int[,] sudokarray =
        //{
        //            {7,0,0,0,0,0,2,0,0 },
        //            {4,0,2,0,0,0,0,0,3 },
        //            {0,0,0,2,0,1,0,0,0 },
        //            {3,2,0,1,8,6,0,9,7 },
        //            {0,0,9,0,7,0,6,3,0 },
        //            {6,5,7,9,3,2,0,0,1 },
        //            {0,0,0,4,6,9,0,0,0 },
        //            {5,9,0,0,0,0,1,0,6 },
        //            {0,0,6,0,0,0,0,0,8 }
        //        };
        // Step 2
        //    public static int[,] sudokarray =
        //{
        //            {7,0,0,0,0,0,2,0,0 },
        //            {4,0,2,0,0,0,0,0,3 },
        //            {9,0,0,2,0,1,0,0,0 },
        //            {3,2,0,1,8,6,5,9,7 },
        //            {0,0,9,0,7,0,6,3,2 },
        //            {6,5,7,9,3,2,0,0,1 },
        //            {0,0,0,4,6,9,0,0,0 },
        //            {5,9,0,0,2,0,1,0,6 },
        //            {0,0,6,0,1,0,9,0,8 }
        //        };
        // Step 3
        //    public static int[,] sudokarray =
        //{
        //            {7,0,0,0,0,0,2,0,9 },
        //            {4,0,2,0,9,0,0,0,3 },
        //            {9,0,0,2,0,1,0,0,0 },
        //            {3,2,4,1,8,6,5,9,7 },
        //            {0,0,9,0,7,0,6,3,2 },
        //            {6,5,7,9,3,2,0,0,1 },
        //            {0,0,0,4,6,9,3,0,0 },
        //            {5,9,0,0,2,0,1,0,6 },
        //            {0,0,6,0,1,0,9,0,8 }
        //        };
        // Step 4
        //    public static int[,] sudokarray =
        //{
        //            {7,0,0,0,0,0,2,0,9 },
        //            {4,0,2,0,9,0,0,0,3 },
        //            {9,0,0,2,0,1,0,0,0 },
        //            {3,2,4,1,8,6,5,9,7 },
        //            {0,0,9,5,7,4,6,3,2 },
        //            {6,5,7,9,3,2,0,0,1 },
        //            {0,7,0,4,6,9,3,0,0 },
        //            {5,9,0,0,2,0,1,4,6 },
        //            {0,4,6,0,1,0,9,0,8 }
        //        };
        // Step 5
        //    public static int[,] sudokarray =
        //{
        //            {7,0,0,0,4,0,2,0,9 },
        //            {4,0,2,0,9,0,0,5,3 },
        //            {9,0,0,2,5,1,0,0,4 },
        //            {3,2,4,1,8,6,5,9,7 },
        //            {0,0,9,5,7,4,6,3,2 },
        //            {6,5,7,9,3,2,4,8,1 },
        //            {0,7,0,4,6,9,3,0,0 },
        //            {5,9,0,0,2,0,1,4,6 },
        //            {0,4,6,0,1,0,9,0,8 }
        //        };
        // Step 6
        //    public static int[,] sudokarray =
        //{
        //            {7,0,5,0,4,0,2,1,9 },
        //            {4,1,2,6,9,0,8,5,3 },
        //            {9,0,0,2,5,1,7,6,4 },
        //            {3,2,4,1,8,6,5,9,7 },
        //            {0,0,9,5,7,4,6,3,2 },
        //            {6,5,7,9,3,2,4,8,1 },
        //            {0,7,0,4,6,9,3,0,4 },
        //            {5,9,0,0,2,0,1,4,6 },
        //            {0,4,6,0,1,0,9,7,8 }
        //        };
        // Step 5
        //    public static int[,] sudokarray =
        //{
        //            {7,6,5,0,4,0,2,1,9 },
        //            {4,1,2,6,9,7,8,5,3 },
        //            {9,0,0,2,5,1,7,6,4 },
        //            {3,2,4,1,8,6,5,9,7 },
        //            {1,8,9,5,7,4,6,3,2 },
        //            {6,5,7,9,3,2,4,8,1 },
        //            {8,7,1,4,6,9,3,2,4 },
        //            {5,9,0,7,2,0,1,4,6 },
        //            {2,4,6,0,1,5,9,7,8 }
        //        };
        // Step 8
        //    public static int[,] sudokarray =
        //{
        //            {7,6,5,0,4,0,2,1,9 },
        //            {4,1,2,6,9,7,8,5,3 },
        //            {9,3,8,2,5,1,7,6,4 },
        //            {3,2,4,1,8,6,5,9,7 },
        //            {1,8,9,5,7,4,6,3,2 },
        //            {6,5,7,9,3,2,4,8,1 },
        //            {8,7,1,4,6,9,3,2,4 },
        //            {5,9,0,7,2,8,1,4,6 },
        //            {2,4,6,3,1,5,9,7,8 }
        //        };
        static void Main(string[] args)
        {
            int[,] posvalues;
            bool possible = true;
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
                    vc.WriteandAdd(sl, value, i, f, possible);
                }



            Console.ReadLine();

            // Implement solver number 9

            int counter = 0;
            while (counter < 10)
            {


                for (int j = 0; j < 9; j++)
                {
                    possible = false;
                    sl.Sudokus.Find(x => x.number == j + 1).PossibilityFinder(sudokarray, sl.Sudokus.Find(x => x.number == j + 1));
                    var possibilitiesarray = sl.Sudokus.Find(x => x.number == j + 1).Possibilitiesarray;
                    sudokarray = sl.Sudokus.Find(x => x.number == j + 1).FillFieldsonRows(sudokarray, possibilitiesarray);
                    sudokarray = sl.Sudokus.Find(x => x.number == j + 1).FillFieldsonColumns(sudokarray, possibilitiesarray);
                    sudokarray = sl.Sudokus.Find(x => x.number == j + 1).FillFieldsonFields(sudokarray, possibilitiesarray);

                    posvalues = possibilitiesarray.Values;

                    // Fill in 100% options

                    for (int i = 0; i < rows; i++)
                        for (int f = 0; f < columns; f++)
                        {
                            value = posvalues[i, f];

                            //vc.WriteandAdd(sl, value, i, f, possible);
                        }

                    //Console.ReadLine();
                }
                for (int i = 0; i < rows; i++)
                    for (int f = 0; f < columns; f++)
                    {
                        value = sudokarray[i, f];
                        vc.WriteandAdd(sl, value, i, f, true);
                    }

                Console.ReadLine();
                counter++;
            }
        }
    }
}
