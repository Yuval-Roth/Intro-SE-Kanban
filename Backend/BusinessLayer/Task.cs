using System;

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
        TaskStates state;
        private string assignee;

        private readonly int MAX_DESCRIPTION_CHAR_CAP = 300;
        private readonly int MAX_TITLE_CHAR_CAP = 50;
        private readonly int MIN_TITLE_CHAR_CAP = 1;


        /// <summary>
        /// Build <c>Task</c> <br/> <br/>
        /// <b>Throws</b> <c>ArgumentException</c> if the title or description over their char cap, or due date is passed
        /// </summary>
        /// <param name="title"></param>
        /// <param name="duedate"></param>
        /// <param name="description"></param>
        /// <exception cref="ArgumentException"></exception>
        public Task(int id, string title, DateTime dueDate,string description)
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
            if (dueDate.CompareTo(DateTime.Today) < 0)
            {
                log.Error("Task() failed: due date was passed");
                throw new ArgumentException("due date was passed");
            }
            this.id = id;
            this.title = title;
            this.dueDate = dueDate;
            this.description = description;
            assignee = "unAssigned";
            creationTime = DateTime.Today;
            state = TaskStates.backlog;
            log.Debug("Task() success");
        }

        public Task(DataAccessLayer.TaskDTO taskDTO)
        {
            id = taskDTO.Id;
            title = taskDTO.Title;
            dueDate = taskDTO.DueDate;
            description = taskDTO.Description;
            assignee = taskDTO.Assignee;
            creationTime = taskDTO.CreationTime;
            state = (TaskStates)taskDTO.State;
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

        public string Assignee
        {
            get { return assignee; }
            init { assignee = value; }
        }
        public TaskStates State => state;

        /// <summary>
        /// Set <c>Task Title</c> to <c>Task</c> task <br/> <br/>
        /// <b>Throws</b> <c>ArgumentException</c> if the title over his char cap
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
        /// <b>Throws</b> <c>ArgumentException</c> if the Description over his char cap
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
        /// <b>Throws</b> <c>ArgumentException</c> if the due date has passed
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
        

        //====================================
        //            Functionality
        //====================================


        /// <summary>
        /// Advance <c>Task</c>
        /// <b>Throws</b> <c>ArgumentException</c> if the task can't be advanced<br/>
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public void AdvanceTask()
        {
            log.Debug("UpdateDescription() for taskId: " + id);
            if(state == TaskStates.done)
            {
                log.Error("AdvanceTask() failed: task numbered '" + id + "' is done and can't be advanced");
                throw new ArgumentException("task numbered '" + id + "' is done and can't be advanced");
            }
            state++;
            log.Debug("AdvanceTask() success");
        }

        public void AssignTask(string email, string emailAssignee)
        {
            log.Debug("AssignTask() for taskId: " + email + ", emailAssignee:" + emailAssignee);
            if (assignee!=email && assignee != "unAssigned")
            {
                log.Error("AssignTask() failed: task numbered '" + id + "' , email: '" + email + "' isn't the task's assignee");
                throw new FieldAccessException("email: '" + email + "' isn't the task's assignee");
            }
            if (assignee==email && email == emailAssignee)
            {
                log.Error("AssignTask() failed: task numbered '" + id + "' , email: '" + email + "' is already the assignee");
                throw new ElementAlreadyExistsException("email: '" + email + "' isn't the task's assignee");
            }
            assignee = emailAssignee;
            log.Debug("AssignTask() success");
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
