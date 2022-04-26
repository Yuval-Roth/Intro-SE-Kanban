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

        public string AddBoard(string email, string name)
        {
            return "";
        }
        public string RemoveBoard(string email, string name)
        {
            return "";
        }

        public string GetAllTasksByState(string email, int columnOrdinal)
        {
            return "";
        }
    }

    
}
