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
        private LandingPageViewModel VM;
        public LandingPage()
        {
            InitializeComponent();
            VM = new LandingPageViewModel();
            DataContext = VM;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (VM.LoginClick())
            {
                // TO DO: Login successful
            }

        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (VM.RegisterClick())
            {
                // TO DO: Registration successful
            }

        }

        private void TextBox_ButtonDown(object sender, MouseButtonEventArgs e)
        {
            VM.TextBoxClick(((System.Windows.Controls.TextBox)sender).Name);
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            VM.ReturnToFrontPage();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            VM.UpdateMargins(ActualWidth,ActualHeight);
        }

        private void TextBoxes_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            VM.ResetErrorMessage();
        }

        private void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            VM.TextBoxClick(((System.Windows.Controls.TextBox)sender).Name);
        }
    }
}
