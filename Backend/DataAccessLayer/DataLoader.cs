using System.Collections.Generic;
using System.Data.SQLite;
using System;

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
                LinkedList<object[]> userList = executer.ExecuteRead(userQuery);

                //Instantiate all the users
                foreach(object[] row in userList)
                {
                    usersList.AddLast(new UserDTO()
                    {
                        Email = (string)row[0],
                        Password = (string)row[1],
                        MyBoards = new(),
                        JoinedBoards = new()
                    });
                }

                // Load the owned/joined boards into the users
                foreach (UserDTO user in usersList)
                {
                    // Load MyBoards
                    string boardsQuery = "SELECT BoardId" +
                                         "FROM Boards" +
                                        $"WHERE Owner = '{user.Email}'";
                    LinkedList<object[]> ownedBoardsList = executer.ExecuteRead(boardsQuery);
                    foreach (object[] row in ownedBoardsList)
                    {
                        user.MyBoards.AddLast((int)row[0]);
                    }

                    // Load JoinedBoards
                    boardsQuery = "SELECT BoardId" +
                                  "FROM UserJoinedBoards" +
                                 $"WHERE Email = '{user.Email}'";
                    LinkedList<object[]> joinedBoardsList = executer.ExecuteRead(boardsQuery);
                    foreach (object[] row in joinedBoardsList)
                    {
                        user.MyBoards.AddLast((int)row[0]);
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
                LinkedList<object[]> boardList = executer.ExecuteRead(boardQuery);
                foreach(object[] row in boardList)
                {
                    // Create a new board
                    BoardDTO board = new()
                    {
                        Id = (int)row[0],
                        Title = (string)row[1],
                        Owner = (string)row[2],
                        Joined = new(),
                        BackLog = new(),
                        InProgress = new(),
                        Done = new(),
                        BackLogLimit = (int)row[3],
                        InProgressLimit = (int)row[4],
                        DoneLimit = (int)row[5],
                        TaskIDCounter = (int)row[6]
                    };
                    boardsList.AddLast(board);
                }

                // Load the tasks and joined list into every board
                foreach (BoardDTO board in boardsList)
                {

                    // Load joined list
                    string joinedQuery = "SELECT Email " +
                                         "FROM UserJoinedBoards " +
                                        $"WHERE BoardId = {board.Id}";
                    LinkedList<object[]> joinedList = executer.ExecuteRead(joinedQuery);
                    foreach (object[] row in joinedList)
                    {
                        board.Joined.AddLast((string)row[0]);
                    }

                    // Load tasks
                    string taskQuery = "SELECT * " +
                                       "FROM Tasks " +
                                      $"WHERE BoardId = {board.Id}";
                    LinkedList<object[]> taskList = executer.ExecuteRead(taskQuery);
                    
                    foreach(object[] row in taskList)
                    {
                        TaskDTO task = new()
                        {
                            BoardId = (int)row[0],
                            Id = (int)row[1],
                            Title = (string)row[2],
                            Assignee = (string)row[3],
                            Description = (string)row[4],
                            CreationTime = (DateTime)row[5],
                            DueDate = (DateTime)row[6],
                            State = (BoardColumnNames)row[7]
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
                string query = "SELECT BoardIDCounter FROM GlobalCounters ";
                LinkedList<object[]> list = executer.ExecuteRead(query);
                boardIdCounter = (int)list.First.Value[0];
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
