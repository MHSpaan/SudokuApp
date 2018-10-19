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

        static void Main(string[] args)
        {
            int[,] sudokuarray;
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



            for (int j = 0; j < 9; j++)
            {
                possible = false;
                sl.Sudokus.Find(x => x.number == j + 1).PossibilityFinder(sudokarray, sl.Sudokus.Find(x => x.number == j + 1));
                sudokuarray = sl.Sudokus.Find(x => x.number == j+1).Possibilitiesarray.Values;
                // Fill in 100% options

                for (int i = 0; i < rows; i++)
                    for (int f = 0; f < columns; f++)
                    {
                        value = sudokuarray[i, f];

                        vc.WriteandAdd(sl, value, i, f,possible);
                    }
                Console.ReadLine();
            }
        }
    }
}
