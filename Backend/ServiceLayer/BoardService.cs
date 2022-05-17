using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.ServiceLayer
{

    /// <summary>
	///This class implements BoardService 
	///<br/>
	///<code>Supported operations:</code>
	///<br/>
	/// <list type="bullet">AddTask()</list>
	/// <list type="bullet">RemoveTask()</list>
    /// /// <list type="bullet">AdvanceTask()</list>
	/// <list type="bullet">LimitColumn()</list>
    /// <list type="bullet">GetColumnLimit()</list>
	/// <list type="bullet">GetColumnName()</list>
	/// <list type="bullet">GetColumn()</list>
	/// <br/><br/>
	/// ===================
	/// <br/>
	/// <c>Ⓒ Kfir Nissim</c>
	/// <br/>
	/// ===================
	/// </summary>
    /// 
    public class BoardService
    {
        private readonly BusinessLayer.BoardController boardController;
        private readonly BusinessLayer.UserController userController;

        public BoardService(BusinessLayer.UserData userData)
        {
            userController = new(userData);
            boardController = new(userData);
        }

        /// <summary>
        /// This method adds a new task.
        /// </summary>
        /// <param name="email">Email of the user. The user must be logged in.</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="title">Title of the new task</param>
        /// <param name="description">Description of the new task</param>
        /// <param name="dueDate">The due date if the new task</param>
		/// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: // (operationState == true) => empty string
		/// }			// (operationState == false) => error message		
		/// </code>
		/// </returns>
        public string AddTask(string email, string boardName, string title, string description, DateTime dueDate)
        {
            try
            {
                BusinessLayer.Board board = boardController.SearchBoard(email,boardName);
                board.AddTask(title, dueDate, description);
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
        /// This method removes a task to the specific user and board.
        /// </summary>
        /// <param name="email">Email of the user. The user must be logged in.</param>
        /// <param name="boardTitle">The name of the board</param>
        /// <param name="taskId">id of the task</param>
        /// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: // (operationState == true) => empty string
		/// }			// (operationState == false) => error message		
		/// </code>
		/// </returns>
        public string RemoveTask(string email, string boardTitle, int taskId)
        {
            try
            {
                BusinessLayer.Board board = boardController.SearchBoard(email, boardTitle);
                board.RemoveTask(taskId);
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
        /// This method advances a task to the next column
        /// </summary>
        /// <param name="email">Email of user. Must be logged in</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="columnOrdinal">The column ID. The first column is identified by 0, the ID increases by 1 for each column</param>
        /// <param name="taskId">The task to be updated identified task ID</param>
        /// <returns>The string "{}", unless an error occurs (see <see cref="BoardService"/>)</returns>
        public string AdvanceTask(string email, string boardName, int columnOrdinal, int taskId)
        {
            try
            {
                BusinessLayer.Board board = boardController.SearchBoard(email, boardName);
                BusinessLayer.Task task = board.SearchTask(taskId);
                board.AdvanceTask(columnOrdinal,taskId);
                task.AdvanceTask();
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
        /// This method limits the number of tasks in a specific column.
        /// </summary>
        /// <param name="email">The email address of the user, must be logged in</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="columnOrdinal">The column ID. The first column is identified by 0, the ID increases by 1 for each column</param>
        /// <param name="limit">The new limit value. A value of -1 indicates no limit.</param>
        /// <returns>
        /// Json formatted as so:
        /// <code>
        ///	{
        ///		operationState: bool 
        ///		returnValue: // (operationState == true) => empty string
        /// }			// (operationState == false) => error message		
        /// </code>
        /// </returns>
        public string LimitColumn(string email, string boardName, int columnOrdinal, int limit)
        {
            try
            {
                BusinessLayer.Board board = boardController.SearchBoard(email, boardName);
                board.LimitColumn(columnOrdinal,limit);
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
        /// This method gets the limit of a specific column.
        /// </summary>
        /// <param name="email">The email address of the user, must be logged in</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="columnOrdinal">The column ID. The first column is identified by 0, the ID increases by 1 for each column</param>
        /// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: // (operationState == true) => column limit
		/// }			// (operationState == false) => error message		
		/// </code>
		/// </returns>
        public string GetColumnLimit(string email, string boardName, int columnOrdinal)
        {
            try
            {
                BusinessLayer.Board board = boardController.SearchBoard(email, boardName);
                int columnlimit=board.GetColumnLimit(columnOrdinal);
                Response<int> res = new(true, columnlimit);
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
        /// This method gets the name of a specific column
        /// </summary>
        /// <param name="email">The email address of the user, must be logged in</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="columnOrdinal">The column ID. The first column is identified by 0, the ID increases by 1 for each column</param>
        /// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: // (operationState == true) => column name
		/// }	             // (operationState == false) => error message		
		/// </code>
		/// </returns>
        public string GetColumnName(string email, string boardName, int columnOrdinal)
        {
            try
            {
                BusinessLayer.Board board = boardController.SearchBoard(email, boardName);
                string columnname = board.GetColumnName(columnOrdinal);
                Response<string> res = new(true, columnname);
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
        /// This method returns a column given it's name
        /// </summary>
        /// <param name="email">Email of the user. Must be logged in</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="columnOrdinal">The column ID. The first column is identified by 0, the ID increases by 1 for each column</param>
        /// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: string // (operationState == true) => LinkedList&lt;Task&gt;
		/// }				// (operationState == false) => error message		
		/// </code>
		/// </returns>
        public string GetColumn(string email, string boardName, int columnOrdinal)
        {
            try
            {
                BusinessLayer.Board board = boardController.SearchBoard(email, boardName);
                LinkedList<BusinessLayer.Task> column = board.GetColumn(columnOrdinal);
                LinkedList<BusinessLayer.Serializable.Task_Serializable> column_serializeable = new();
                foreach (BusinessLayer.Task task in column)
                {
                    column_serializeable.AddLast(task.GetSerializableInstance());
                }
                Response<LinkedList<BusinessLayer.Serializable.Task_Serializable>> res = new(true, column_serializeable);
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
