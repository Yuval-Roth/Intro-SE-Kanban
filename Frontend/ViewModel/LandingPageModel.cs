using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Frontend.ViewModel
{

    public partial class LandingPageModel : Notifier
    {
        public enum Visibility
        {
            Visible,
            Hidden
        }

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

        public LandingPageModel()
        {
            loginButton = new(306, 205, "Login","Visible");
            registerButton = new(306, 205+75, "Register","Visible");
            returnButton = new(306 -100, 205 + 75, "Return", "Hidden");
            emailBox = new("Insert email here", "Hidden");
            passwordBox = new("Insert password here","Hidden");
        }


        public bool LoginClick()
        {
            if (LoginOrRegisterScreen)
            {
                registerButton.Visibility = "Hidden";
                loginButton.Y += 75;
                loginButton.X += 100;
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
            loginButton.Y -=75;
            loginButton.X -= 100;
            returnButton.Visibility = "Hidden";
            registerButton.Visibility = "Visible";
            emailBox = new("Insert email here", "Hidden");
            RaisePropertyChanged("EmailBox");
            passwordBox = new("Insert password here", "Hidden");
            RaisePropertyChanged("PasswordBox");
            LoginOrRegisterScreen = true;
        }
    }
}
