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

        public Button LoginButton;
        public Button RegisterButton;

        public LandingPageModel()
        {
            LoginButton = new(306,287);
            RegisterButton = new(306, 205);
        }


        public void LoginClick()
        {
            LoginButton.Visibility = "Invisible";
        }
    }
}
