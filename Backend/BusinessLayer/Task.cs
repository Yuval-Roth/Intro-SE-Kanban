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
            set {
                log.Debug("UpdateTitle() for taskId: " + id);
                if (value == null)
                {
                    log.Error("UpdateTitle() failed: '" + value + "' is null");
                    throw new NoSuchElementException("Title is null");
                }
                log.Debug("UpdateTitle() success");
                title = value;
                }
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
                dueDate = value;
                log.Debug("UpdateDueDate() success");
            }
        }
        public string Description
        {
            get { return description; }
            set {
                log.Debug("UpdateDescription() for taskId: " + id);
                if (value == null)
                {
                    log.Error("UpdateDescription() failed: '" + value + "' is null");
                    throw new NoSuchElementException("Description is null");
                }
                if(descriptionCharCap==true && value.Length > DESCRIPTION_CHAR_CAP)
                {
                    log.Error("UpdateDescription() failed: description is over the description limit");
                    throw new ArgumentException("Description is over the description limit");
                }
                log.Debug("UpdateDescription() success");
                description = value;
                }
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

        public void LimitDescription()
        {
            log.Debug("AdvanceTask() for taskId: " + id);
            if(description.Length> DESCRIPTION_CHAR_CAP)
            {
                log.Error("UpdateDescription() failed: " + description + " is over the limit");
                throw new ArgumentException(description + " is over the limit");
            }
            descriptionCharCap = true;
            log.Debug("LimitDescription() success");
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
