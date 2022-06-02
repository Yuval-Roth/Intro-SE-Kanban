using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class UserDTO
    {
        public string email { get; set; }
        public string password { get; set; }
        public BoardDTO[] ownBoards { get; set; }
        public BoardDTO[] joinBoards { get; set; }
    }
}
