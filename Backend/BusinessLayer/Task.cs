using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IntroSE.Kanban.Backend.BusinessLayer
{


    /// <summary>
    ///This class controls the actions users' task.<br/>
    ///<br/>
    ///<code>Supported operations:</code>
    ///<br/>
    /// <list type="bullet">Task()</list>
    /// <list type="bullet">AdvanceTask()</list>
    /// <list type="bullet">SetTitle()</list>
    /// <list type="bullet">SetDescription()</list>
    /// <list type="bullet">SetDueDate()</list>
    /// <br/><br/>
    /// ===================
    /// <br/>
    /// <c>Ⓒ Kfir Nissim</c>
    /// <br/>
    /// ===================
    /// </summary>


    public class Task
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Backend\\BusinessLayer\\Task.cs");

        private readonly int id;
        private readonly DateTime creationTime;
        private string title;
        private string description;
        private DateTime dueDate;

        private TaskStates state;
        private readonly int MAX_DESCRIPTION_CHAR_CAP = 300;
        private readonly int MAX_TITLE_CHAR_CAP = 50;
        private readonly int MIN_TITLE_CHAR_CAP = 1;


        /// <summary>
        /// Build <c>Task</c> <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if the title or description over their char cap, or due date is passed
        /// </summary>
        /// <param name="title"></param>
        /// <param name="duedate"></param>
        /// <param name="description"></param>
        /// <exception cref="ArgumentException"></exception>
        public Task(int id, string title, DateTime duedate,string description)
        {
            log.Debug("Task() for id: " + id);
            if (title.Length < MIN_TITLE_CHAR_CAP)
            {
                log.Error("Task() failed: title is empty");
                throw new ArgumentException("title is empty");
            }
            if (title.Length > MAX_TITLE_CHAR_CAP)
            {
                log.Error("Task() failed: title is over the limit");
                throw new ArgumentException("title is over the limit");
            }
            if (description.Length > MAX_DESCRIPTION_CHAR_CAP)
            {
                log.Error("Task() failed: description is over the limit");
                throw new ArgumentException("description is over the limit");
            }
            if(duedate.CompareTo(DateTime.Now) < 1)
            {
                log.Error("Task() failed: due date was passed");
                throw new ArgumentException("due date was passed");
            }
            this.id = id;
            this.title = title;
            this.dueDate = duedate;
            this.description = description;
            creationTime = DateTime.Today;
            state = TaskStates.backlog;
            log.Debug("Task() success");
        }


        //====================================
        //            getters/setters
        //====================================

        public int Id
        {
            get { return id; }
            init { id = value; }
        }

        public DateTime CreationTime
        {
            get { return creationTime; }
            init { creationTime = value; }
        }

        /// <summary>
        /// Set <c>Task Title</c> to <c>Task</c> task <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if the title over his char cap
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public string Title 
        {
            get { return title; }
            set {
                log.Debug("UpdateTitle() for taskId: " + id);
                if (state == TaskStates.done)
                {
                    log.Error("UpdateTitle() failed: " + id + "is done");
                    throw new ArgumentException("the task '" +
                        Id + "' is already done");
                }
                if (value.Length < MIN_TITLE_CHAR_CAP)
                {
                    log.Error("UpdateTitle() failed: title is empty");
                    throw new ArgumentException("title is empty");
                }
                if (value.Length > MAX_TITLE_CHAR_CAP)
                {
                    log.Error("UpdateTitle() failed: title is over the limit");
                    throw new ArgumentException("title is over the limit");
                }
                log.Debug("UpdateTitle() success");
                title = value;
                }
        }

        /// <summary>
        /// Set <c>Task Description</c> to <c>Task</c> task <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if the Description over his char cap
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public string Description
        {
            get { return description; }
            set
            {
                log.Debug("UpdateDescription() for taskId: " + id);
                if (state == TaskStates.done)
                {
                    log.Error("UpdateDescription() failed: " + id + "is done");
                    throw new ArgumentException("the task '" +
                        Id + "' is already done");
                }
                if (value.Length > MAX_DESCRIPTION_CHAR_CAP)
                {
                    log.Error("UpdateDescription() failed: description is over the limit");
                    throw new ArgumentException("description is over the limit");
                }
                log.Debug("UpdateDescription() success");
                description = value;
            }
        }


        /// <summary>
        /// Set <c>Task DueDate</c> to <c>Task</c> task <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if the due date is passed
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public DateTime DueDate 
        {
            get { return dueDate; }
            set {
                log.Debug("UpdateDueDate() for taskId: " + id);
                if (state == TaskStates.done)
                {
                    log.Error("UpdateDueDate() failed: " + id + "is done");
                    throw new ArgumentException("the task '" +
                        Id + "' is already done");
                }
                if (value.CompareTo(DateTime.Today) < 0)
                {
                    log.Error("UpdateDueDate() failed: due date was passed");
                    throw new ArgumentException("due date was passed");
                }
                dueDate = value;
                log.Debug("UpdateDueDate() success");
            }
        }


        //====================================================
        //                  Json related
        //====================================================

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
