using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class TaskDTO
    {
        public int BoardId;
        public int TaskId;
        public string Title;
        public string Description;
        public DateTime CreationTime;
        public DateTime DueDate;
        public BusinessLayer.TaskStates state;
        public string assignee;
    }
}
