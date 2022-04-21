using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
   
    public class Task
    {
        private string title;
        private string description;
        private Date creationTime;
        private Date dueDate;
        private Enum state;

        [JsonConstructor]
        public Task(string title,Date creationTime, string description, Date dueDate, Enum state)
        {
            this.title = title;
            this.creationTime = creationTime;
            this.dueDate = dueDate;
            this.state = state;
            this.description = description;
        }


        public string GetTitle() 
        {
        
        
        }
    
        public Date CreationTime { get; set; }
        public Date DueDate { get; set; }
        public string Description { get; set; }
        public Enum State { get; set; }
        public Boolean DescriptionCharCap { get; set; }
        public int DESCRIPTION_CHAR_CAP = 300;
    }
}
