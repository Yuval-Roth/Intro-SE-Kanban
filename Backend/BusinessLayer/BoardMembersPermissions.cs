using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class BoardMembersPermissions
    {

        public static bool EditBoard(string email, Board board)
        {
            if (board.Owner == email) { return true; }
            foreach(string joined in board.Joined)
            {
                if (joined == email) { return true; }
            }
            return false;
        }

        public static bool EditTask(string email, Task task)
        {
            if(task.Assignee == email)
            {
                return true;
            }
            return false;
        }

        public static bool RemoveBoard(string email, Board board)
        {
            return board.Owner == email;
        }

        public static bool LeaveBoard(string email, Board board)
        {
            if (board.Owner == email) { return false; }
            foreach (string joined in board.Joined)
            {
                if (joined == email) { return true; }
            }
            return false;

        }

        public static bool SetOwner(string email, Board board)
        {
            if(board.Owner==email && board.Joined.Contains(email))
            {
                return true;
            }
            return false;
        }
    }
}
