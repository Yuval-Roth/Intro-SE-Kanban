using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;
using IntroSE.Kanban.Frontend.Utilities;

namespace IntroSE.Kanban.Frontend.Model
{
    public class LoginRegisterController
    {

        UserService userService;

        public LoginRegisterController()
        {
            ServiceLayerFactory.GetInstance().BackendInitializer.LoadData();
            userService = ServiceLayerFactory.GetInstance().UserService;
        }
        public Utilities.Response<string> Login(string email, string password)
        {
            string json = userService.LogIn(email, password);
            return Utilities.JsonEncoder.BuildFromJson<Utilities.Response<string>>(json);
            
        }
        public Utilities.Response<string> Register(string email, string password)
        {
            string json = userService.Register(email, password);
            return Utilities.JsonEncoder.BuildFromJson<Utilities.Response<string>>(json);
        }
    }
}
