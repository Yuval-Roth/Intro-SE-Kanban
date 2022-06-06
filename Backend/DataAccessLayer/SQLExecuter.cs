
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class SQLExecuter
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Backend\\DataAccessLayer\\SQLExecuter.cs");

        public SQLExecuter() { }

        public bool ExecuteWrite(string query) {
            throw new NotImplementedException();

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
                        return true;
                    }
                    else return false;
                }
                finally
                {
                    connection.Close();
                }
            }
                
        }
        public object ExecuteRead(string query)
        {
            throw new NotImplementedException();

            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "kanban.db"));
            SQLiteConnectionStringBuilder connectionBuilder = new()
            {
                DataSource = path
            };


            using (SQLiteConnection connection = new(connectionBuilder.ConnectionString))
            {
                SQLiteCommand command = new(query, connection);
                connection.Open();

                try
                {
                    return command.ExecuteReader();
                }
                finally
                {
                    connection.Close();
                }
            }

        }
    }
}
