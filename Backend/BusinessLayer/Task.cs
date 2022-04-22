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
        private bool descriptionCharCap;
        private readonly int DESCRIPTION_CHAR_CAP = 300;




        public string Title 
        {
            get { return title; }
            set { title = value; }
        }
    
        public Date CreationTime 
        {
            get { return creationTime; }
            set { creationTime = value; } 
        }
        public Date DueDate 
        {
            get { return dueDate; }
            set { dueDate = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public TaskStates State
        {
            get { return state; }
            set { state = value; }
        }
        public Boolean DescriptionCharCap
        {
            get { return descriptionCharCap; }
            set { descriptionCharCap = value;}
        }
        



        //====================================================
        //                  Json related
        //====================================================
     
        //[JsonConstructor]
        //public Task(string title, string description, Date creationTime, Date dueDate, TaskStates state)
        //{
        //    this.title = title;
        //    this.description = description;
        //    this.creationTime = creationTime;
        //    this.dueDate = dueDate;
        //    this.state = state;
        //}
       
        public Serializable.Task_Serializable GetSerializableInstance() 
        {
            return new Serializable.Task_Serializable()
            {
                Title = Title,
                Description = Description,
                CreationTime = CreationTime,
                DueDate = DueDate,
                State = State,
            };
        }
    }
}
