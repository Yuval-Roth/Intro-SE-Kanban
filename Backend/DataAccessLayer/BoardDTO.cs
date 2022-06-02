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
        string[] Joined;
        TaskDTO[] backlog;
        TaskDTO[] inprogress;
        TaskDTO[] done;
        int backlogLimit;
        int inprogressLimit;
        int doneLimit;
    }
}
