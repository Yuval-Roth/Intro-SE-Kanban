using IntroSE.Kanban.Backend.ServiceLayer;
using IntroSE.Kanban.Backend.Utilities;
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

namespace IntroSE.Kanban.Frontend.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
            DataForFrontend();

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
            gs.AdvanceTask(email, boardName1, 0, 0);
            gs.AdvanceTask(email, boardName1, 0, 0);
            gs.AdvanceTask(email, boardName1, 0, 1);
            CIString boardName2 = "board2";
            gs.AddBoard(email, boardName2);


        }
    }
}
