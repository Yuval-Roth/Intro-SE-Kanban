using System;
using System.Collections.Generic;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    public class BoardService
    {
        BusinessLayer.Board board;

        public BoardService(BusinessLayer.Board board)
        {
            this.board = board;
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
    }
}

