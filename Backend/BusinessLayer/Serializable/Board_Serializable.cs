using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer.Serializable
{
    [Serializable]
    public sealed class Board_Serializable
    {
        public string Title { get; set; }
        public LinkedList<Task>[] Columns { get; set; }
        public int[] ColumnLimit { get; set; }
        public Dictionary<int, TaskStates> TaskStateTracker { get; set; }
    }
}
