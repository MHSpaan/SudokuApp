using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{

    class Possibilities
    {
        public int Number { get; set; }
        public int[,] Values { get; set; }

        public Possibilities(int nr)
        {
            Values = new int[9, 9];
            Number = nr;
        }

        public List<int[,]> FillFieldsonRows(int[,] array, int possibillities)
        {
            List<int[,]> sudokuarrays = new List<int[,]>();
            int sum = 0;
            List<int[]> coords = new List<int[]>();

            for (int i = 0; i < Values.GetLength(0); i++)
            {
                coords.Clear();
                for (int j = 0; j < Values.GetLength(1); j++)
                {
                    if (Values[i, j] == 1)
                    {
                        coords.Add(new int[] { i, j });
                        sum++;
                    }
                }
                if (sum == possibillities)
                {

                    if (sum == 1)
                    {
                        array[coords[0][0], coords[0][1]] = Number;
                    }
                    else if (sum == 2)
                    {
                        foreach (var item in coords)
                        {
                            int[,] tmparray = new int[9, 9];
                            for (int h = 0; h < 9; h++)
                            {
                                for (int k = 0; k < 9; k++)
                                {
                                    tmparray[k, h] = array[k, h];
                                }
                            }
                            tmparray[item[0], item[1]] = Number;
                            sudokuarrays.Add(tmparray);
                            tmparray = new int[9, 9];
                        }
                    }
                }
                sum = 0;
            }
            return sudokuarrays;

        }

        public List<int[,]> FillFieldsonColumns(int[,] array, int possibillities)
        {
            List<int[,]> sudokuarrays = new List<int[,]>();
            int sum = 0;
            List<int[]> coords = new List<int[]>();
            var value = Values;

            for (int i = 0; i < value.GetLength(0); i++)
            {
                coords.Clear();
                for (int j = 0; j < value.GetLength(1); j++)
                {
                    if (value[j, i] == 1)
                    {
                        coords.Add(new int[] { j, i });
                        sum++;
                    }
                }
                if (sum == possibillities)
                {
                    int[,] tmparray = new int[9, 9];

                    if (sum == 1)
                    {
                        array[coords[0][0], coords[0][1]] = Number;
                    }
                    else if (sum == 2)
                    {
                        foreach (var item in coords)
                        {
                            for (int h = 0; h < 9; h++)
                            {
                                for (int k = 0; k < 9; k++)
                                {
                                    tmparray[k, h] = array[k, h];
                                }
                            }
                            tmparray[item[0], item[1]] = Number;
                            sudokuarrays.Add(tmparray);
                            tmparray = new int[9, 9];
                        }
                    }
                }
                sum = 0;
            }
            return sudokuarrays;
        }

        public int[,] FillFieldsonFields(int[,] array, int possibillities)
        {
            int rows = 0;
            int columns = 0;
            List<int[,]> sudokuarrays = new List<int[,]>();
            int sum = 0;
            List<int[]> coords = new List<int[]>();
            var value = Values;
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
                        if (value[i + rows, j + columns] == 1)
                        {

                            coords.Add(new int[] { i + rows, j + columns });
                            sum++;
                        }
                    }
                }
                if (sum == 1)
                {
                    array[coords[0][0], coords[0][1]] = Number;
                }
                sum = 0;
            }
            return array;
        }
    }
}
