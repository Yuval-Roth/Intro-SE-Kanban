using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    public class BoardService
    {
        //public string GetAllBoards(string email)
        //{
        //    return "";
        //}
        //public string SearchBoard(string email, string title)
        //{
        //    return "";
        //}
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
        //public string GetTask(string email, string boardTitle, string taskId)
        //{
        //    return "";
        //}
        //public string GetAllTasksByType(string email, string boardTitle, string taskType)
        //{
        //    return "";
        //}
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
