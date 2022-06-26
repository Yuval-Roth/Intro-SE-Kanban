using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Frontend.Model
{
    public class Task
    {
        public int BoardId { get; set; }
        public int Id { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public DateTime CreationTime { set; get; }
        public DateTime DueDate { set; get; }
        public BoardColumnsNames State { set; get; }
        public string Assignee { set; get; }
    }


}
