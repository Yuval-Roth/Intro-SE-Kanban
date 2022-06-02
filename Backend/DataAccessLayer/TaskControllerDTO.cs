using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class TaskControllerDTO
    {
        private SQLExecuter executer;

        public bool AdvanceTask(int boardId, int taskId)
        {
            throw new NotImplementedException("No implement yet");
        }
        public bool ChangeTitle(string title, int boardId, int taskId)
        {
            throw new NotImplementedException("No implement yet");
        }
        public bool ChangeDescription(string description, int boardId, int taskId)
        {
            throw new NotImplementedException("No implement yet");
        }
        public bool ChangeAssignee(string email, int boardId, int taskId)
        {
            throw new NotImplementedException("No implement yet");
        }
        public bool ChangeDueDate(DateTime dueDate, int boardId, int taskId)
        {
            throw new NotImplementedException("No implement yet");
        }
    }
}
