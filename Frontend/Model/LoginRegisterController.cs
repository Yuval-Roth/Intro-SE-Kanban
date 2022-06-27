using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;
using IntroSE.Kanban.Backend.ServiceLayer.Deprecated;
using IntroSE.Kanban.Frontend.Utilities;

namespace IntroSE.Kanban.Frontend.Model
{
    public class LoginRegisterController
    {

        UserService userService;

        public LoginRegisterController()
        {
            GradingService gs = new();
            gs.LoadData();
            userService = ServiceLayerFactory.GetInstance().UserService;
        }
        public Response<string> Login(string email, string password)
        {
            string json = userService.LogIn(email, password);
            return JsonEncoder.BuildFromJson<Response<string>>(json);
            
        }
        public Response<string> Register(string email, string password)
        {
            string json = userService.Register(email, password);
            return JsonEncoder.BuildFromJson<Response<string>>(json);
        }
    }
}
