using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    
    public enum TaskStates
    {
        backLog,
        inProgress,
        done
    }
    public class Task
    {

        private string title;
        private string description;
        private Date creationTime;
        private Date dueDate;
        private TaskStates state;




        public string GetTitle() 
        {
            return title;
        
        }
    
        public Date CreationTime { get; set; }
        public Date DueDate { get; set; }
        public string Description { get; set; }
        public TaskStates State
        {
            get { return state; }
            set { state = value; }
        }
        public Boolean DescriptionCharCap { get; set; }
        public int DESCRIPTION_CHAR_CAP = 300;



        //====================================================
        //                  Json related
        //====================================================


        [JsonConstructor]
        public Task(string title, string description, Date creationTime, Date dueDate, TaskStates state)
        {
            this.title = title;
            this.description = description;
            this.creationTime = creationTime;
            this.dueDate = dueDate;
            this.state = state;
        }
       
        public Serializable.Task_Serializable GetSerializableInstance() 
        {
            return new Serializable.Task_Serializable()
            {
                Title = GetTitle(),
                Description = Description,
                CreationTime = CreationTime,
                DueDate = DueDate,
                State = State,
            };
        }
    }
}
