using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class UserDTO
    {
        public string email;
        public string password;
        public BoardDTO[] ownBoards;
        public BoardDTO[] joinBoards;
    }
}
