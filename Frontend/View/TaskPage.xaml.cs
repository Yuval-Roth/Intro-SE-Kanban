using System.Windows;
using IntroSE.Kanban.Frontend.ViewModel;

namespace IntroSE.Kanban.Frontend.View
{
    public partial class TaskPage : Window
    {

        private string currentUser;
        private TaskViewModel VM;

        public TaskPage()
        {
            InitializeComponent();
            VM = new TaskViewModel();
            DataContext = VM;
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            BoardPage boardPage = new BoardPage();
            boardPage.Initialize(currentUser);
            boardPage.Show();
            Close();
        }
        public void Initialize(string email,int boardId)
        {
            currentUser = email;
            VM.Initialize(currentUser,boardId);
        }
    }
}
