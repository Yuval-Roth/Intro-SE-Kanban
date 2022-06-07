using System.Data.SQLite;
using System.IO;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class SQLExecuter
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Backend\\DataAccessLayer\\SQLExecuter.cs");

        public SQLExecuter() { }

        public bool ExecuteWrite(string query) {

            log.Debug("ExecuteWrite() for: "+query);

            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "kanban.db"));
            SQLiteConnectionStringBuilder connectionBuilder = new()
            {
                DataSource = path
            };

            using (SQLiteConnection connection = new(connectionBuilder.ConnectionString))
            {
                SQLiteCommand command = new(query,connection);
                connection.Open();

                try
                {
                    int affectedRows = command.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        log.Debug("ExecuteWrite() success");
                        return true;
                    }
                    else
                    {
                        log.Error("ExecuteWrite() failed");
                        return false;
                    } 
                }
                finally
                {
                    connection.Close();
                }
            }   
        }
        public SQLiteDataReader ExecuteRead(string query)
        {

            log.Debug("ExecuteRead() for: " + query);

            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "kanban.db"));
            SQLiteConnectionStringBuilder connectionBuilder = new()
            {
                DataSource = path,
                ReadOnly = true
            };


            using (SQLiteConnection connection = new(connectionBuilder.ConnectionString))
            {
                SQLiteCommand command = new(query, connection);
                connection.Open();

                try
                {
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        log.Debug("ExecuteRead() success");
                        return reader;
                    }
                    log.Error("ExecuteRead() failed - fetched 0 rows");
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }

        }
    }
}
