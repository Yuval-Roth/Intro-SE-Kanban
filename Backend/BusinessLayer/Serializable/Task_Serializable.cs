using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer.Serializable
{
    [Serializable]
    public sealed class Task_Serializable
    {
        public string Title { get; set; }
        public Date CreationTime { get; set; }
        public Date DueDate { get; set; }
        public string Description { get; set; }
        public TaskStates State { get; set; }
        public bool DescriptionCharCap { get; set; }
    }
}
