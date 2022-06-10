using System;
using IntroSE.Kanban.Backend.BusinessLayer;

namespace IntroSE.Kanban.Backend.ServiceLayer
{

    /// <summary>
	///This class implements TaskService 
	///<br/>
	///<code>Supported operations:</code>
	///<br/>
	/// <list type="bullet">UpdateTaskDueDate()</list>
	/// <list type="bullet">UpdateTaskTitle()</list>
    /// <list type="bullet">UpdateTaskDescription()</list>
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
        private readonly BoardController boardController;

        public TaskService(BoardController BC)
        {
            boardController = BC;
        }


        /// <summary>
        /// This method updates the due date of a task
        /// </summary>
        /// <param name="email">Email of the user. Must be logged in</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="columnOrdinal">The column ID. The first column is identified by 0, the ID increases by 1 for each column</param>
        /// <param name="taskId">The task to be updated identified task ID</param>
        /// <param name="dueDate">The new due date of the column</param>
        /// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: // (operationState == true) => empty string
		/// }			// (operationState == false) => error message		
		/// </code>
		/// </returns>
        public string UpdateTaskDueDate(string email, string boardName, int columnOrdinal, int taskId, DateTime dueDate)
        {
            if (ValidateArguments.ValidateNotNull(new object[] { email, boardName, columnOrdinal, taskId, dueDate }) == false)
            {
                Response<string> res = new(false, "UpdateTaskDueDate() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                Board board = boardController.SearchBoard(email.ToLower(), boardName);
                Task task = board.SearchTask(taskId, columnOrdinal);
                if(!BoardMembersPermissions.EditTask(email.ToLower(), task))
                {
                    Response<string> res1 = new(false, "UpdateTaskDueDate() failed: User is not the task's assignee");
                    return JsonController.ConvertToJson(res1);
                }
                task.DueDate = dueDate;
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
        /// This method updates task title.
        /// </summary>
        /// <param name="email">Email of user. Must be logged in</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="columnOrdinal">The column ID. The first column is identified by 0, the ID increases by 1 for each column</param>
        /// <param name="taskId">The task to be updated identified task ID</param>
        /// <param name="title">New title for the task</param>
        /// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: // (operationState == true) => empty string
		/// }			// (operationState == false) => error message		
		/// </code>
		/// </returns>
        public string UpdateTaskTitle(string email, string boardName, int columnOrdinal, int taskId, string title)
        {
            if (ValidateArguments.ValidateNotNull(new object[] { email, boardName, columnOrdinal, taskId, title}) == false)
            {
                Response<string> res = new(false, "UpdateTaskTitle() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                Board board = boardController.SearchBoard(email.ToLower(), boardName);
                Task task = board.SearchTask(taskId, columnOrdinal);
                if (!BoardMembersPermissions.EditTask(email.ToLower(), task))
                {
                    Response<string> res1 = new(false, "UpdateTaskTitle() failed: User is not the task's assignee");
                    return JsonController.ConvertToJson(res1);
                }
                task.Title = title;
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
        /// This method updates the description of a task.
        /// </summary>
        /// <param name="email">Email of user. Must be logged in</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="columnOrdinal">The column ID. The first column is identified by 0, the ID increases by 1 for each column</param>
        /// <param name="taskId">The task to be updated identified task ID</param>
        /// <param name="description">New description for the task</param>
        /// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: // (operationState == true) => empty string
		/// }			// (operationState == false) => error message		
		/// </code>
		/// </returns>
        public string UpdateTaskDescription(string email, string boardName, int columnOrdinal, int taskId, string description)
        {
            if (ValidateArguments.ValidateNotNull(new object[] { email, boardName, columnOrdinal, taskId, description }) == false)
            {
                Response<string> res = new(false, "UpdateTaskDescription() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                Board board = boardController.SearchBoard(email.ToLower(), boardName);
                Task task = board.SearchTask(taskId, columnOrdinal);
                if (!BoardMembersPermissions.EditTask(email.ToLower(), task))
                {
                    Response<string> res1 = new(false, "UpdateTaskDescription() failed: User is not the task's assignee");
                    return JsonController.ConvertToJson(res1);
                }
                task.Description = description;
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
        /// This method assigns a task to a user
        /// </summary>
        /// <param name="email">Email of the user. Must be logged in</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="columnOrdinal">The column number. The first column is 0, the number increases by 1 for each column</param>
        /// <param name="taskId">The task to be updated identified a task ID</param>        
        /// <param name="emailAssignee">Email of the asignee user</param>
        /// <returns>
        /// Json formatted as so:
        /// <code>
        ///	{
        ///		operationState: bool 
        ///		returnValue: // (operationState == true) => empty string
        /// }			// (operationState == false) => error message		
        /// </code>
        /// </returns>
        public string AssignTask(string email, string boardName, int columnOrdinal, int taskId, string emailAssignee)
        {
            if (ValidateArguments.ValidateNotNull(new object[] { email, boardName, columnOrdinal, taskId, emailAssignee }) == false)
            {
                Response<string> res = new(false, "UpdateTaskDescription() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                Board board = boardController.SearchBoard(email.ToLower(), boardName);
                Task task = board.SearchTask(taskId, columnOrdinal);
                task.AssignTask(email.ToLower(), emailAssignee.ToLower());
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
            catch (IndexOutOfRangeException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (ElementAlreadyExistsException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
        }

    }
    
}
