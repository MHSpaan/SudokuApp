using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class Sudokunumber
    {
        public int Number { get; set; }
        public List<Row> Rows { get; set; }
        public List<Column> Columns { get; set; }
        public List<Field> Fields { get; set; }
        public Possibilities Possibilitiesarray { get; set; }


        public Sudokunumber()
        {
            Rows = new List<Row>();
            Columns = new List<Column>();
            Fields = new List<Field>();
        }
        public Sudokunumber(int nr) : this()
        {
            this.Number = nr;
            Possibilitiesarray = new Possibilities(nr);
        }
        
        public void AddValues(int number, int row, int column)
        {

            Rows.Find(x => x.Number == row + 1).Values[column] = number;
            Columns.Find(x => x.Number == column + 1).Values[row] = number;
            if (column < 3)
                if (row < 3)
                    Fields.Find(x => x.Number == 1).Values[row, column] = number;
                else if (row > 5)
                    Fields.Find(x => x.Number == 7).Values[row - 6, column] = number;
                else
                    Fields.Find(x => x.Number == 4).Values[row - 3, column] = number;

            else if (column > 5)
                if (row < 3)
                    Fields.Find(x => x.Number == 3).Values[row, column - 6] = number;
                else if (row > 5)
                    Fields.Find(x => x.Number == 9).Values[row - 6, column - 6] = number;
                else
                    Fields.Find(x => x.Number == 6).Values[row - 3, column - 6] = number;

            else
                if (row < 3)
                Fields.Find(x => x.Number == 2).Values[row, column - 3] = number;
            else if (row > 5)
                Fields.Find(x => x.Number == 8).Values[row - 6, column - 3] = number;
            else
                Fields.Find(x => x.Number == 5).Values[row - 3, column - 3] = number;
        }

        public List<int[,]> FillFieldsonRows(int[,] array, Possibilities possibilities, int possibillities)
        {
            List<int[,]> sudokuarrays = new List<int[,]>();
            int sum = 0;
            List<int[]> coords = new List<int[]>();
            var value = possibilities.Values;
            for (int i = 0; i < value.GetLength(0); i++)
            {
                coords.Clear();
                for (int j = 0; j < value.GetLength(1); j++)
                {
                    if (value[i, j] == 1)
                    {
                        coords.Add(new int[]{i,j});
                        sum++;
                    }

                }
                if (sum == possibillities)

                {
                    int[,] tmparray = new int[9, 9];
                    int position = 0;
                    foreach (var item in coords)
                    {
                        for (int h = 0; h < 9; h++)
                        {
                            for (int k = 0; k < 9; k++)
                            {
                                tmparray[k,h] = array[k,h];
                            }
                        }
                        if (sum == 1)
                        {
                            array[item[0], item[1]] = possibilities.Number;
                        }
                        else if (sum == 2)
                        {
                            sudokuarrays.Add(tmparray);
                            sudokuarrays[position].SetValue(possibilities.Number, item[0], item[1]);
                            tmparray = new int[9, 9];
                            position++;
                        }
                    }
                }
                sum = 0;
            }
            return sudokuarrays;
            
        }

        public int[,] FillFieldsonColumns(int[,] array, Possibilities possibilities)

        {
            int sum = 0;
            int[] coords = { 0, 0 };
            var value = possibilities.Values;
            for (int i = 0; i < value.GetLength(0); i++)
            {
                for (int j = 0; j < value.GetLength(1); j++)
                {
                    if (value[j, i] == 1)
                    {
                        coords[0] = j;
                        coords[1] = i;
                        sum++;
                    }

                }
                if (sum == 1)
                {
                    array[coords[0], coords[1]] = possibilities.Number;
                    break;
                }
                sum = 0;
            }
            return array;
        }

        public int[,] FillFieldsonFields(int[,] array, Possibilities possibilities)

        {
            int rows = 0;
            int columns = 0;
            int sum = 0;
            int[] coords = { 0, 0 };
            var value = possibilities.Values;
            for (int k = 0; k < 9; k++)
            {
                switch (k)
                {
                    case 0:
                        rows = 0;
                        columns = 0;
                        break;
                    case 1:
                        rows = 0;
                        columns = 3;
                        break;
                    case 2:
                        rows = 0;
                        columns = 6;
                        break;
                    case 3:
                        rows = 3;
                        columns = 0;
                        break;
                    case 4:
                        rows = 3;
                        columns = 3;
                        break;
                    case 5:
                        rows = 3;
                        columns = 6;
                        break;
                    case 6:
                        rows = 6;
                        columns = 0;
                        break;
                    case 7:
                        rows = 6;
                        columns = 3;
                        break;
                    case 8:
                        rows = 6;
                        columns = 6;
                        break;
                }

                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (value[i+rows, j+columns] == 1)
                        {
                            coords[0] = i+rows;
                            coords[1] = j+columns;
                            sum++;
                        }

                    }

                }
                if (sum == 1)
                {
                    array[coords[0], coords[1]] = possibilities.Number;
                    break;
                }
                sum = 0;
            }
            return array;
        }
    }

}
