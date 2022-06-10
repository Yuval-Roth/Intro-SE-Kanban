using System;
using System.Collections.Generic;
using IntroSE.Kanban.Backend.BusinessLayer;

namespace IntroSE.Kanban.Backend.ServiceLayer
{

    /// <summary>
	///This class implements BoardService 
	///<br/>
	///<code>Supported operations:</code>
	///<br/>
	/// <list type="bullet">AddTask()</list>
	/// <list type="bullet">RemoveTask()</list>
    /// <list type="bullet">AdvanceTask()</list>
	/// <list type="bullet">LimitColumn()</list>
    /// <list type="bullet">UnlimitColumn()</list>
    /// <list type="bullet">GetColumnLimit()</list>
	/// <list type="bullet">GetColumnName()</list>
	/// <list type="bullet">GetColumn()</list>
    /// /// <list type="bullet">ChangeOwner()</list>
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
        private readonly BoardController boardController;

        public BoardService(BoardController BC)
        {
            boardController = BC;
        }

        /// <summary>
        /// This method add user to board's joined boards
        /// </summary>
        /// <param name="email">Email of the user. The user must be logged in.</param>
        /// <param name="boardId">the Id of the board</param>
        /// <returns>
        /// Json formatted as so:
        /// <code>
        ///	{
        ///		operationState: bool 
        ///		returnValue: // (operationState == true) => empty string
        /// }			// (operationState == false) => error message		
        /// </code>
        /// </returns>
        public string JoinBoard(string email, int boardId)
        {
            if (ValidateArguments.ValidateNotNull(new object[] { email, boardId }) == false)
            {
                Response<string> res = new(false, "JoinBoard() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                Board board = boardController.SearchBoard(email.ToLower(), boardId);
                boardController.JoinBoard(email.ToLower(), boardId);
                board.JoinBoard(email.ToLower(), boardId);
                Response<string> res = new(true, "");
                return JsonController.ConvertToJson(res);
            }
            catch (NoSuchElementException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (AccessViolationException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (UserDoesNotExistException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (ElementAlreadyExistsException ex)
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
        /// This method remove user from the board's joined boards
        /// </summary>
        /// <param name="email">Email of the user. The user must be logged in.</param>
        /// <param name="boardId">the Id of the board</param>
        /// <returns>
        /// Json formatted as so:
        /// <code>
        ///	{
        ///		operationState: bool 
        ///		returnValue: // (operationState == true) => empty string
        /// }			// (operationState == false) => error message		
        /// </code>
        /// </returns>

        public string LeaveBoard(string email, int boardId)
        {
            if (ValidateArguments.ValidateNotNull(new object[] { email, boardId }) == false)
            {
                Response<string> res = new(false, "LeaveBoard() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                Board board = boardController.SearchBoard(email.ToLower(), boardId);
                boardController.LeaveBoard(email.ToLower(), boardId);
                board.LeaveBoard(email.ToLower(), boardId);
                Response<string> res = new(true, "");
                return JsonController.ConvertToJson(res);
            }
            catch (NoSuchElementException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (AccessViolationException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (UserDoesNotExistException ex)
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
        /// This method transfers a board ownership.
        /// </summary>
        /// <param name="currentOwnerEmail">Email of the current owner. Must be logged in</param>
        /// <param name="newOwnerEmail">Email of the new owner</param>
        /// <param name="boardName">The name of the board</param>
        /// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: string // (operationState == true) => empty string;
		/// }				// (operationState == false) => error message		
		/// </code>
		/// </returns>
        public string ChangeOwner(string currentOwnerEmail, string newOwnerEmail, string boardName)
        {
            if (ValidateArguments.ValidateNotNull(new object[] { currentOwnerEmail, newOwnerEmail, boardName }) == false)
            {
                Response<string> res = new(false, "ChangeOwner() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                BusinessLayer.Board board = boardController.SearchBoard(currentOwnerEmail.ToLower(), boardName);
                boardController.ChangeOwner(currentOwnerEmail.ToLower(), newOwnerEmail.ToLower(), boardName);
                board.ChangeOwner(currentOwnerEmail.ToLower(), newOwnerEmail.ToLower(), boardName);
                Response<string> res = new(true, "");
                return JsonController.ConvertToJson(res);
            }
            catch (ElementAlreadyExistsException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (NoSuchElementException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (UserDoesNotExistException ex)
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
            if (ValidateArguments.ValidateNotNull(new object[] { email, boardName, title, description, dueDate }) == false)
            {
                Response<string> res = new(false, "AddTask() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                Board board = boardController.SearchBoard(email.ToLower(),boardName);
                board.AddTask(title, dueDate, description);
                Response<string> res = new(true, "");
                return JsonController.ConvertToJson(res);
            }
            catch (NoSuchElementException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (ArgumentException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (AccessViolationException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (UserDoesNotExistException ex)
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
            if (ValidateArguments.ValidateNotNull(new object[] { email, boardTitle, taskId }) == false)
            {
                Response<string> res = new(false, "RemoveTask() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                Board board = boardController.SearchBoard(email.ToLower(), boardTitle);
                board.RemoveTask(taskId);
                Response<string> res = new(true, "");
                return JsonController.ConvertToJson(res);
            }
            catch (NoSuchElementException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (ArgumentException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (AccessViolationException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (UserDoesNotExistException ex)
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
        /// <returns>
        /// Json formatted as so:
        /// <code>
        ///	{
        ///		operationState: bool 
        ///		returnValue: // (operationState == true) => empty string
        /// }			// (operationState == false) => error message		
        /// </code>
        /// </returns>
        public string AdvanceTask(string email, string boardName, int columnOrdinal, int taskId)
        {
            if (ValidateArguments.ValidateNotNull(new object[] { email, boardName, columnOrdinal, taskId }) == false)
            {
                Response<string> res = new(false, "AdvanceTask() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                Board board = boardController.SearchBoard(email.ToLower(), boardName);
                Task task = board.SearchTask(taskId);
                board.AdvanceTask(email.ToLower(),columnOrdinal, taskId);
                task.AdvanceTask(email.ToLower());
                Response<string> res = new(true, "");
                return JsonController.ConvertToJson(res);
            }
            catch (NoSuchElementException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (ArgumentException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (IndexOutOfRangeException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (AccessViolationException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (UserDoesNotExistException ex)
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
            if (ValidateArguments.ValidateNotNull(new object[] { email, boardName, columnOrdinal, limit }) == false)
            {
                Response<string> res = new(false, "LimitColumn() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                Board board = boardController.SearchBoard(email.ToLower(), boardName);
                board.LimitColumn(columnOrdinal,limit);
                Response<string> res = new(true, "");
                return JsonController.ConvertToJson(res);
            }
            catch (NoSuchElementException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (ArgumentException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (IndexOutOfRangeException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (AccessViolationException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (UserDoesNotExistException ex)
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
		///		returnValue: // (operationState == true) => column limit (int)
		/// }			// (operationState == false) => error message		
		/// </code>
		/// </returns>
        public string GetColumnLimit(string email, string boardName, int columnOrdinal)
        {
            if (ValidateArguments.ValidateNotNull(new object[] { email, boardName, columnOrdinal }) == false)
            {
                Response<string> res = new(false, "GetColumnLimit() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                Board board = boardController.SearchBoard(email.ToLower(), boardName);
                int columnlimit = board.GetColumnLimit(columnOrdinal);
                Response<int> res = new(true, columnlimit);
                return JsonController.ConvertToJson(res);
            }
            catch (NoSuchElementException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (ArgumentException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (IndexOutOfRangeException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (AccessViolationException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (UserDoesNotExistException ex)
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
		///		returnValue: // (operationState == true) => column name (string)
		/// }	             // (operationState == false) => error message		
		/// </code>
		/// </returns>
        public string GetColumnName(string email, string boardName, int columnOrdinal)
        {
            if (ValidateArguments.ValidateNotNull(new object[] { email, boardName, columnOrdinal }) == false)
            {
                Response<string> res = new(false, "GetColumnName() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                Board board = boardController.SearchBoard(email.ToLower(), boardName);
                string columnname = board.GetColumnName(columnOrdinal);
                Response<string> res = new(true, columnname.ToLower());
                return JsonController.ConvertToJson(res);
            }
            catch (NoSuchElementException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (ArgumentException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (IndexOutOfRangeException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (AccessViolationException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (UserDoesNotExistException ex)
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
            if (ValidateArguments.ValidateNotNull(new object[] { email ,boardName, columnOrdinal }) == false)
            {
                Response<string> res = new(false, "GetColumn() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                Board board = boardController.SearchBoard(email.ToLower(), boardName);
                LinkedList<Task> column = board.GetColumn(columnOrdinal);
                Response<LinkedList<Task>> res = new(true, column);
                return JsonController.ConvertToJson(res);
            }
            catch (NoSuchElementException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (ArgumentException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (IndexOutOfRangeException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (AccessViolationException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (UserDoesNotExistException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
        }


    }
    
}
