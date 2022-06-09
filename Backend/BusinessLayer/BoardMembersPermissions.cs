
namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class BoardMembersPermissions
    {
        
        public static bool EditBoard(string email, Board board)
        {
            return board.Owner == email || board.Joined.Contains(email);
        }

        public static bool EditTask(string email, Task task)
        {
            return task.Assignee == email;
        }

        public static bool BoardOwnerPermission(string email, Board board)
        {
            return board.Owner == email;
        }

        public static bool LeaveBoard(string email, Board board)
        {
            return board.Owner != email && board.Joined.Contains(email);
        }

        public static bool SetOwner(string email, Board board)
        {
            if(board.Owner==email && board.Joined.Contains(email))
            {
                return true;
            }
            return false;
        }

        public static bool SetAssignee(string email, Task task)
        {
            return task.Assignee == email || task.Assignee == "unAssigned";
        }
    }
}
