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
            return executer.Execute("INSERT INTO Users (Email,Password)" +
                $"VALUES('{user.Email}','{user.Password}')");
        }
        public bool DeleteUser(string email)
        {
            return executer.Execute($"DELETE FROM Users WHERE Email= '{email}'");
        }
        public bool ChangePassword(string email, string password)
        {
            return executer.Execute("UPDATE Users" +
                $"SET Password = '{password}'" +
                $"WHERE Email = '{email}'");
        }
        public bool ChangeEmail(string oldEmail, string newEmail)
        {
            return executer.Execute("UPDATE Users" +
                $"SET Email = '{newEmail}'" +
                $"WHERE Email = '{oldEmail}'");
        }
    }
}
