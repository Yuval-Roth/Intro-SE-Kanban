using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class BoardMembersPermissions
    {

        public static bool AddTask(string email, Board board)
        {
            if (board.Owner == email) { return true; }
            foreach(string joined in board.Joined)
            {
                if (joined == email) { return true; }
            }
            return false;
        }

    }
}
