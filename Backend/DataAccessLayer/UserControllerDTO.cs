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
            executer.Execute("INSERT INTO Users (Email,Password)" +
                $"VALUES({ user.Email},{user.Password})");
            throw new NotImplementedException("No implement yet");
        }
        public bool DeleteUser(string email)
        {
            executer.Execute($"DELETE FROM Users WHERE Email= {email}");
            throw new NotImplementedException("No implement yet");
        }
        public bool ChangePassword(string email, string password)
        {
            executer.Execute("UPDATE Users" +
                $"SET Password = {password}" +
                $"WHERE Email = {email}");
            throw new NotImplementedException("No implement yet");
        }
        public bool ChangeEmail(string oldEmail, string newEmail)
        {
            executer.Execute("UPDATE Users" +
                $"SET Email = {newEmail}" +
                $"WHERE Email = {oldEmail}");
            throw new NotImplementedException("No implement yet");
        }
    }
}
