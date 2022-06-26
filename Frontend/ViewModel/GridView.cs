using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Frontend.ViewModel
{
    public class GridView : Notifier
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private int rows;
        private readonly string[] columns;
        private string[,] table;
        

        public GridView(int x, int y, int width, int height, int rows, params string[] columnNames)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.rows = rows;
            columns = columnNames;
            table = new string[rows, columnNames.Length];
        }

        public void SetValue(int row, int column, string value)
        {
            table[row, column] = value;
            RaisePropertyChanged("Text");
        }

        public string GetValue(int row, int column)
        {
            return table[row, column];
        }




    }
}
