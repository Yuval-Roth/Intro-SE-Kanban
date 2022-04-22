using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace IntroSE.Kanban.Backend.BusinessLayer.Serializable
{
    [Serializable]
    public sealed class User_Serializable
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
