using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    public class BoardsService
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
        public string SearchBoard(BusinessLayer.User user, String title)
        {   
            return "";
        }

        //==================================================
        //                    Board
        //==================================================

        public string GetTask(BusinessLayer.User user, BusinessLayer.Board board, string taskTitle)
        {
            return "";
        }
        public string GetAllTasksByType(BusinessLayer.User user, BusinessLayer.Board board, Enum type)
        {
            return "";
        }
        public string AddTask(BusinessLayer.User user, BusinessLayer.Board board, string title, BusinessLayer.Date dueDate, string description)
        {          
            return "";
        }
        public string RemoveTask(BusinessLayer.User user, BusinessLayer.Board board, string title)
        {
            return "";
        }
        public string AdvanceTask(BusinessLayer.User user, BusinessLayer.Board board, string title)
        {
            return "";
        }

        //==================================================
        //                    Task
        //==================================================

        public string SetTaskTitle(BusinessLayer.User user, BusinessLayer.Board board, string taskTitle, string newTitle)
        {
            return "";
        }
        public string GetTaskDuedate(BusinessLayer.User user, BusinessLayer.Board board, string taskTitle)
        {
            return "";
        }
        public string SetTaskDuedate(BusinessLayer.User user, BusinessLayer.Board board, string taskTitle, BusinessLayer.Date newDate)
        {
            return "";
        }
        public string GetTaskDescription(BusinessLayer.User user, BusinessLayer.Board board, string taskTitle)
        {
            return "";
        }
        public string SetTaskDescription(BusinessLayer.User user, BusinessLayer.Board board, string taskTitle, string newDescription)
        {
            return "";
        }
        public string GetTaskState(BusinessLayer.User user, BusinessLayer.Board board, string taskTitle)
        {
            return "";
        }
        public static string TaskToJson(BusinessLayer.Task task)
        {
            BusinessLayer.Task toSerialize = new() 
            {
                Title=task.Title,
                CreationTime=task.CreationTime,
                Description=task.Description,
                DueDate=task.DueDate,
                State=task.State,
            };
            return JsonController.Serialize<BusinessLayer.Task>(toSerialize);
        }
        public static BusinessLayer.Task BuildTaskFromJson(string json) 
        {
            return JsonController.Deserialize<BusinessLayer.Task>(json);
        }
    }
}
