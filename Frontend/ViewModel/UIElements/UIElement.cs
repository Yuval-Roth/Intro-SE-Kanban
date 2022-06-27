using IntroSE.Kanban.Frontend.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Frontend.ViewModel.UIElements
{
    public class UIElement : Notifier
    {
        protected int x;
        protected int y;
        protected int width;
        protected int height;
        protected string visibility;
        protected string content;

        public UIElement(int x, int y, int width, int height, string content, bool visible)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            if (visible) visibility = "Visible";
            else visibility = "Hidden";
            this.content = content;
        }
        public UIElement(int x, int y, int width, int height, string content) : this(x, y, width, height, content, true) { }
        public UIElement(int x, int y, int width, int height, bool visible) : this(x, y, width, height, "", visible) { }
        public UIElement(int x, int y, int width, int height) : this(x, y, width, height, "", true) { }
        public UIElement(int x, int y, string content, bool Visible) : this(x, y, 0, 0, content, Visible) { }
        public UIElement(int x, int y, bool Visible) : this(x, y, 0, 0, "", Visible) { }
        public UIElement(int x, int y, string content) : this(x, y, 0, 0, content, true) { }
        public UIElement(int x, int y) : this(x, y, 0, 0, "", true) { }


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
        public int Width
        {
            get { return width; }
            set
            {
                width = value;
                RaisePropertyChanged("Margin");
            }
        }
        public int Height
        {
            get { return height; }
            set
            {
                height = value;
                RaisePropertyChanged("Margin");
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
        public string Content
        {
            get => content;
            set
            {
                content = value;
                RaisePropertyChanged("Content");
            }
        }
        public string Margin => $"{x},{y},{width},{height}";

    }
}
