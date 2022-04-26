using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    public class BoardsService
    {
        private UserData userData;
        private BusinessLayer.BoardController boardController;

        public BoardsService(BusinessLayer.UserData userData)
        {
            boardController = new BusinessLayer.BoardController(userData);
        }

        //==================================================
        //                  BoardController
        //==================================================

        public string CreateBoard(string email, string title)
        {
            return "";
        }
        public string DeleteBoard(string email, string title)
        {
            return "";
        }
        public string GetAllTasksByState(string email, string state)
        {
            return "";
        }
        public string GetAllBoards(string email)
        {
            return "";
        }
        public string SearchBoard(string email, string title)
        {   
            return "";
        }



        public string AddBoard(string email, string name)
        {
            throw new NotImplementedException();
        }
        public string RemoveBoard(string email, string name)
        {
            throw new NotImplementedException();
        }
        public string InProgressTasks(string email)
        {
            throw new NotImplementedException();
        }

        //==================================================
        //                    Board
        //==================================================

        public string GetTask(string email, string boardTitle, string taskTitle)
        {
            return "";
        }
        public string GetAllTasksByType(string email, string boardTitle, string taskType)
        {
            return "";
        }
        public string AddTask(string email, string boardTitle, string dueDate, string description)
        {          
            return "";
        }
        public string RemoveTask(string email, string boardTitle, string title)
        {
            return "";
        }
        public string AdvanceTask(string email, string boardTitle, string title)
        {
            return "";
        }



        public string LimitColumn(string email, string boardName, int columnOrdinal, int limit)
        {
            return "";
        }
        public string GetColumnLimit(string email, string boardName, int columnOrdinal)
        {
            throw new NotImplementedException();
        }

        public string GetColumnName(string email, string boardName, int columnOrdinal)
        {
            throw new NotImplementedException();
        }

        public string AddTask(string email, string boardName, string title, string description, DateTime dueDate)
        {
            throw new NotImplementedException();
        }
        public string AdvanceTask(string email, string boardName, int columnOrdinal, int taskId)
        {
            throw new NotImplementedException();
        }
        public string GetColumn(string email, string boardName, int columnOrdinal)
        {
            throw new NotImplementedException();
        }


        //==================================================
        //                    Task
        //==================================================

        public string SetTaskTitle(string email, string boardTitle, string taskTitle, string newTitle)
        {
            return "";
        }
        public string GetTaskDuedate(string email, string boardTitle, string taskTitle)
        {
            return "";
        }
        public string SetTaskDueDate(string email, string boardTitle, string taskTitle, string newDate)
        {
            return "";
        }
        public string GetTaskDescription(string email, string boardTitle, string taskTitle)
        {
            return "";
        }
        public string SetTaskDescription(string email, string boardTitle, string taskTitle, string newDescription)
        {
            return "";
        }
        public string GetTaskState(string email, string boardTitle, string taskTitle)
        {
            return "";
        }


        public string UpdateTaskDueDate(string email, string boardName, int columnOrdinal, int taskId, DateTime dueDate)
        {
            throw new NotImplementedException();
        }
        public string UpdateTaskTitle(string email, string boardName, int columnOrdinal, int taskId, string title)
        {
            throw new NotImplementedException();
        }
        public string UpdateTaskDescription(string email, string boardName, int columnOrdinal, int taskId, string description)
        {
            throw new NotImplementedException();
        }
    }
}
