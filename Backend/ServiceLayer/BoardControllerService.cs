using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    /// <summary>
	///This class implements UserService 
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

        public BoardControllerService(BusinessLayer.UserData userData)
        {
            boardController = new(userData);
        }

        /// <summary>
        /// This method adds a board to the specific user.
        /// </summary>
        /// <param name="email">Email of the user. Must be logged in</param>
        /// <param name="name">The name of the new board</param>
        /// <returns>The string "{}", unless an error occurs (see <see cref="BoardControllerService"/>)</returns>
        public string AddBoard(string email, string name)
        {
            return "";
        }

        /// <summary>
        /// This method removes a board to the specific user.
        /// </summary>
        /// <param name="email">Email of the user. Must be logged in</param>
        /// <param name="name">The name of the board</param>
        /// <returns>The string "{}", unless an error occurs (see <see cref="BoardControllerService"/>)</returns>
        public string RemoveBoard(string email, string name)
        {
            return "";
        }

        /// <summary>
        /// This method returns all the tasks of the user by specific state.
        /// </summary>
        /// <param name="email">Email of the user. Must be logged in</param>
        /// <returns>Response with a list of tasks by specific state, unless an error occurs (see <see cref="BoardControllerService"/>)</returns>
        public string GetAllTasksByState(string email, int columnOrdinal)
        {
            return "";
        }
    }

    
}
