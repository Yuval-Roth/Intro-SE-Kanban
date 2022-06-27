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
    public partial class TaskPage : Window
    {

        private string currentUser;
        private TaskViewModel VM;
        public TaskPage(/*string email, int boardId*/)
        {
            InitializeComponent();
            VM = new TaskViewModel(/*email, boardId*/);
            DataContext = VM;
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            BoardPage boardPage = new BoardPage();
            boardPage.Show();
            this.Close();
        }
        public void Initialize(string email)
        {
            currentUser = email;
            VM.Initialize(currentUser);
        }
    }
}
