using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using IntroSE.Kanban.Frontend.Model;

namespace IntroSE.Kanban.Frontend.ViewModel
{

    public partial class LandingPageViewModel : Notifier
    {
        private /*static*/ int Height/* = (int)System.Windows.SystemParameters.PrimaryScreenHeight*/;
        private /*static*/ int Width/* = (int)System.Windows.SystemParameters.PrimaryScreenWidth*/;

        private int Login_Button_X/* = Width / 2 - 95*/;
        private int Login_Button_Y/* = Height/2*/;
        private int Register_Button_X/* = Width / 2 - 95*/;
        private int Register_Button_Y/* = Height / 2 + Height / 10*/;
        private int Return_Button_X/* = Width / 2 - 95 - 100*/;
        private int Return_Button_Y/* = Height / 2 + Height / 10*/;

        private int Login_Button_Login_Screen_X/* = Width / 2 - 95 + 100*/;
        private int Login_Button_Login_Screen_Y/* = Height / 2 + Height / 10*/;
        private int Register_Button_Register_Screen_X/* = Width / 2 - 95 + 100*/;
        private int Register_Button_Register_Screen_Y/* = Height / 2 + Height / 10*/;

        private int EmailBox_X/* = Width / 2 -125*/;
        private int EmailBox_Y/* = Height / 2 - Height / 15*/;
        private int PasswordBox_X/* = Width/2 -125 */;
        private int PasswordBox_Y/* = Height/2 - Height / 30*/;
        private int ErrorMessage_X/* = Width / 2 - 125*/;
        private int ErrorMessage_Y/* = Height / 2*/;


        private Button loginButton;
        private Button registerButton;
        private Button returnButton;
        private TextBox emailBox;
        private TextBox passwordBox;
        private bool LoginOrRegisterScreen = true;
        private Label errorMessage;

        public Button LoginButton => loginButton;
        public Button RegisterButton => registerButton;
        public Button ReturnButton => returnButton;
        public TextBox EmailBox => emailBox;
        public TextBox PasswordBox => passwordBox;
        public Label ErrorMessage => errorMessage;
        public string ImageMargin => $"-{Width * 0.15},-{Height * 0.15},-{Width * 0.15},-{Height * 0.15}";

        private LoginRegisterController LRController;

        public LandingPageViewModel()
        {
            
            LRController = new();
            loginButton = new(Login_Button_X,Login_Button_Y,0,0, "Login","Visible");
            registerButton = new(Register_Button_X,Register_Button_Y, 0, 0, "Register","Visible");
            returnButton = new(Return_Button_X,Return_Button_Y, 0, 0, "Return", "Hidden");
            emailBox = new(EmailBox_X, EmailBox_Y,0,0, "Insert email here", "Hidden");
            passwordBox = new(PasswordBox_X, PasswordBox_Y ,0,0, "Insert password here","Hidden");
            emailBox = new(EmailBox_X, EmailBox_Y, 0, 0, "Insert email here", "Hidden");
            passwordBox = new(PasswordBox_X, PasswordBox_Y, 0, 0, "Insert password here","Hidden");
            errorMessage = new(ErrorMessage_X, ErrorMessage_Y, "", "Hidden");
            UpdateMargins(SystemParameters.PrimaryScreenWidth, SystemParameters.PrimaryScreenHeight);
        }

        public void ResetErrorMessage()
        {
            errorMessage.Hide();
            errorMessage.Text = "";
        }

