using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IntroSE.Kanban.Frontend.ViewModel;

namespace IntroSE.Kanban.Frontend.View
{
    public partial class Task : Window
    {
        private TaskViewModel VM;
        public Task()
        {
            InitializeComponent();
            VM = new TaskViewModel();
            DataContext = VM;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            VM.LoginClick();
        }
    }
}
