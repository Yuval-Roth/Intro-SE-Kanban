using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using IntroSE.Kanban.Frontend.Model;

namespace IntroSE.Kanban.Frontend.ViewModel
{

    public partial class LandingPageViewModel : Notifier
    {
        private static int HEIGHT = (int)System.Windows.SystemParameters.PrimaryScreenHeight;
        private static int WIDTH = (int)System.Windows.SystemParameters.PrimaryScreenWidth;

        private int LOGIN_BUTTON_X = WIDTH / 2 - 95;
        private int LOGIN_BUTTON_Y = HEIGHT/2;
        private int REGISTER_BUTTON_X = WIDTH / 2 - 95;
        private int REGISTER_BUTTON_Y = HEIGHT / 2 + HEIGHT / 10;
        private int RETURN_BUTTON_X = WIDTH / 2 - 95 - 100;
        private int RETURN_BUTTON_Y = HEIGHT / 2 + HEIGHT / 10;

        private int LOGIN_BUTTON_LOGIN_SCREEN_X = WIDTH / 2 - 95 + 100;
        private int LOGIN_BUTTON_LOGIN_SCREEN_Y = HEIGHT / 2 + HEIGHT / 10;
        private int REGISTER_BUTTON_REGISTER_SCREEN_X = WIDTH / 2 - 95 + 100;
        private int REGISTER_BUTTON_REGISTER_SCREEN_Y = HEIGHT / 2 + HEIGHT / 10;

        private int EMAILBOX_X = WIDTH / 2 -125;
        private int EMAILBOX_Y = HEIGHT / 2 - HEIGHT / 15;
        private int PASSWORDBOX_X = WIDTH/2 -125 ;
        private int PASSWORDBOX_Y = HEIGHT/2 - HEIGHT / 30;
        private int ERRORMESSAGE_X = WIDTH / 2 - 125;
        private int ERRORMESSAGE_Y = HEIGHT / 2;


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
        public string ImageMargin => $"-{WIDTH * 0.15},-{HEIGHT * 0.15},-{WIDTH * 0.15},-{HEIGHT * 0.15}";

        private LoginRegisterController LRController;

        public LandingPageViewModel()
        {
            LRController = new();
            loginButton = new(LOGIN_BUTTON_X,LOGIN_BUTTON_Y,0,0, "Login","Visible");
            registerButton = new(REGISTER_BUTTON_X,REGISTER_BUTTON_Y, 0, 0, "Register","Visible");
            returnButton = new(RETURN_BUTTON_X,RETURN_BUTTON_Y, 0, 0, "Return", "Hidden");
            emailBox = new(EMAILBOX_X, EMAILBOX_Y,0,0, "Insert email here", "Hidden");
            passwordBox = new(PASSWORDBOX_X, PASSWORDBOX_Y ,0,0, "Insert password here","Hidden");
            emailBox = new(EMAILBOX_X, EMAILBOX_Y, 0, 0, "Insert email here", "Hidden");
            passwordBox = new(PASSWORDBOX_X, PASSWORDBOX_Y, 0, 0, "Insert password here","Hidden");
            errorMessage = new(ERRORMESSAGE_X, ERRORMESSAGE_Y, "", "Hidden");
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
                loginButton.Y = LOGIN_BUTTON_LOGIN_SCREEN_Y;
                loginButton.X = LOGIN_BUTTON_LOGIN_SCREEN_X;
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
                registerButton.X = REGISTER_BUTTON_REGISTER_SCREEN_X;
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
            loginButton.X = LOGIN_BUTTON_X;
            loginButton.Y = LOGIN_BUTTON_Y;
            registerButton.X = REGISTER_BUTTON_X;

            returnButton.Hide();
            registerButton.Show();
            loginButton.Show();

            emailBox = new(EMAILBOX_X,EMAILBOX_Y,0,0,"Insert email here", "Hidden");
            RaisePropertyChanged("EmailBox");

            passwordBox = new(PASSWORDBOX_X, PASSWORDBOX_Y,0,0,"Insert password here", "Hidden");
            RaisePropertyChanged("PasswordBox");

            LoginOrRegisterScreen = true;
        }
        public void UpdateMargins(double ActualWidth, double ActualHeight)
        {
            HEIGHT = (int)ActualHeight;
            WIDTH = (int)ActualWidth;
            UpdateSizes();

            if (LoginOrRegisterScreen)
            {
                loginButton.X = LOGIN_BUTTON_X;
                loginButton.Y = LOGIN_BUTTON_Y;
                registerButton.X = REGISTER_BUTTON_X;
                registerButton.Y = REGISTER_BUTTON_Y;
            }
            else
            {
                loginButton.X = LOGIN_BUTTON_LOGIN_SCREEN_X;
                loginButton.Y = LOGIN_BUTTON_LOGIN_SCREEN_Y;
                registerButton.X = REGISTER_BUTTON_REGISTER_SCREEN_X;
                registerButton.Y = REGISTER_BUTTON_REGISTER_SCREEN_Y;
            }
            returnButton.X = RETURN_BUTTON_X;
            returnButton.Y = RETURN_BUTTON_Y;
            emailBox.X = EMAILBOX_X;
            emailBox.Y = EMAILBOX_Y;
            passwordBox.X = PASSWORDBOX_X;
            passwordBox.Y = PASSWORDBOX_Y;
        }
        private void UpdateSizes()
        {
             LOGIN_BUTTON_X = WIDTH / 2 - 80;
             LOGIN_BUTTON_Y = HEIGHT / 2;
             REGISTER_BUTTON_X = WIDTH / 2 - 80;
             REGISTER_BUTTON_Y = HEIGHT / 2 + HEIGHT / 10;
             RETURN_BUTTON_X = WIDTH / 2 - 95 - 100;
             RETURN_BUTTON_Y = HEIGHT / 2 + HEIGHT / 10;

             LOGIN_BUTTON_LOGIN_SCREEN_X = WIDTH / 2 - 95 + 100;
             LOGIN_BUTTON_LOGIN_SCREEN_Y = HEIGHT / 2 + HEIGHT / 10;
             REGISTER_BUTTON_REGISTER_SCREEN_X = WIDTH / 2 - 95 + 100;
             REGISTER_BUTTON_REGISTER_SCREEN_Y = HEIGHT / 2 + HEIGHT / 10;

             EMAILBOX_X = WIDTH / 2 - 125;
             EMAILBOX_Y = HEIGHT / 2 - HEIGHT / 10;
             PASSWORDBOX_X = WIDTH / 2 - 125;
             PASSWORDBOX_Y = HEIGHT / 2 - HEIGHT / 20;
        }
    }
   
}
