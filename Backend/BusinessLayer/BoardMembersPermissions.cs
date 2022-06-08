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

        }

        public static bool EditTask(string email, Task task)
        {
            if(task.Assignee == email)
            {
                return true;
            }
            return false;
        }

        public 
    }
}
