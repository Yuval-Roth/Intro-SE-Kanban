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
        public string AdvanceTask(string email, string boardName, int columnOrdinal, int taskId)
        {
            return "";
        }
        public string UpdateTaskDueDate(string email, string boardName, int columnOrdinal, int taskId, DateTime dueDate)
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
