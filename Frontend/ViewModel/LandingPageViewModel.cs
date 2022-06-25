using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Frontend.ViewModel
{

    public partial class LandingPageViewModel : Notifier
    {
        private static readonly int HEIGHT = (int)System.Windows.SystemParameters.PrimaryScreenHeight;
        private static readonly int WIDTH = (int)System.Windows.SystemParameters.PrimaryScreenWidth;

        private readonly int LOGIN_BUTTON_X = WIDTH / 2 - 80;
        private readonly int LOGIN_BUTTON_Y = HEIGHT/2;
        private readonly int REGISTER_BUTTON_X = WIDTH / 2 - 80;
        private readonly int REGISTER_BUTTON_Y = HEIGHT / 2 + HEIGHT / 10;
        private readonly int RETURN_BUTTON_X = WIDTH / 2 - 80 - 100;
        private readonly int RETURN_BUTTON_Y = HEIGHT / 2 + HEIGHT / 10;

        private readonly int LOGIN_BUTTON_LOGIN_SCREEN_X = WIDTH / 2 - 80 + 100;
        private readonly int LOGIN_BUTTON_LOGIN_SCREEN_Y = HEIGHT / 2 + HEIGHT / 10;
        private readonly int REGISTER_BUTTON_REGISTER_SCREEN_X = WIDTH / 2 - 80 + 100;

        private readonly int EMAILBOX_X = WIDTH / 2 -80;
        private readonly int EMAILBOX_Y = HEIGHT / 2 - HEIGHT / 10;
        private readonly int PASSWORDBOX_X = WIDTH/2 -80 ;
        private readonly int PASSWORDBOX_Y = HEIGHT/2;


        private Button loginButton;
        private Button registerButton;
        private Button returnButton;
        private TextBox emailBox;
        private TextBox passwordBox;
        private bool LoginOrRegisterScreen = true;

        public Button LoginButton => loginButton;
        public Button RegisterButton => registerButton;
        public Button ReturnButton => returnButton;
        public TextBox EmailBox => emailBox;
        public TextBox PasswordBox => passwordBox;

        public LandingPageViewModel()
        {
            loginButton = new(LOGIN_BUTTON_X,LOGIN_BUTTON_Y, "Login","Visible");
            registerButton = new(REGISTER_BUTTON_X,REGISTER_BUTTON_Y, "Register","Visible");
            returnButton = new(RETURN_BUTTON_X,RETURN_BUTTON_Y, "Return", "Hidden");
            emailBox = new(EMAILBOX_X, EMAILBOX_Y, "Insert email here", "Hidden");
            passwordBox = new(PASSWORDBOX_X, PASSWORDBOX_Y, "Insert password here","Hidden");
        }


        public bool LoginClick()
        {
            if (LoginOrRegisterScreen)
            {
                registerButton.Visibility = "Hidden";
                loginButton.Y = LOGIN_BUTTON_LOGIN_SCREEN_Y;
                loginButton.X = LOGIN_BUTTON_LOGIN_SCREEN_X;
                returnButton.Visibility = "Visible";
                emailBox.Visibility = "Visible";
                passwordBox.Visibility = "Visible";
                LoginOrRegisterScreen = false;
                return false;
            }
            else
            {

                return true;
            }
        }
        public bool RegisterClick()
        {
            if (LoginOrRegisterScreen)
            {
                loginButton.Visibility = "Hidden";
                registerButton.X = REGISTER_BUTTON_REGISTER_SCREEN_X;
                returnButton.Visibility = "Visible";
                emailBox.Visibility = "Visible";
                passwordBox.Visibility = "Visible";
                LoginOrRegisterScreen = false;
                return false;
            }
            else
            {

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
            loginButton.X = LOGIN_BUTTON_X;
            loginButton.Y = LOGIN_BUTTON_Y;
            registerButton.X = REGISTER_BUTTON_X;

            returnButton.Visibility = "Hidden";
            registerButton.Visibility = "Visible";
            loginButton.Visibility = "Visible";

            emailBox = new(EMAILBOX_X,EMAILBOX_Y,"Insert email here", "Hidden");
            RaisePropertyChanged("EmailBox");

            passwordBox = new(PASSWORDBOX_X, PASSWORDBOX_Y,"Insert password here", "Hidden");
            RaisePropertyChanged("PasswordBox");

            LoginOrRegisterScreen = true;
        }
        public string ImageMargin => $"-{WIDTH * 0.15},-{HEIGHT * 0.15},-{WIDTH * 0.15},-{HEIGHT * 0.15}";
        //public void UpdateMargins()
        //{
        //    if (LoginOrRegisterScreen)
        //    {
        //        loginButton.X = LOGIN_BUTTON_X;
        //        loginButton.Y = LOGIN_BUTTON_Y;
        //        registerButton.X = REGISTER_BUTTON_X;
        //        registerButton.Y = REGISTER_BUTTON_Y;
        //    }
        //    else
        //    {
        //        loginButton.X = LOGIN_BUTTON_LOGIN_SCREEN_X;
        //        loginButton.Y = LOGIN_BUTTON_LOGIN_SCREEN_Y;
        //        registerButton.X = REGISTER_BUTTON_REGISTER_SCREEN_X;
        //        registerButton.Y = REGISTER_BUTTON_REGISTER_SCREEN_Y;
        //    }
        //        returnButton.X = RETURN_BUTTON_X;
        //        returnButton.Y = RETURN_BUTTON_Y;
        //}
    }
   
}
