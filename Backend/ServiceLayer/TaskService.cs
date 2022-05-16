using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.ServiceLayer
{

    /// <summary>
	///This class implements TaskService 
	///<br/>
	///<code>Supported operations:</code>
	///<br/>
	/// <list type="bullet">UpdateTaskDueDate()</list>
	/// <list type="bullet">UpdateTaskTitle()</list>
    /// /// <list type="bullet">UpdateTaskDescription()</list>
	/// <br/><br/>
	/// ===================
	/// <br/>
	/// <c>Ⓒ Kfir Nissim</c>
	/// <br/>
	/// ===================
	/// </summary>
    /// 

    public class TaskService
    {
        private readonly BusinessLayer.BoardController boardController;
        private readonly BusinessLayer.UserController userController;

        public TaskService(BusinessLayer.UserData userData)
        {
            userController = new(userData);
            boardController = new(userData);
        }


        /// <summary>
        /// This method updates the due date of a task
        /// </summary>
        /// <param name="email">Email of the user. Must be logged in</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="columnOrdinal">The column ID. The first column is identified by 0, the ID increases by 1 for each column</param>
        /// <param name="taskId">The task to be updated identified task ID</param>
        /// <param name="dueDate">The new due date of the column</param>
        /// <returns>The string "{}", unless an error occurs (see <see cref="TaskService"/>)</returns>
        public string UpdateTaskDueDate(string email, string boardName, int columnOrdinal, int taskId, DateTime dueDate)
        {
            if (userController.isLogIn(email) == false)
            {
                Response<string> res = new(false, "user isn't log in");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                BusinessLayer.Board board = boardController.SearchBoard(email, boardName);
                BusinessLayer.Task task = board.SearchTask(taskId);
                task.DueDate = dueDate;
                Response<string> res = new(true, "");
                return JsonController.ConvertToJson(res);
            }
            catch (BusinessLayer.NoSuchElementException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (ArgumentException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
        }

        /// <summary>
        /// This method updates task title.
        /// </summary>
        /// <param name="email">Email of user. Must be logged in</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="columnOrdinal">The column ID. The first column is identified by 0, the ID increases by 1 for each column</param>
        /// <param name="taskId">The task to be updated identified task ID</param>
        /// <param name="title">New title for the task</param>
        /// <returns>The string "{}", unless an error occurs (see <see cref="TaskService"/>)</returns>
        public string UpdateTaskTitle(string email, string boardName, int columnOrdinal, int taskId, string title)
        {
            if (userController.isLogIn(email) == false)
            {
                Response<string> res = new(false, "user isn't log in");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                BusinessLayer.Board board = boardController.SearchBoard(email, boardName);
                BusinessLayer.Task task = board.SearchTask(taskId);
                task.Title = title;
                Response<string> res = new(true, "");
                return JsonController.ConvertToJson(res);
            }
            catch (BusinessLayer.NoSuchElementException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (ArgumentException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
        }

        /// <summary>
        /// This method updates the description of a task.
        /// </summary>
        /// <param name="email">Email of user. Must be logged in</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="columnOrdinal">The column ID. The first column is identified by 0, the ID increases by 1 for each column</param>
        /// <param name="taskId">The task to be updated identified task ID</param>
        /// <param name="description">New description for the task</param>
        /// <returns>The string "{}", unless an error occurs (see <see cref="GradingService"/>)</returns>
        public string UpdateTaskDescription(string email, string boardName, int columnOrdinal, int taskId, string description)
        {
            if (userController.isLogIn(email) == false)
            {
                Response<string> res = new(false, "user isn't log in");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                BusinessLayer.Board board = boardController.SearchBoard(email, boardName);
                BusinessLayer.Task task = board.SearchTask(taskId);
                task.Description = description;
                Response<string> res = new(true, "");
                return JsonController.ConvertToJson(res);
            }
            catch (BusinessLayer.NoSuchElementException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (ArgumentException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
        }
    }
    
}
