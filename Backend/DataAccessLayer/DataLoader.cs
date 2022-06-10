using System.Collections.Generic;
using System.Data.SQLite;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class DataLoader
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Backend\\DataAccessLayer\\SQLExecuter.cs");

        private SQLExecuter executer;
        private LinkedList<UserDTO> usersList;
        private LinkedList<BoardDTO> boardsList;
        private int boardIdCounter;

        public DataLoader(SQLExecuter executer) 
        {
            this.executer = executer;
            usersList = new();
            boardsList = new();
        }

        public void LoadData()
        {
            LoadUsers();            
            LoadBoards();
            LoadBoardIdCounter();
        }

        public LinkedList<UserDTO> UsersList => usersList;
        public LinkedList<BoardDTO> BoardsList => boardsList;
        public int BoardIdCounter => boardIdCounter;


        private void LoadUsers()
        {
            log.Debug("LoadUsers() Initiated");
            try
            {
                // Load everything from users table
                string userQuery = "SELECT * FROM Users";
                using (SQLiteDataReader userReader = executer.ExecuteRead(userQuery))
                {
                    //Instantiate all the users
                    while (userReader.Read())
                    {
                        usersList.AddLast(new UserDTO()
                        {
                            Email = userReader.GetString(0),
                            Password = userReader.GetString(1),
                            MyBoards = new(),
                            JoinedBoards = new()
                        });
                    }
                }

                // Load the owned/joined boards into the users
                foreach (UserDTO user in usersList)
                {
                    // Load MyBoards
                    string boardsQuery = "SELECT BoardId" +
                                         "FROM Boards" +
                                        $"WHERE Owner = '{user.Email}'";
                    using (SQLiteDataReader boardsReader = executer.ExecuteRead(boardsQuery))
                    {
                        while (boardsReader.Read())
                        {
                            user.MyBoards.AddLast(boardsReader.GetInt32(0));
                        }
                    }

                    // Load JoinedBoards
                    boardsQuery = "SELECT BoardId" +
                                  "FROM UserJoinedBoards" +
                                 $"WHERE Email = '{user.Email}'";
                    using (SQLiteDataReader boardsReader = executer.ExecuteRead(boardsQuery))
                    {
                        while (boardsReader.Read())
                        {
                            user.JoinedBoards.AddLast(boardsReader.GetInt32(0));
                        }
                    }
                }
                log.Debug("LoadUsers() success");
            }
            catch (SQLiteException e)
            {
                log.Error(e.Message);
                throw;
            }           
        }

        private void LoadBoards()
        {

            log.Debug("LoadBoards() Initiated");
            try
            {
                //Instantiate all the boards
                string boardQuery = "SELECT * FROM Boards";
                using (SQLiteDataReader boardsReader = executer.ExecuteRead(boardQuery))
                {
                    while (boardsReader.Read())
                    {
                        // Create a new board
                        BoardDTO board = new()
                        {
                            Id = boardsReader.GetInt32(0),
                            Title = boardsReader.GetString(1),
                            Owner = boardsReader.GetString(2),
                            Joined = new(),
                            BackLog = new(),
                            InProgress = new(),
                            Done = new(),
                            BackLogLimit = boardsReader.GetInt32(3),
                            InProgressLimit = boardsReader.GetInt32(4),
                            DoneLimit = boardsReader.GetInt32(5),
                            TaskIDCounter = boardsReader.GetInt32(6)
                        };
                        boardsList.AddLast(board);
                    }
                }

                // Load the tasks and joined list into every board
                foreach (BoardDTO board in boardsList)
                {

                    // Load joined list
                    string joinedQuery = "SELECT Email" +
                                         "FROM UserJoinedBoards" +
                                        $"WHERE BoardId = {board.Id}";
                    using (SQLiteDataReader joinedReader = executer.ExecuteRead(joinedQuery))
                    {
                        while (joinedReader.Read())
                        {
                            board.Joined.AddLast(joinedReader.GetString(0));
                        }
                    }

                    // Load tasks
                    string taskQuery = "SELECT *" +
                                       "FROM Tasks" +
                                      $"WHERE BoardId = {board.Id}";
                    using (SQLiteDataReader taskReader = executer.ExecuteRead(taskQuery))
                    {
                        while (taskReader.Read())
                        {
                            TaskDTO task = new()
                            {
                                Id = taskReader.GetInt32(1),
                                Title = taskReader.GetString(2),
                                Assignee = taskReader.GetString(3),
                                Description = taskReader.GetString(4),
                                CreationTime = taskReader.GetDateTime(5),
                                DueDate = taskReader.GetDateTime(6),
                                State = (BoardColumnNames)taskReader.GetValue(7)
                            };
                            switch (task.State)
                            {
                                case BoardColumnNames.Backlog:
                                    board.BackLog.AddLast(task);
                                    break;

                                case BoardColumnNames.Inprogress:
                                    board.InProgress.AddLast(task);
                                    break;

                                case BoardColumnNames.Done:
                                    board.Done.AddLast(task);
                                    break;
                            }
                        }
                    }
                }
                log.Debug("LoadBoards() success");
            }
            catch (SQLiteException e)
            {
                log.Error(e.Message);
                throw;
            }   
        }
        private void LoadBoardIdCounter()
        {
            log.Debug("LoadBoardIdCounter() initiated");
            try
            {
                string query = "SELECT Counter FROM BoardIDCounter ";
                using (SQLiteDataReader reader = executer.ExecuteRead(query))
                {
                    reader.Read();
                    boardIdCounter = reader.GetInt32(0);
                }
            }
            catch (SQLiteException e) 
            {
                log.Error(e.Message);
                throw;
            }
            log.Debug("LoadBoardIdCounter() success");
        }
    }
}
