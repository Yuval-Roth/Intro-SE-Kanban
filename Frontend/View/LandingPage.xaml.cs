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
using System.Windows.Navigation;
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
        private NavigationService nav;
        public LandingPage()
        {
            InitializeComponent();
            VM = new LandingPageModel();
            DataContext = VM;
            nav = NavigationService.GetNavigationService(this);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (VM.LoginClick())
            {
                //Uri uri = new Uri("Window1.xaml", UriKind.RelativeOrAbsolute);
                //nav.Navigate(uri);
            }
            
        }

        private void TextBox_ButtonDown(object sender, MouseButtonEventArgs e)
        {
            VM.TextBoxClick(((System.Windows.Controls.TextBox)sender).Name);
        }
    }
}
