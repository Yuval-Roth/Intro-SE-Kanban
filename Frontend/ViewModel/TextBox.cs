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
        private int width;
        private int height;
        private string text;
        public bool FirstClick;
        private string visibility;
        public TextBox(int x, int y, int width, int height, string text, string visibility)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
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
        public void Show()
        {
            Visibility = "Visible";
        }
        public void Hide()
        {
            Visibility = "Hidden";
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
        public int X
        {
            get { return x; }
            set
            {
                x = value;
                RaisePropertyChanged("Margin");
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                y = value;
                RaisePropertyChanged("Margin");
            }
        }
        public string Margin => $"{x},{y},0,0";
    }
}
