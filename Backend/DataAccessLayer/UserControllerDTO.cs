
namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class UserControllerDTO
    {
        private SQLExecuter executer;

        public UserControllerDTO(SQLExecuter executer)
        {
            this.executer = executer;
        }

        public bool AddUser(UserDTO user)
        {
            return executer.ExecuteWrite("INSERT INTO Users (Email,Password)" +
                $"VALUES('{user.Email}','{user.Password}')");
        }
        public bool DeleteUser(string email)
        {
            return executer.ExecuteWrite($"DELETE FROM Users WHERE Email= '{email}'");
        }
        public bool ChangePassword(string email, string password)
        {
            return executer.ExecuteWrite("UPDATE Users" +
                $"SET Password = '{password}'" +
                $"WHERE Email = '{email}'");
        }
        public bool ChangeEmail(string oldEmail, string newEmail)
        {
            return executer.ExecuteWrite("UPDATE Users" +
                $"SET Email = '{newEmail}'" +
                $"WHERE Email = '{oldEmail}'");
        }
    }
}
