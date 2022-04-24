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
    }
}
