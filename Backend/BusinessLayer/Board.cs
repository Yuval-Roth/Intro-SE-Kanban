using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IntroSE.Kanban.Backend.BusinessLayer
{

    /// <summary>
    ///This class controls the actions users' board.<br/>
    ///<br/>
    ///<code>Supported operations:</code>
    ///<br/>
    /// <list type="bullet">AddTask()</list>
    /// <list type="bullet">RemoveTask()</list>
    /// <list type="bullet">AdvanceTask()</list>
    /// <list type="bullet">SearchTask()</list>
    /// <list type="bullet">GetColumnLimit()</list>
    /// <list type="bullet">GetColumnName()</list>
    /// <list type="bullet">GetColumn()</list>
    /// <list type="bullet">LimitColumn()</list>
    /// <list type="bullet">UnlimitColumn()</list>
    /// <br/><br/>
    /// ===================
    /// <br/>
    /// <c>Ⓒ Kfir Nissim</c>
    /// <br/>
    /// ===================
    /// </summary>

    public class Board
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Backend\\BusinessLayer\\Board.cs");

        static public int taskIDCounter;
        private string title;
        private LinkedList<Task>[] columns;
        private int [] columnLimit;
        private Dictionary<int, TaskStates> taskStateTracker;

        //====================================
        //            getters/setters
        //====================================

        public Board(string title)
        {
            this.title = title;
            columnLimit = new int[3];
            columns = new LinkedList<Task>[3];
            columnLimit[(int)TaskStates.backlog] = -1;
            columnLimit[(int)TaskStates.inprogress] = -1;
            columnLimit[(int)TaskStates.done] = -1;
            columns[(int)TaskStates.backlog] = new LinkedList<Task>();
            columns[(int)TaskStates.inprogress] = new LinkedList<Task>();
            columns[(int)TaskStates.backlog] = new LinkedList<Task>();
            taskStateTracker = new();
        }
        public string Title
        { 
            get { return title; }
            set { title = value; }
        }


        //====================================
        //            Functionality
        //====================================


        

        /// <summary>
        /// Add new <c>Task</c> to <c>Board</c> board <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if the backlog column reach the limit
        /// </summary>
        /// <param name="title"></param>
        /// <param name="duedate"></param>
        /// <param name="description"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddTask(string title, DateTime duedate, string description)
        {
            log.Debug("AddTask() for: " + title + ", " + description + ", " + duedate);
            if (columns[(int)TaskStates.backlog].Count != columnLimit[(int)TaskStates.backlog])
            {
                columns[(int)TaskStates.backlog].AddLast(new Task(taskIDCounter, title, duedate, description));
                taskStateTracker.Add(taskIDCounter, TaskStates.backlog);
                taskIDCounter++;
                log.Debug("AddTask() success");
            }
            else 
            {
                log.Error("AddTask() failed: board '" + this.title + "' has reached its limit and can't contain more tasks");
                throw new ArgumentException("A board titled " +
                        this.title + " has a limit and can't contains more task");
            }
        }


        /// <summary>
        /// Remove <c>Task</c> from <c>Board</c> board <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if the task isn't exist
        /// </summary>
        /// <param name="taskID"></param>
        /// <exception cref="ArgumentException"></exception>
        public void RemoveTask(int taskId)
        {
            log.Debug("RemoveTask() taskId: " + taskId);
            if (taskStateTracker.ContainsKey(taskId))
            {
                LinkedList<Task> taskList = columns[(int)taskStateTracker[taskId]];
                foreach (Task task in taskList)
                {
                    if (task.Id == taskId)
                    {
                        taskList.Remove(task);
                        taskStateTracker.Remove(taskId);
                        log.Debug("RemoveTask() success");
                        break;
                    }
                }       
            }
            else
            {
                log.Error("RemoveTask() failed: task numbered '" + taskId + "' doesn't exist");
                throw new NoSuchElementException("A Task with the taskId '" +
                    taskId + "' doesn't exist in the Board");
            }
        }


        /// <summary>
        /// Advance <c>Task</c> from <c>Board</c> board <br/> <br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if the task doesn't exist at all or is not in the specified column<br/>
        /// <b>Throws</b> <c>ArgumentException</c> if the task can't be advanced<br/>
        /// <b>Throws</b> <c>IndexOutOfRangeException</c> if the column is not a valid column number
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="columnOrdinal"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AdvanceTask(int columnOrdinal, int taskId)
        {
            log.Debug("AdvanceTask() for column and taskId: " + (TaskStates)columnOrdinal + ", " + taskId);
            ValidateColumnOrdinal(columnOrdinal);

            if (taskStateTracker.ContainsKey(taskId))
            {
                TaskStates state = taskStateTracker[taskId];
                if ((int)state == columnOrdinal)
                {
                    if (state != TaskStates.done)
                    {
                        Task toAdvance = SearchTask(taskId);
                        columns[(int)state].Remove(toAdvance);
                        columns[(int)state+1].AddLast(toAdvance);
                        taskStateTracker[taskId] = state+1;
                        log.Debug("AdvanceTask() success");
                    }
                    else
                    {
                        log.Error("AdvanceTask() failed: task numbered '" + taskId + "' is done and can't be advanced");
                        throw new ArgumentException("task numbered '" + taskId + "' is done and can't be advanced");
                    }
                }
                else
                {
                    log.Error("AdvanceTask() failed: task numbered '" + taskId + "'isn't in the column " + (TaskStates)columnOrdinal);
                    throw new NoSuchElementException("the task '" +
                        taskId + "'doesn't found in the column " + (TaskStates)columnOrdinal);
                }
            }
            else
            {
                log.Error("AdvanceTask() failed: task numbered '" + taskId + "' doesn't exist");
                throw new NoSuchElementException("task numbered '" + taskId + "' doesn't exist");
            }
            
        }


        /// <summary>
        /// Search <c>Task</c> from <c>Board</c> board <br/> <br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if the task doesn't exist in the specified column <br/>
        /// <b>Throws</b> <c>IndexOutOfRangeException</c> if the column is not a valid column number
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="columnOrdinal"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Task SearchTask(int taskId, int columnOrdinal)
        {
            log.Debug("SearchTask() taskId, columnOrdinal: " + taskId + ", " + columnOrdinal);
            ValidateColumnOrdinal(columnOrdinal);

            LinkedList<Task> taskList = columns[columnOrdinal];
            foreach (Task task in taskList)
            {
                if (task.Id == taskId)
                {
                    log.Debug("SearchTask() success");
                    return task;
                }
            }
            log.Error("SearchTask() failed: A task numbered '" + taskId +
                "' doesn't exist in column '" + columnOrdinal + "'");
            throw new NoSuchElementException("A Task with the taskId '" +
                taskId + "' doesn't exist in column '" + columnOrdinal + "'");
        }

        /// <summary>
        /// Search <c>Task</c> from <c>Board</c> board <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if the task isn't exist
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns>Task, unless an error occurs</returns>
        /// <exception cref="ArgumentException"></exception>
        public Task SearchTask(int taskId) 
        {
            log.Debug("SearchTask() taskId: " + taskId);
            if (taskStateTracker.ContainsKey(taskId))
            {
                LinkedList<Task> taskList = columns[(int)taskStateTracker[taskId]];
                foreach (Task task in taskList)
                {
                    if (task.Id == taskId)
                    {
                        log.Debug("SearchTask() success");
                        return task;
                    }
                }
                //======================================================================================================
                // this part of the code should generally never run. if it does, there is a serious problem somewhere.
                //======================================================================================================
                log.Fatal("FATAL ERROR: task numbered"+taskId +"exists in the taskStateTracker and not in the column '"+
                    taskStateTracker[taskId] + "' where it's supposed to be");
                throw new OperationCanceledException("FATAL ERROR: task numbered" + taskId +
                    "exists in the taskStateTracker and not in the column '" +
                    taskStateTracker[taskId] + "' where it's supposed to be");
                //======================================================================================================
            }
            else
            {
                log.Error("SearchTask() failed: A task numbered '" + taskId + "' doesn't exist");
                throw new NoSuchElementException("A Task with the taskId '" +
                    taskId + "' doesn't exist in the Board");
            }           
        }

        /// <summary>
        /// Get<c>column limit</c> from <c>Board</c> board <br/> <br/>
        /// <b>Throws</b> <c>ArgumentException</c> if the column doesn't have a limit <br/>
        /// <b>Throws</b> <c>IndexOutOfRangeException</c> if the column is not a valid column number
        /// </summary>
        /// <param name="columnOrdinal"></param>
        /// <returns>int column limit, unless an error occurs</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int GetColumnLimit(int columnOrdinal)
        {
            log.Debug("GetColumnLimit() columnOrdinal: " + columnOrdinal);
            ValidateColumnOrdinal(columnOrdinal);

            if (columnLimit[columnOrdinal] != -1)
            {
                log.Debug("GetColumnLimit() success");
                return columnLimit[columnOrdinal];
            }
            else 
            {
                log.Error("GetColumnLimit() failed: '" + (TaskStates)columnOrdinal + "' has no limit");
                throw new ArgumentException("the column '" +
                    (TaskStates)columnOrdinal + "' has no limit");
            }
            //else
            //{
            //    return -1;
            //}
            
        }


        /// <summary>
        /// Get<c>column name</c> from <c>Board</c> board <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if column isn't exist
        /// </summary>
        /// <param name="columnOrdinal"></param>
        /// <returns>column name, unless an error occurs</returns>
        /// <exception cref="ArgumentException"></exception>
        public string GetColumnName(int columnOrdinal)
        {
            log.Debug("GetColumnName() columnOrdinal: " + (TaskStates)columnOrdinal);
            if (columnOrdinal < (int)TaskStates.backlog || columnOrdinal > (int)TaskStates.done)
            {
                log.Error("GetColumnName() failed: '" + columnOrdinal + "' doesn't exist");
                throw new NoSuchElementException("A column '" +
                    columnOrdinal + "' doesn't exist in the Board");
            }
            
            log.Debug("GetColumnName() success");
            return ((TaskStates) columnOrdinal).ToString();
        }

        /// <summary>
        /// Get<c>column</c> from <c>Board</c> board <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if column isn't exist
        /// </summary>
        /// <param name="columnOrdinal"></param>
        /// <returns>LinkedList of task, unless an error occurs</returns>
        /// <exception cref="ArgumentException"></exception>
        public LinkedList<Task> GetColumn(int columnOrdinal)
        {
            log.Debug("GetColumn() columnOrdinal: " + (TaskStates)columnOrdinal);
            if (columnOrdinal < (int)TaskStates.backlog || columnOrdinal > (int)TaskStates.done)
            {
                log.Error("GetColumn() failed: '" + columnOrdinal + "' doesn't exist");
                throw new NoSuchElementException("A column '" +
                    columnOrdinal + "' doesn't exist in the Board");
            }

            log.Debug("GetColumn() success");
            return columns[columnOrdinal];
        }

        /// <summary>
        /// Limit<c>column</c> from <c>Board</c> board <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if column isn't exist or limit is illegal or column is over thr limit
        /// </summary>
        /// <param name="columnOrdinal"></param>
        /// <param name="limit"></param>
        /// <exception cref="ArgumentException"></exception>
        public void LimitColumn(int columnOrdinal, int limit)
        {
            log.Debug("LimitColumn() for column and limit: " + (TaskStates)columnOrdinal + ", " + limit);
            if (limit < 0)
            {
                log.Error("LimitColumn() failed: '" + limit + "' the limit is negative");
                throw new NoSuchElementException("A limit '" +
                    limit + "' is negative");
            }
            if (columnOrdinal < (int)TaskStates.backlog || columnOrdinal > (int)TaskStates.done)
            {
                log.Error("LimitColumn() failed: '" + columnOrdinal + "' doesn't exist");
                throw new NoSuchElementException("A column '" +
                    columnOrdinal + "' doesn't exist in the Board");
            }
            if (columns[columnOrdinal].Count > limit)
            {
                log.Error("LimitColumn() failed: '" + (TaskStates)columnOrdinal + "' size is bigger than th limit " +limit);
                throw new NoSuchElementException("A column '" +
                    (TaskStates)columnOrdinal + "' size is bigger than th limit " + limit);
            }
            log.Debug("LimitColumn() success");
            columnLimit[columnOrdinal] = limit;
        }

        /// <summary>
        /// Unlimit<c>column</c> from <c>Board</c> board <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if column isn't exist
        /// </summary>
        /// <param name="columnOrdinal"></param>
        /// <exception cref="ArgumentException"></exception>
        public void UnlimitColumn(int columnOrdinal)
        {
            log.Debug("UnimitColumn() for column: " + (TaskStates)columnOrdinal);
            if (columnOrdinal < (int)TaskStates.backlog || columnOrdinal > (int)TaskStates.done)
            {
                log.Error("LimitColumn() failed: '" + columnOrdinal + "' doesn't exist");
                throw new NoSuchElementException("A column '" +
                    columnOrdinal + "' doesn't exist in the Board");
            }
            log.Debug("LimitColumn() success");
            columnLimit[columnOrdinal] = -1;
        }

        private void ValidateColumnOrdinal(int columnOrdinal)
        {
            if (columnOrdinal < (int)TaskStates.backlog | columnOrdinal > (int)TaskStates.done)
            {
                log.Error("AdvanceTask() failed: '" + columnOrdinal + "' is not a valid column number");
                throw new IndexOutOfRangeException("The column '" + columnOrdinal + "' is not a valid column number");
            }
        }

        //====================================================
        //                  Json related
        //====================================================

        public Serializable.Board_Serializable GetSerializableInstance() 
        {
            LinkedList<Serializable.Task_Serializable> serializableBackLog = new();
            foreach (Task task in columns[(int) TaskStates.backlog])
            {
                serializableBackLog.AddLast(task.GetSerializableInstance());
            }

            LinkedList<Serializable.Task_Serializable> serializableInProgress = new();
            foreach (Task task in columns[(int)TaskStates.inprogress])
            {
                serializableInProgress.AddLast(task.GetSerializableInstance());
            }

            LinkedList<Serializable.Task_Serializable> serializableDone = new();
            foreach (Task task in columns[(int)TaskStates.done])
            {
                serializableDone.AddLast(task.GetSerializableInstance());
            }
            return new Serializable.Board_Serializable()
            {
                Title = title,
                Backlog = serializableBackLog,
                InProgress = serializableInProgress,
                Done = serializableDone,
            };
        }
    }
}
