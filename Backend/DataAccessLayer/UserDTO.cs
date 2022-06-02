using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public BoardDTO[] MyBoards { get; set; }
        public BoardDTO[] JoinedBoards { get; set; }
    }
}
