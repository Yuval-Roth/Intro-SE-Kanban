using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public enum TaskStates 
    {
        backlog,
        inprogress,
        done
    }
    public class TaskDTO
    {
        //public int BoardId { set; get; } 
        
        // BoardID is not needed here because
        // TaskDTO will be held inside BoardDTO when loading the data


        public int Id { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public DateTime CreationTime { set; get; }
        public DateTime DueDate { set; get; }
        public TaskStates State { set; get; }
        public string Assignee { set; get; }
    }
}
