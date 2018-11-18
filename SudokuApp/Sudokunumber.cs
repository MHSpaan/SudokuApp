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
    }
}
