using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    public class TaskService
    {
        private readonly BusinessLayer.BoardController boardController;

        public TaskService(BusinessLayer.UserData userData)
        {
            boardController = new(userData);
        }

        public string UpdateTaskDuedate(string email, string boardTitle,string columnOrdinal, string taskId)
        {
            return "";
        }
        public string UpdateTaskTitle(string email, string boardTitle, int columnOrdinal, int taskId, string title)
        {
            return "";
        }
        public string UpdateTaskDescription(string email, string boardTitle, int columnOrdinal, int taskId, string description)
        {
            return "";
        }
    }
    
}
