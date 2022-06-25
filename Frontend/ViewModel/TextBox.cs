using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Frontend.ViewModel
{
    public class TextBox:Notifier
    {
        private string text;
        public bool FirstClick;
        private string visibility;
        public TextBox(string text, string visibility)
        {
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
    }
}
