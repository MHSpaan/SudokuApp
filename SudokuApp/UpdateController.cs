using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp
{
    class UpdateController
    {
        static Stopwatch sw = new Stopwatch();
        ViewController vc = new ViewController();

        public List<int[,]> FillFieldsonRows(Sudokunumber sn, int[,] array, int possibillities)
        {
            List<int[,]> sudokuarrays = new List<int[,]>();
            int sum = 0;
            var Values = sn.Possibilitiesarray.Values;
            var Number = sn.Number;
            List<int[]> coords = new List<int[]>();

            for (int i = 0; i < Values.GetLength(0); i++)
            {
                Values = sn.Possibilitiesarray.Values;
                //vc.ConsoleSudokuDisplay(Values);
                //Console.ReadLine();
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
                        UpdateValues(array, sn);
                        PossibilityFinder(array, sn);
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

        public List<int[,]> FillFieldsonColumns(Sudokunumber sn, int[,] array, int possibillities)
        {
            List<int[,]> sudokuarrays = new List<int[,]>();
            int sum = 0;
            List<int[]> coords = new List<int[]>();
            var Values = sn.Possibilitiesarray.Values;
            var Number = sn.Number;

            for (int i = 0; i < Values.GetLength(0); i++)
            {
                Values = sn.Possibilitiesarray.Values;
                //vc.ConsoleSudokuDisplay(Values);
                //Console.ReadLine();
                coords.Clear();
                for (int j = 0; j < Values.GetLength(1); j++)
                {
                    if (Values[j, i] == 1)
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
                                    UpdateValues(array, sn);
                                    PossibilityFinder(array, sn);
                                }
                            }
                            tmparray[item[0], item[1]] = Number;
                            sudokuarrays.Add(tmparray);
                            tmparray = new int[9, 9];
                        }
                    }
                }
                UpdateValues(array, sn);
                PossibilityFinder(array, sn);
                sum = 0;
            }
            return sudokuarrays;
        }

        public List<int[,]> FillFieldsonFields(Sudokunumber sn, int[,] array, int possibillities)
        {
            int rows = 0;
            int columns = 0;
            List<int[,]> sudokuarrays = new List<int[,]>();
            int sum = 0;
            List<int[]> coords = new List<int[]>();
            var Values = sn.Possibilitiesarray.Values;
            var Number = sn.Number;

            for (int k = 0; k < 9; k++)
            {
                sum = 0;
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

                Values = sn.Possibilitiesarray.Values;
                //vc.ConsoleSudokuDisplay(Values);
                //Console.ReadLine();
                coords.Clear();
                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (Values[i + rows, j + columns] == 1)
                        {

                            coords.Add(new int[] { i + rows, j + columns });
                            sum++;
                        }
                    }
                }
                if (sum == possibillities)
                {
                    if (sum == 1)
                    {
                        array[coords[0][0], coords[0][1]] = Number;
                        UpdateValues(array, sn);
                        PossibilityFinder(array, sn);
                    }
                    else if (sum == 2)
                    {
                        int[,] tmparray = new int[9, 9];
                        foreach (var item in coords)
                        {
                            for (int h = 0; h < 9; h++)
                            {
                                for (int d = 0; d < 9; d++)
                                {
                                    tmparray[d, h] = array[d, h];
                                    UpdateValues(array, sn);
                                    PossibilityFinder(array, sn);
                                }
                            }
                            tmparray[item[0], item[1]] = Number;
                            sudokuarrays.Add(tmparray);
                            tmparray = new int[9, 9];
                        }

                    }
                    sum = 0;
                }
            }
            return sudokuarrays;
        }

        internal bool FillingSudokuLoop(Sudokulist sl, int[,] sudokuarray)
        {
            var counter = 0;
            var checkcounter = 0;
            do
            {
                checkcounter = counter;
                counter = 0;

                for (int j = 1; j <= sudokuarray.GetLength(0); j++)
                {

                    var sn = sl.Sudokus.Find(x => x.Number == j);
                    PossibilityFinder(sudokuarray, sn);
                    FillArray1Option(sn, sudokuarray, 1);


                    UpdateValues(sudokuarray, sn);
                }
                counter = CountZeros(sudokuarray);
                if (counter == 0)
                {
                    return true;
                }
            }
            while (counter != checkcounter && counter > 0);
            return false;
        }

        internal void UpdateValues(int[,] sudokuarray, Sudokunumber sn)
        {
            for (int i = 0; i < sudokuarray.GetLength(0); i++)
                for (int f = 0; f < sudokuarray.GetLength(1); f++)
                {
                    int value = sudokuarray[i, f];
                    if (value > 0)
                    {
                        AddValues(sn, value, i, f);
                    }

                }
        }

        public void AddValues(Sudokunumber sn, int number, int row, int column)
        {

            sn.Rows.Find(x => x.Number == row + 1).Values[column] = number;
            sn.Columns.Find(x => x.Number == column + 1).Values[row] = number;
            if (column < 3)
                if (row < 3)
                    sn.Fields.Find(x => x.Number == 1).Values[row, column] = number;
                else if (row > 5)
                    sn.Fields.Find(x => x.Number == 7).Values[row - 6, column] = number;
                else
                    sn.Fields.Find(x => x.Number == 4).Values[row - 3, column] = number;

            else if (column > 5)
                if (row < 3)
                    sn.Fields.Find(x => x.Number == 3).Values[row, column - 6] = number;
                else if (row > 5)
                    sn.Fields.Find(x => x.Number == 9).Values[row - 6, column - 6] = number;
                else
                    sn.Fields.Find(x => x.Number == 6).Values[row - 3, column - 6] = number;

            else
                if (row < 3)
                sn.Fields.Find(x => x.Number == 2).Values[row, column - 3] = number;
            else if (row > 5)
                sn.Fields.Find(x => x.Number == 8).Values[row - 6, column - 3] = number;
            else
                sn.Fields.Find(x => x.Number == 5).Values[row - 3, column - 3] = number;
        }

        public void PossibilityFinder(int[,] array, Sudokunumber number)
        {
            Possibilities Possibilitiesarray = new Possibilities(number.Number);
            var row = array.GetLength(0);
            var column = array.GetLength(1);
            for (int i = 0; i < row; i++)
                for (int f = 0; f < column; f++)
                {
                    if (array[i, f] > 0)
                    {
                        Possibilitiesarray.Values[i, f] = 0;
                    }
                    else
                    {

                        bool ispresent = false;
                        foreach (var nr in number.Rows.Find(x => x.Number == i + 1).Values)
                        {
                            if (nr == number.Number)
                            {
                                ispresent = true;
                                break;
                            }
                        }

                        if (!ispresent)
                        {
                            foreach (var nr in number.Columns.Find(x => x.Number == f + 1).Values)
                            {
                                if (nr == number.Number)
                                {
                                    ispresent = true;
                                    break;
                                }
                            }
                            if (!ispresent)
                            {
                                #region(decide fieldnumber)
                                int fieldnumber;
                                if (f < 3)
                                    if (i < 3)
                                        fieldnumber = 1;
                                    else if (i > 5)
                                        fieldnumber = 7;
                                    else
                                        fieldnumber = 4;

                                else if (f > 5)
                                    if (i < 3)
                                        fieldnumber = 3;
                                    else if (i > 5)
                                        fieldnumber = 9;
                                    else
                                        fieldnumber = 6;

                                else
                                    if (i < 3)
                                    fieldnumber = 2;
                                else if (i > 5)
                                    fieldnumber = 8;
                                else
                                    fieldnumber = 5;
                                #endregion

                                foreach (var nr in number.Fields.Find(x => x.Number == fieldnumber).Values)
                                {
                                    if (nr == number.Number)
                                    {
                                        ispresent = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (ispresent)
                        {
                            Possibilitiesarray.Values[i, f] = 0;
                        }
                        else
                        {
                            Possibilitiesarray.Values[i, f] = 1;
                        }

                    }
                }
            number.Possibilitiesarray = Possibilitiesarray;
        }

        internal void FillArray1Option(Sudokunumber sn, int[,] sudokuarray, int possibillities)
        {
            var possibilitiesarray = sn.Possibilitiesarray;
            FillFieldsonRows(sn, sudokuarray, possibillities);
            FillFieldsonColumns(sn, sudokuarray, possibillities);
            FillFieldsonFields(sn, sudokuarray, possibillities);
        }

        internal void FillArray2Options(OutcomeList outcomelist, Sudokunumber sn, int[,] sudokuarray, int possibillities)
        {
            List<int[,]> sudokuarrays = new List<int[,]>();
            var possibilitiesarray = sn.Possibilitiesarray;
            List<int[,]> sudokus = new List<int[,]>();
            sudokus = FillFieldsonRows(sn, sudokuarray, possibillities);
            foreach (var item in sudokus)
            {
                OutcomeList outcomes = new OutcomeList(item);
                outcomelist.OutcomesList.Add(outcomes);
            }
            sudokus = FillFieldsonColumns(sn, sudokuarray, possibillities);
            foreach (var item in sudokus)
            {
                OutcomeList outcomes = new OutcomeList(item);
                outcomelist.OutcomesList.Add(outcomes);
            }
            sudokus = FillFieldsonFields(sn, sudokuarray, possibillities);
            foreach (var item in sudokus)
            {
                OutcomeList outcomes = new OutcomeList(item);
                outcomelist.OutcomesList.Add(outcomes);
            }
        }

        internal int CountZeros(int[,] array)
        {
            int checker = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i,j] == 0)
                    {
                        checker++;
                    }
                }

            }
            return checker;
        }

        internal int[,] fillnewarray(int[,] array)
        {
            var temparray = new int[9,9];
            for (int h = 0; h < 9; h++)
            {
                for (int k = 0; k < 9; k++)
                {
                    temparray[k, h] = array[k, h];
                }
            }
            return temparray;
        }

        internal void Filling(OutcomeList arraylists)
        {
            var size = arraylists.Outcomes.GetLength(0);
            Sudokunumber sn = new Sudokunumber();
            var checkcounter = 0;
            var counter = 0;
            do
            {
                checkcounter = counter;
                counter = 0;
                CreateList(arraylists);
                for (int j = 1; j <= size; j++)
                {
                    sn = arraylists.Sudokulist.Sudokus.Find(x => x.Number == j);
                    UpdateValues(arraylists.Outcomes, sn);

                    sn = arraylists.Sudokulist.Sudokus.Find(x => x.Number == j);
                    PossibilityFinder(arraylists.Outcomes, sn);
                    var asda = sn.Possibilitiesarray;
                    FillArray1Option(sn, arraylists.Outcomes, 1);


                    UpdateValues(arraylists.Outcomes, sn);

                }
                counter = CountZeros(arraylists.Outcomes);

            }
            while (counter != checkcounter && counter > 0);
            if (counter == 0)
            {
                arraylists.Solved = true;
                arraylists.Dispose();
            }
            else
            {
                arraylists.Solved = false;
                for (int i = 1; i <= size; i++)
                {
                    sn = arraylists.Sudokulist.Sudokus.Find(x => x.Number == i);
                    UpdateValues(arraylists.Outcomes, sn);
                    FillArray2Options(arraylists, sn, arraylists.Outcomes, 2);
                }
            }

        }


        internal void CreateList(OutcomeList arraylists)
        {
            var size = arraylists.Outcomes.GetLength(0);
            Sudokulist sl = new Sudokulist();
            for (int i = 1; i <= size; i++)
            {
                sl.Sudokus.Add(new Sudokunumber(i));
                for (int j = 1; j <= size; j++)
                {

                    sl.Sudokus.Find(x => x.Number == i).Rows.Add(new Row(j, size));
                    sl.Sudokus.Find(x => x.Number == i).Columns.Add(new Column(j, size));
                    sl.Sudokus.Find(x => x.Number == i).Fields.Add(new Field(j));
                }
            }
            arraylists.Sudokulist = sl;

        }
    }
}
