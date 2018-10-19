using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class Sudokunumber
    {
        public int number { get; set; }
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
            this.number = nr;
        }

        #region(Fill Fields)
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

        #endregion

        public void PossibilityFinder(int[,] array, Sudokunumber number)
        {
            Possibilitiesarray = new Possibilities(number.number);
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
                            if (nr == number.number)
                            {
                                ispresent = true;
                            }
                        }

                        foreach (var nr in number.Columns.Find(x => x.Number == f + 1).Values)
                        {
                            if (nr == number.number)
                            {
                                ispresent = true;
                            }
                        }

                        #region(decide fieldnumber)
                        int fieldnumber;
                        if (f < 3)
                            if (i < 3)
                                fieldnumber =1;
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

                        foreach (var nr in number.Fields.Find(x => x.Number ==fieldnumber).Values)
                        {
                            if (nr == number.number)
                            {
                                ispresent = true;
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
        }
    }

}
