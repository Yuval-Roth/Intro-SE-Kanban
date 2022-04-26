using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    public class BoardService
    {
        private readonly BusinessLayer.BoardController boardController;

        public BoardService(BusinessLayer.UserData userData)
        {
            boardController = new(userData);
        }

        public string AddTask(string email, string boardTitle, string dueDate, string description)
        {
            return "";
        }
        public string RemoveTask(string email, string boardTitle, string title)
        {
            return "";
        }
        public string GetAllTasksByState(string email, string state)
        {
            return "";
        }
        public string AdvanceTask(string email, string boardName, int columnOrdinal, int taskId)
        {
            return "";
        }
        public string LimitColumn(string email, string boardName, int columnOrdinal, int limit)
        {
            return "";
        }
        public string GetColumnLimit(string email, string boardName, int columnOrdinal)
        {
            return "";
        }
        public string GetColumnName(string email, string boardName, int columnOrdinal)
        {
            return "";
        }
        public string GetColumn(string email, string boardName, int columnOrdinal)
        {
            return "";
        }
    }
    
}
