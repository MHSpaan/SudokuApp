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

       
    }

}
