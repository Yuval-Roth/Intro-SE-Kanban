using System;
using System.Collections.Generic;
using IntroSE.Kanban.Backend.Utilities;
using IntroSE.Kanban.Backend.Exceptions;
using IntroSE.Kanban.Backend.BusinessLayer;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    /// <summary>
	///This class implements BoardControllerService 
	///<br/>
	///<code>Supported operations:</code>
	///<br/>
	/// <list type="bullet">AddBoard()</list>
	/// <list type="bullet">RemoveBoard()</list>
	/// <list type="bullet">GetAllTasksByState()</list>
	/// <br/><br/>
	/// ===================
	/// <br/>
	/// <c>Ⓒ Kfir Nissim</c>
	/// <br/>
	/// ===================
	/// </summary>
    public class BoardControllerService
    {

        private readonly BoardController boardController;

        public BoardControllerService(BoardController BC)
        {
            boardController = BC;
        }

        /// <summary>
        /// This method adds a board to the specific user.
        /// </summary>
        /// <param name="email">Email of the user. Must be logged in</param>
        /// <param name="name">The name of the new board</param>
        /// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue:  // (operationState == true) => empty string
		/// }		       // (operationState == false) => error message		
		/// </code>
		/// </returns>
        public string AddBoard(string email, string name)
        {
            if (ValidateArguments.ValidateNotNull(new object[] { email, name }) == false)
            {
                Response<string> res = new(false, "AddBoard() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                boardController.AddBoard(email, name);
                Response<string> res = new(true, "");
                return JsonController.ConvertToJson(res);
            }
            catch (ElementAlreadyExistsException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (UserDoesNotExistException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (AccessViolationException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (ArgumentException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (UserNotLoggedInException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
        }

        /// <summary>
        /// This method removes a board to the specific user.
        /// </summary>
        /// <param name="email">Email of the user. Must be logged in</param>
        /// <param name="name">The name of the board</param>
        /// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: // (operationState == true) => empty string
		/// }			// (operationState == false) => error message		
		/// </code>
		/// </returns>
        public string RemoveBoard(string email, string name)
        {
            if (ValidateArguments.ValidateNotNull(new object[] { email, name}) == false)
            {
                Response<string> res = new(false, "RemoveBoard() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                boardController.RemoveBoard(email, name);
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
            //catch (OperationCanceledException ex)
            //{
            //    Response<string> res = new(false, ex.Message);
            //    return JsonController.ConvertToJson(res);
            //}
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
            catch (UserNotLoggedInException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
        }

        /// <summary>
        /// This method returns all the tasks of the user by specific state.
        /// </summary>
        /// <param name="email">Email of the user. Must be logged in</param>
        /// <param name="columnOrdinal">column id . Must be between zero and numbers of columns</param>
        /// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: //(operationState == true) => LinkedList&lt;Task&gt;
		/// }		      //(operationState == false) => string with error message		
		/// </code>
		/// </returns>
        public string GetAllTasksByState(string email, int columnOrdinal)
        {
            if (ValidateArguments.ValidateNotNull(new object[] { email, columnOrdinal }) == false)
            {
                Response<string> res = new(false, "GetAllTasksByState() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                LinkedList<Task> tasks = boardController.GetAllTasksByState(email, columnOrdinal);
                Response<LinkedList<Task>> res = new(true, tasks);
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
            catch (UserNotLoggedInException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
        }

        /// <summary>
        /// This method returns all the board's Id of the user.
        /// </summary>
        /// <param name="email">Email of the user. Must be logged in</param>
        /// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: //(operationState == true) => LinkedList&lt;int&gt;
		/// }		      //(operationState == false) => string with error message		
		/// </code>
		/// </returns>
        public string GetUserBoards(string email)
        {
            if (ValidateArguments.ValidateNotNull(new object[] { email}) == false)
            {
                Response<string> res = new(false, "GetUserBoards() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {            
                Response<LinkedList<int>> res = new(true, boardController.GetBoardsId(email));
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
            catch (UserNotLoggedInException ex)
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
