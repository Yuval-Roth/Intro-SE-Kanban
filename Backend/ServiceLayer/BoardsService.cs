using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    internal class BoardsService
    {

        //==================================================
        //                  BoardController
        //==================================================

        public string CreateBoard(BusinessLayer.User user, String title)
        {
            return "";
        }
        public string DeleteBoard(BusinessLayer.User user, String title)
        {
            return "";
        }
        public string GetAllTasksByState(BusinessLayer.User user, Enum state)
        {
            return "";
        }
        public string GetAllBoards(BusinessLayer.User user)
        {
            return "";
        }
        public string SearchBoard(string json)
        {   
            // BusinessLayer.User user, String title
            return "";
        }

        //==================================================
        //                    Board
        //==================================================

        
        public string GetTask(string json)
        {
            //BusinessLayer.User user, BusinessLayer.Board board, string taskTitle
            return "";
        }
        public string GetAllTasksByType(string json)
        {
            //BusinessLayer.User user, BusinessLayer.Board board, Enum type
            return "";
        }
        public string AddTask(string json)
        {          
            //BusinessLayer.User user, BusinessLayer.Board board, string title, BusinessLayer.Date dueDate, string description
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
