using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Frontend.ViewModel
{
    public class LandingPageModel : Notifier
    {

        private Button loginButton;
        private Button registerButton;
        private TextBox emailBox;
        private TextBox passwordBox;
        private bool LoginOrRegisterScreen = true;

        public Button LoginButton => loginButton;
        public Button RegisterButton => registerButton;
        public TextBox EmailBox => emailBox;
        public TextBox PasswordBox => passwordBox;

        public LandingPageModel()
        {
            loginButton = new(306, 205, "Login");
            registerButton = new(306, 287, "Register");
            emailBox = new("Insert email here");
            passwordBox = new("Insert password here");
        }


        public bool LoginClick()
        {
            if (LoginOrRegisterScreen)
            {
                registerButton.Visibility = "Hidden";
                loginButton.Y += 50;
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
                    if(emailBox.FirstClick)
                        emailBox.Text = "";
                    break;
                case "PasswordBox":
                    if(passwordBox.FirstClick)
                        passwordBox.Text = "";
                    break;
            }
        }
    }
}
