
namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class UserControllerDTO
    {
        private SQLExecuter executer;

        public UserControllerDTO(SQLExecuter executer)
        {
            this.executer = executer;
        }

        public bool AddUser(string email, string password)
        {
            return executer.ExecuteWrite("INSERT INTO Users (Email,Password) " +
                $"VALUES('{email}','{password}')");
        }
        public bool ChangePassword(string email, string password)
        {
            return executer.ExecuteWrite("UPDATE Users " +
                $"SET Password = '{password}' " +
                $"WHERE Email like '{email}'");
        }
        public bool ChangeEmail(string oldEmail, string newEmail)
        {
            return executer.ExecuteWrite("UPDATE Users " +
                $"SET Email = '{newEmail}' " +
                $"WHERE Email like '{oldEmail}'");
        }
    }
}
