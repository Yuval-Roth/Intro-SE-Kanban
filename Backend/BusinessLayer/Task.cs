using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    
    internal enum TaskStates
    {
        backLog,
        inProgress,
        done
    }

    public class Task
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Backend\\BusinessLayer\\Task.cs");

        private int id;
        private DateTime creationTime;
        private string title;
        private string description;
        private DateTime dueDate;

        private TaskStates state;
        private bool descriptionCharCap;
        private readonly int DESCRIPTION_CHAR_CAP = 300;

        public Task(int id, string title, DateTime duedate,string description)
        {
            this.id = id;
            this.title = title;
            this.dueDate = duedate;
            this.description = description;
            creationTime = new DateTime();
            state = TaskStates.backLog;
            descriptionCharCap= false;
        }


        //====================================
        //            getters/setters
        //====================================

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Title 
        {
            get { return title; }
            set { title = value; }
        }
    
        public DateTime CreationTime 
        {
            get { return creationTime; }
            set { creationTime = value; } 
        }
        public DateTime DueDate 
        {
            get { return dueDate; }
            set {
                log.Debug("UpdateDueDate() for taskId: " + id);
                if (value == null)
                {
                    log.Error("AdvanceTask() failed: value is null");
                    throw new NoSuchElementException("value is null");
                }
                dueDate = value; 
                }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public bool DescriptionCharCap
        {
            get { return descriptionCharCap; }
            set { descriptionCharCap = value;}
        }

        //====================================
        //            Functionality
        //====================================

        public void AdvanceTask()
        {
            log.Debug("AdvanceTask() for taskId: " + id);
            if(state == TaskStates.done)
            {
                log.Error("AdvanceTask() failed: '" + id + "' is done");
                throw new ArgumentException("the task '" +
                    id + "' is already done");
            }
            state++;
            log.Debug("AdvanceTask() success");
        }



        //====================================================
        //                  Json related
        //====================================================

        //[JsonConstructor]
        //public Task(string Title, string Description, Date CreationTime, Date DueDate, TaskStates State, bool DescriptionCharCap)
        //{
        //    title = Title;
        //    description = Description;
        //    creationTime = CreationTime;
        //    dueDate = DueDate;
        //    state = State;
        //    descriptionCharCap = DescriptionCharCap;
        //}

        public Serializable.Task_Serializable GetSerializableInstance() 
        {
            return new Serializable.Task_Serializable()
            {
                Id = id,
                CreationTime = creationTime,
                Title = title,
                Description = description,
                DueDate = dueDate,
            };
        }
    }
}
