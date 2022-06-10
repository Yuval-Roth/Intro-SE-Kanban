using System.Data.SQLite;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class DatabaseNuker
    {
        private SQLExecuter executer;

        public DatabaseNuker()
        {
            executer = DataAccessLayerFactory.GetInstance().SQLExecuter;
        }

        public void Nuke()
        {
            string[] tables = { "Users", "Boards","UserJoinedBoards","Tasks"};
            foreach (string table in tables)
            {
                executer.ExecuteWrite($"DELETE FROM {table}");
            }
            executer.ExecuteWrite($"UPDATE GlobalCounters SET BoardIDCounter = 0");
        }
    }
}
