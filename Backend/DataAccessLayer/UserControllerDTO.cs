using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class UserControllerDTO
    {
        private SQLExecuter executer;

        public bool AddUser(UserDTO user)
        {
            throw new NotImplementedException("No implement yet");
        }
        public bool DeleteUser(string email)
        {
            throw new NotImplementedException("No implement yet");
        }
        public bool ChangePassword(string email, string password)
        {
            throw new NotImplementedException("No implement yet");
        }
        public bool ChangeEmail(string oldEmail, string newEmail)
        {
            throw new NotImplementedException("No implement yet");
        }
    }
}
