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
        private readonly BusinessLayer.UserController userController;

        public BoardControllerService(BusinessLayer.UserData userData)
        {
            userController = new(userData);
            boardController = new(userData);
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
		///		returnValue: string // (operationState == true) => empty string
		/// }				// (operationState == false) => error message		
		/// </code>
		/// </returns>
        public string AddBoard(string email, string name)
        {
            if (userController.isLogIn(email) == false)
            {
                Response<string> res = new(false, "user isn't log in");
                return JsonController.ConvertToJson(res);
            }
            try
            {
                boardController.AddBoard(email, name);
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
            return "";
        }

        /// <summary>
        /// This method returns all the tasks of the user by specific state.
        /// </summary>
        /// <param name="email">Email of the user. Must be logged in</param>
        /// /// <param name="columnOrdinal">column id . Must be between zero and numbers of columns</param>
        /// /// <returns>
		/// Json formatted as so:
		/// <code>
		///	{
		///		operationState: bool 
		///		returnValue: //(operationState == true) => LinkedList&lt;Task&gt;
		/// }		      //(operationState == false) => string with error message		
		/// </code>
		/// </returns>
        /// <returns>Response with a list of tasks by specific state, unless an error occurs (see <see cref="BoardControllerService"/>)</returns>
        public string GetAllTasksByState(string email, int columnOrdinal)
        {
            return "";
        }
    }

    
}
