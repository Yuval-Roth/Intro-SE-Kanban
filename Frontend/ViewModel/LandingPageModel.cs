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

        public Button LoginButton = new(306, 287);
        public Button RegisterButton = new (306, 205);

        public LandingPageModel()
        {
            
        }


        public void LoginClick()
        {
            RegisterButton.Visibility = "Invisible";
            LoginButton.X -= 100;
        }
    }
}
