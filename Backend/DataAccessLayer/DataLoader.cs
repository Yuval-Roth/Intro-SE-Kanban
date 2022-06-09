using System.Collections.Generic;
using System.Data.SQLite;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class DataLoader
    {
        private SQLExecuter executer;
        private LinkedList<UserDTO> usersList;
        private LinkedList<BoardDTO> boardsList;
        private bool dataLoaded = false;
        public void LoadData()
        {
            usersList = new();
            LoadUsers();            
            boardsList = new();
            LoadBoards();

            dataLoaded = true;
        }

        private void LoadUsers()
        {
            string userQuery = "SELECT * FROM Users";
            SQLiteDataReader userReader = executer.ExecuteRead(userQuery);

            while(userReader.Read())
            {
                UserDTO user = new UserDTO()
                {
                    Email = userReader.GetString(0),
                    Password = userReader.GetString(1)
                };
                string joinedQuery = "SELECT * FROM UserJoinedBoards" +
                    $"WHERE Email = '{user.Email}'";

                SQLiteDataReader joinedBoardsReader = executer.ExecuteRead(joinedQuery);

            }         
        }
        
        private void LoadBoards()
        {
            string boardQuery = "SELECT * FROM Boards";
            SQLiteDataReader boardsReader = executer.ExecuteRead(boardQuery);

            while (boardsReader.Read())
            {
                LinkedList<TaskDTO> Backlog = new();
                LinkedList<TaskDTO> Inprogress = new();
                LinkedList<TaskDTO> Done = new();
                string taskQuery = "SELECT * FROM Tasks" +
                $"WHERE BoardId = {boardsReader.GetInt32(0)}";
                SQLiteDataReader taskReader = executer.ExecuteRead(taskQuery);
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
                            Backlog.AddLast(task);
                            break;

                        case BoardColumnNames.Inprogress: 
                            Inprogress.AddLast(task);
                            break;

                        case BoardColumnNames.Done:
                            Done.AddLast(task);
                            break;
                    }
                }
                boardsList.AddLast(new BoardDTO()
                {

                });    
            
            
            }



            

        }
    }
}
