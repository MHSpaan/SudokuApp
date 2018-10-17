using System;

namespace SudokuApp
{
    class Program
    {
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


            var rows = sudokarray.GetLength(0);
            var columns = sudokarray.GetLength(1);
            Sudokulist sl = new Sudokulist();
            int value;
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

            for (int i = 0; i < rows; i++)
                for (int f = 0; f < columns; f++)
                {
                    value = sudokarray[i, f];
                    if (value > 0)
                    {
                        sl.Sudokus.Find(x => x.number == value).AddValues(value, i, f);
                    }
                    if (f != rows - 1)
                    {
                        if (value == 0)
                        {
                            Console.Write(" ");
                        }
                        else
                            Console.Write(sudokarray[i, f]);
                        Console.Write('|');
                    }
                    else
                    {
                        if (value == 0)
                        {
                            Console.Write(" ");
                        }
                        else
                            Console.Write(sudokarray[i, f]);
                        Console.WriteLine();
                    }
                }



            Console.ReadLine();

            // Implement solver number 9
            //sl.Sudokus.Find(x => x.number == 9).Solve(sudokarray, sl.Sudokus.Find(x=>x.number==9));
            sl.Sudokus.Find(x => x.number == 1).Solve(sudokarray, sl.Sudokus.Find(x => x.number == 1));


            sudokarray = sl.Sudokus.Find(x => x.number == 1).Possibilitiesarray.Values;
            for (int i = 0; i < rows; i++)
                for (int f = 0; f < columns; f++)
                {
                    value = sudokarray[i, f];
                    if (value > 0)
                    {
                        sl.Sudokus.Find(x => x.number == value).AddValues(value, i, f);
                    }
                    if (f != rows - 1)
                    {
                        if (value == 0)
                        {
                            Console.Write(" ");
                        }
                        else
                            Console.Write(sudokarray[i, f]);
                        Console.Write('|');
                    }
                    else
                    {
                        if (value == 0)
                        {
                            Console.Write(" ");
                        }
                        else
                            Console.Write(sudokarray[i, f]);
                        Console.WriteLine();
                    }
                }
            Console.ReadLine();
        }
    }
}
