using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class BoardDTO
    {
        public int id;
        public string Title;
        public string owner;
        public string[] Joined;
        public TaskDTO[] backlog;
        public TaskDTO[] inprogress;
        public TaskDTO[] done;
        public int backlogLimit;
        public int inprogressLimit;
        public int doneLimit;
    }
}
