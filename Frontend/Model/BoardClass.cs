using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Frontend.Model
{
    public class BoardClass
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string Owner { set; get; }
        public LinkedList<string> Joined { set; get; }
        public LinkedList<Task> BackLog { set; get; }
        public LinkedList<Task> InProgress { set; get; }
        public LinkedList<Task> Done { set; get; }
        public int BackLogLimit { set; get; }
        public int InProgressLimit { set; get; }
        public int DoneLimit { set; get; }
        public int TaskIDCounter { set; get; }

    }
}