        public bool LoginClick()
        {
            if (LoginOrRegisterScreen)
            {
                registerButton.Hide();
                loginButton.Y = Login_Button_Login_Screen_Y;
                loginButton.X = Login_Button_Login_Screen_X;
                returnButton.Show();
                emailBox.Show();
                passwordBox.Show();
                LoginOrRegisterScreen = false;
                return false;
            }
            else
            {

                Response<string> res = LRController.Login(emailBox.Text,passwordBox.Text);
                if (res.operationState == false)
                {
                    ErrorMessage.Text = res.returnValue;
                    errorMessage.Show();
                    return false;
                }
                ErrorMessage.Text = "Login Successful";
                errorMessage.Show();
                return true;
            }
        }
        public bool RegisterClick()
        {
            if (LoginOrRegisterScreen)
            {
                loginButton.Hide();
                registerButton.X = Register_Button_Register_Screen_X;
                returnButton.Show();
                emailBox.Show();
                passwordBox.Show();
                LoginOrRegisterScreen = false;
                return false;
            }
            else
            {
                Response<string> res = LRController.Register(emailBox.Text, passwordBox.Text);
                if (res.operationState == false)
                {
                    ErrorMessage.Text = res.returnValue;
                    errorMessage.Show();
                    return false;
                }
                ErrorMessage.Text = "Register Successful";
                errorMessage.Show();
                return true;
            }
        }
        public void TextBoxClick(string name)
        {
            switch (name)
            {
                case "EmailBox":
                    if (emailBox.FirstClick)
                    {
                        emailBox.Text = "";
                        emailBox.FirstClick = false;
                    }
                    break;
                case "PasswordBox":
                    if (passwordBox.FirstClick)
                    {
                        passwordBox.Text = "";
                        passwordBox.FirstClick = false;
                    }
                    break;
            }
        }
        public void ReturnToFrontPage()
        {
            ResetErrorMessage();
            loginButton.X = Login_Button_X;
            loginButton.Y = Login_Button_Y;
            registerButton.X = Register_Button_X;

            returnButton.Hide();
            registerButton.Show();
            loginButton.Show();

            emailBox = new(EmailBox_X,EmailBox_Y,0,0,"Insert email here", "Hidden");
            RaisePropertyChanged("EmailBox");

            passwordBox = new(PasswordBox_X, PasswordBox_Y,0,0,"Insert password here", "Hidden");
            RaisePropertyChanged("PasswordBox");

            LoginOrRegisterScreen = true;
        }
        public void UpdateMargins(double ActualWidth, double ActualHeight)
        {
            Height = (int)ActualHeight;
            Width = (int)ActualWidth;
            UpdateSizes();

            if (LoginOrRegisterScreen)
            {
                loginButton.X = Login_Button_X;
                loginButton.Y = Login_Button_Y;
                registerButton.X = Register_Button_X;
                registerButton.Y = Register_Button_Y;
            }
            else
            {
                loginButton.X = Login_Button_Login_Screen_X;
                loginButton.Y = Login_Button_Login_Screen_Y;
                registerButton.X = Register_Button_Register_Screen_X;
                registerButton.Y = Register_Button_Register_Screen_Y;
            }
            returnButton.X = Return_Button_X;
            returnButton.Y = Return_Button_Y;
            emailBox.X = EmailBox_X;
            emailBox.Y = EmailBox_Y;
            passwordBox.X = PasswordBox_X;
            passwordBox.Y = PasswordBox_Y;
            errorMessage.X = ErrorMessage_X;
            errorMessage.Y = ErrorMessage_Y;
        }
        private void UpdateSizes()
        {
            Login_Button_X = Width / 2 - 80;
            Login_Button_Y = Height / 2;
            Register_Button_X = Width / 2 - 80;
            Register_Button_Y = Height / 2 + Height / 10;
            Return_Button_X = Width / 2 - 95 - 100;
            Return_Button_Y = Height / 2 + Height / 10;

            Login_Button_Login_Screen_X = Width / 2 - 95 + 100;
            Login_Button_Login_Screen_Y = Height / 2 + Height / 10;
            Register_Button_Register_Screen_X = Width / 2 - 95 + 100;
            Register_Button_Register_Screen_Y = Height / 2 + Height / 10;

            EmailBox_X = Width / 2 - 125;
            EmailBox_Y = Height / 2 - Height / 10;
            PasswordBox_X = Width / 2 - 125;
            PasswordBox_Y = Height / 2 - Height / 20;

            ErrorMessage_X = Width / 2 - 125;
            ErrorMessage_Y = Height / 2;

    }
    }
   
}
