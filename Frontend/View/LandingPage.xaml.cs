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
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Window
    {
        private LandingPageModel VM;
        public LandingPage()
        {
            InitializeComponent();
            VM = new LandingPageModel();
            DataContext = VM;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            VM.LoginClick();
        }
    }
}
