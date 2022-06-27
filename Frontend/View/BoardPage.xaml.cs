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
using IntroSE.Kanban.Backend.ServiceLayer;
using IntroSE.Kanban.Backend.Utilities;
using IntroSE.Kanban.Frontend.ViewModel;

namespace IntroSE.Kanban.Frontend.View
{
    /// <summary>
    /// Interaction logic for BoardPage.xaml
    /// </summary>
    public partial class BoardPage : Window
    {
        private string currentUser;
        private BoardPageViewModel VM;
        public BoardPage()
        {
            InitializeComponent();
            VM = new BoardPageViewModel();
            DataContext = VM;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            int output = VM.Submit_Click();
            if (output != -1)
            {
                TaskPage TP = new();
                TP.Initialize(currentUser,output);
                TP.Show();
                Close();
            }
            //VM.Submit_Click();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void ChosenBoard_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            
            VM.ChosenBoard_Click();

        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LandingPage landingPage = new LandingPage();
            landingPage.Show();
            Close();
        }
        public void Initialize(string email)
        {
            currentUser = email;
            VM.Initialize(currentUser);
        }
        
    }
}
