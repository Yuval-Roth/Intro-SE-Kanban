using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class TaskDTO
    {
        public int BoardId { set; get; }
        public int TaskId { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public DateTime CreationTime { set; get; }
        public DateTime DueDate { set; get; }
        public BusinessLayer.TaskStates State { set; get; }
        public string Assignee { set; get; }
    }
}
