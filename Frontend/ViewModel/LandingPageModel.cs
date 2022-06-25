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
        private string email = "";
        private string password = "";
        private bool LoginOrRegisterScreen = true;

        public LandingPageModel()
        {
            loginButton = new(306, 205, "Login");
            registerButton = new(306, 287, "Register");
        }


        public bool LoginClick()
        {
            if (LoginOrRegisterScreen)
            {
                registerButton.Visibility = "Hidden";
                loginButton.Y += 50;
                LoginOrRegisterScreen = false;
                return false;
            }
            else
            {

                return true;
            }
        }
        public string Email
        {
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
            get { return email; }
        }
        public string Password
        {
            set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
            get { return password; }
        }

        public Button LoginButton => loginButton;
        public Button RegisterButton => registerButton;
    }
}
