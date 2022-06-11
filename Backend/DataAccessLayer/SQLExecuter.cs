using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;

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
                    log.Debug($"ExecuteWrite() changed {affectedRows} rows");

                    if (affectedRows > 0) return true;
                    else return false;
                }
                finally
                {
                    connection.Close();
                }
            }   
        }
        public LinkedList<object[]> ExecuteRead(string query)
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
                    LinkedList<object[]> output = new();
                    while (reader.Read())
                    {
                        object[] row = new object[reader.FieldCount];
                        for(int i=0; i< row.Length; i++)
                        { 
                            row[i] = reader.GetValue(i);
                        }
                        output.AddLast(row);
                    }
                    log.Debug($"ExecuteRead() fetched {reader.StepCount} rows");
                    return output;
                }
                finally
                {
                    connection.Close();
                }
            }

        }
    }
}
