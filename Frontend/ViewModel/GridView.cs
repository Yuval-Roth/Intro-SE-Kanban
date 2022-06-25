using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Frontend.ViewModel
{
    public class GridView
    {
        private int rows;
        private readonly string[] columns;
        private string[,] table;
        

        public GridView(int rows, params string[] columnNames)
        {
            this.rows = rows;
            columns = columnNames;
            table = new string[rows, columnNames.Length];
        }

        public void SetValue(int row, int column, string value)
        {
            table[row, column] = value; 
        }

        public string GetValue(int row, int column)
        {
            return table[row, column];
        }




    }
}
