using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Frontend.ViewModel
{
    public class TaskViewModel : Notifier
    {

        private Button backButton;
        private string email = "";
        private string password = "";
        private bool LoginOrRegisterScreen = true;

        public TaskViewModel()
        {
            backButton = new(306, 205, "Back", "Visible");
        }


        public void ReturnClick()
        {
            if (LoginOrRegisterScreen)
            {
                LoginOrRegisterScreen = false;
            }
            else
            {

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

        public Button BackButton => backButton;
    }
}
