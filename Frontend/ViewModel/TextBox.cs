using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Frontend.ViewModel
{
    public class TextBox:Notifier
    {
        private int x;
        private int y;
        private string text;
        public bool FirstClick;
        private string visibility;
        public TextBox(int x, int y,string text, string visibility)
        {
            this.x = x;
            this.y = y;
            this.text = text;
            this.visibility = visibility;
            FirstClick = true;
        }
        public string Text
        {
            get { return text; }
            set 
            {
                text = value;
                RaisePropertyChanged("Text");
            }
        }
        public string Visibility
        {
            get { return visibility; }
            set
            {
                visibility = value;
                RaisePropertyChanged("Visibility");
            }
        }
        public string Margin => $"{x},{y},0,0";
    }
}
