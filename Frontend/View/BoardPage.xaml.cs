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
        private BoardPageViewModel VM;
        public BoardPage()
        {
            InitializeComponent();
            DataForFrontend();
            string email = "mail@mail.com";
            VM = new BoardPageViewModel(email);
            DataContext = VM;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            int output = VM.Submit_Click();
            if(output != -1)
            {
                //move to kfir's window with string
            }

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
            this.Close();
        }

        public static void DataForFrontend()
        {
            GradingService gs = new();
            gs.DeleteData();
            CIString email = "mail@mail.com";
            string password = "Password1";
            gs.Register(email, password);
            CIString boardName1 = "board1";
            gs.AddBoard(email, boardName1);
            CIString title1 = "Make an appointment";
            CIString desc1 = "With the mannager";
            DateTime due1 = new DateTime(2023, 06, 15);
            CIString title2 = "Publish the scedual";
            CIString desc2 = "must be quickly";
            DateTime due2 = new DateTime(2023, 06, 15);
            CIString title3 = "Send holidy gifts";
            CIString desc3 = "Flowers";
            DateTime due3 = new DateTime(2023, 06, 15);
            gs.AddTask(email, boardName1, title1, desc1, due1);
            gs.AddTask(email, boardName1, title2, desc2, due2);
            gs.AddTask(email, boardName1, title3, desc3, due3);
            gs.AssignTask(email, boardName1, 0, 0, email);
            gs.AssignTask(email, boardName1, 0, 1, email);
            gs.AssignTask(email, boardName1, 0, 2, email);
            gs.AdvanceTask(email, boardName1, 0, 0);
            gs.AdvanceTask(email, boardName1, 1, 0);
            gs.AdvanceTask(email, boardName1, 0, 1);
            CIString boardName2 = "board2";
            gs.AddBoard(email, boardName2);


        }
    }
}
