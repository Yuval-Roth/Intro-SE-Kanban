
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class SQLExecuter
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Backend\\DataAccessLayer\\SQLExecuter.cs");

        private Queue<string> queue;

        public SQLExecuter() { }
        public bool Execute(string command) 
        {
            queue.Enqueue(command);
            if (queue.Count == 5) 
            {
                log.Fatal("SQL queries are not executing");
                foreach (string query in queue) 
                {
                    log.Fatal("SQL query not executed: "+ query);
                }
            }
            return Execute();
        }
        public bool Execute() {
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "kanban.db"));

            using (SQLiteConnection connection = new("C:\\Users\\Yuval\\source\repos\\BGU-SE-Intro\\2021-2022-kanban-team-25\\Backend\\DataAccessLayer\\Kanban.db"))

                SQLiteCommand command = new()
        }
    }
}
