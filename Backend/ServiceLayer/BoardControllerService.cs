using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    public class BoardControllerService
    {
        private readonly BusinessLayer.BoardController boardController;

        public BoardControllerService(BusinessLayer.UserData userData)
        {
            boardController = new(userData);
        }

        public string CreateBoard(string email, string title)
        {
            return "";
        }
        public string DeleteBoard(string email, string title)
        {
            return "";
        }
    }

    
}
