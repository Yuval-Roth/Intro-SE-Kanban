using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private readonly BusinessLayer.BoardController boardController;

        public BoardControllerService(BusinessLayer.BoardController BC)
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
            if (ValidateArguments.ValidateNotNull(new object[] { email.ToLower(), name }) == false)
            {
                Response<string> res = new(false, "AddBoard() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                boardController.AddBoard(email.ToLower(), name);
                Response<string> res = new(true, "");
                return JsonController.ConvertToJson(res);
            }
            catch (BusinessLayer.ElementAlreadyExistsException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (DataMisalignedException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (BusinessLayer.UserDoesNotExistException ex)
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
            if (ValidateArguments.ValidateNotNull(new object[] { email.ToLower(), name.ToLower() }) == false)
            {
                Response<string> res = new(false, "RemoveBoard() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                boardController.RemoveBoard(email.ToLower(), name);
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
            catch (OperationCanceledException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (AccessViolationException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (BusinessLayer.UserDoesNotExistException ex)
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
            if (ValidateArguments.ValidateNotNull(new object[] { email.ToLower(), columnOrdinal }) == false)
            {
                Response<string> res = new(false, "GetAllTasksByState() failed: ArgumentNullException");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                LinkedList<BusinessLayer.Task> tasks = boardController.GetAllTasksByState(email.ToLower(), columnOrdinal);
                Response<LinkedList<BusinessLayer.Task>> res = new(true, tasks);
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
            catch (AccessViolationException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
            catch (BusinessLayer.UserDoesNotExistException ex)
            {
                Response<string> res = new(false, ex.Message);
                return JsonController.ConvertToJson(res);
            }
        }
    }

    
}
