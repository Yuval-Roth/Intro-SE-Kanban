using System;
using System.Collections.Generic;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    public class BoardService
    {

        public BoardService()
        {
           
        }
        public string GetTitle()
        {
            return "";
        }
        public string GetTask(string title)
        {
            return "";
        }
        public string GetAllTasksByType(Enum type)
        {
            return "";
        }
        public string AddTask(string title, BusinessLayer.Date dueDate, string description)
        {
            return "";
        }
        public string RemoveTask(string title)
        {
            return "";
        }
        public string AdvanceTask(string title)
        {
            return "";
        }
        public string LimitColumn(string email, string boardName, int columnOrdinal, int limit)
        {
            throw new NotImplementedException();
        }
    }
}

