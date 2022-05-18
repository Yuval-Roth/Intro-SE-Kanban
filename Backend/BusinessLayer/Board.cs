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

        private int counterID;
        private string title;
        private Dictionary<int, LinkedList<Task>> columns;
        private int [] columnLimit;

        //====================================
        //            getters/setters
        //====================================

        public Board(string title)
        {
            this.title = title;
            counterID = 0;
            columnLimit = new int[3];
            columns = new();
            columnLimit[(int)TaskStates.backlog] = -1;
            columnLimit[(int)TaskStates.inprogress] = -1;
            columnLimit[(int)TaskStates.done] = -1;
            columns.Add((int)TaskStates.backlog, new LinkedList<Task>());
            columns.Add((int)TaskStates.inprogress, new LinkedList<Task>());
            columns.Add((int)TaskStates.done, new LinkedList<Task>());
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
            log.Debug("AddTask() for taskId: " + title + ", " + description + ", " + duedate);
            if (columnLimit[(int)TaskStates.backlog] !=-1 && columns[(int)TaskStates.backlog] !=null && columns[(int)TaskStates.backlog].Count() == columnLimit[(int)TaskStates.backlog])
            {
                log.Error("AddTask() failed: board '" + this.title + "' has a limit and can't contains more task");
                throw new ArgumentException("A board titled " +
                        this.title + " has a limit and can't contains more task");
            }
            try
            {
                LinkedList<Task> list = columns[(int)TaskStates.backlog];
                list.AddLast(new Task(counterID, title, duedate, description));
                counterID++;
                columns[(int)TaskStates.backlog] = list;
                log.Debug("AddTask() success");
            }
            catch (NoSuchElementException e)
            {
                log.Error("AddTask() failed: '" + e.Message);
                throw new NoSuchElementException(e.Message);
            }
            catch (ArgumentException e)
            {
                log.Error("AddTask() failed: '" + e.Message);
                throw new ArgumentException(e.Message);
            }
        }


        /// <summary>
        /// Remove <c>Task</c> from <c>Board</c> board <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if the task isn't exist
        /// </summary>
        /// <param name="taskId"></param>
        /// <exception cref="ArgumentException"></exception>
        public void RemoveTask(int taskId)
        {
            log.Debug("RemoveTask() taskId: " + taskId);
            bool found = false;
            for (int i = 0; i < columns.Count; i++)
            {
                foreach (Task task in columns[i])
                {
                    if (task.Id == taskId) { found = true; columns[i].Remove(task); break; }
                }
                if (found) { break; }
            }
            if (!found)
            {
                log.Error("RemoveTask() failed: '" + taskId + "' doesn't exist");
                throw new NoSuchElementException("A Task with the taskId '" +
                    taskId + "' doesn't exist in the Board");
            }
            else { log.Debug("RemoveTask() success"); }
        }


        /// <summary>
        /// Advance <c>Task</c> from <c>Board</c> board <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if the task isn't exist int the column, or column is illegal, or next column is reach the limit
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="columnOrdinal"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AdvanceTask(int columnOrdinal, int taskId)
        {
            log.Debug("AdvanceTask() for column and taskId: " + columnOrdinal + ", " + taskId);
            if (columnOrdinal < (int)TaskStates.backlog || columnOrdinal > (int)TaskStates.done) 
            {
                log.Error("AdvanceTask() failed: '" + columnOrdinal + "' doesn't exist");
                throw new NoSuchElementException("A column '" +
                    columnOrdinal + "' doesn't exist in the Board");
            }
            bool found = false;
            foreach(Task task in columns[columnOrdinal])
            {
                if (task.Id == taskId) { found=true; break; }
            }
            if (!found)
            {
                log.Error("AdvanceTask() failed: '" + taskId + "' doesn't found in the column " + (TaskStates)columnOrdinal);
                throw new NoSuchElementException("the task '" +
                    taskId + "'doesn't found in the column " + (TaskStates)columnOrdinal);
            }
            if ((TaskStates)columnOrdinal == TaskStates.done)
            {
                log.Error("AdvanceTask() failed: '" + (TaskStates)columnOrdinal + "' value is done");
                throw new ArgumentException("the task '" +
                    taskId + "' is already done");
            }
            int nextcolumnordinal = columnOrdinal + 1;
            if(columns[nextcolumnordinal].Count() == columnLimit[nextcolumnordinal])
            {
                log.Error("AdvanceTask() failed: '" + taskId + "' the next column " + (TaskStates)nextcolumnordinal + "'is over the limit");
                throw new ArgumentException("'the next column " + (TaskStates)nextcolumnordinal + "'is over the limit");
            }
            Task toAdvance = SearchTask(taskId);
            columns[columnOrdinal].Remove(toAdvance);
            columns[nextcolumnordinal].AddLast(toAdvance);
            log.Debug("AdvanceTask() success");
        }


        /// <summary>
        /// Search <c>Task</c> from <c>Board</c> board <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if the task isn't exist or column is illegal
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="columnOrdinal"></param>
        /// <exception cref="ArgumentException"></exception>
        public Task SearchTask(int taskId, int columnOrdinal)
        {
            log.Debug("SearchTask() taskId: " + taskId + " ,columnOrdinal: " + columnOrdinal);
            if ((columnOrdinal < (int)TaskStates.backlog || columnOrdinal > (int)TaskStates.done)){
                log.Error("AdvanceTask() failed: '" + columnOrdinal + "' doesn't exist");
                throw new NoSuchElementException("A column '" +
                    columnOrdinal + "' doesn't exist in the Board");
            }
            LinkedList<Task> list = columns[columnOrdinal];
            foreach (Task task in list)
            {
                if (task.Id == taskId) { log.Debug("SearchTask() success"); return task; }
            }
            log.Error("SearchTask() failed: '" + taskId + "' doesn't exist");
            throw new NoSuchElementException("A Task with the taskId '" +
                taskId + "' doesn't exist in the Board");
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
            for (int i = 0; i < columns.Count; i++)
            {
                LinkedList<Task> list = columns[i];
                foreach (Task task in list)
                {
                    if (task.Id == taskId) {log.Debug("SearchTask() success"); return task; }
                }
            }   
                log.Error("SearchTask() failed: '" + taskId + "' doesn't exist");
                throw new NoSuchElementException("A Task with the taskId '" +
                    taskId + "' doesn't exist in the Board");
        }

        /// <summary>
        /// Get<c>column limit</c> from <c>Board</c> board <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if column isn't exist or column has no limit
        /// </summary>
        /// <param name="columnOrdinal"></param>
        /// <returns>int column limit, unless an error occurs</returns>
        /// <exception cref="ArgumentException"></exception>
        public int GetColumnLimit(int columnOrdinal)
        {
            log.Debug("GetColumnLimit() columnOrdinal: " + columnOrdinal);
            if (columnOrdinal < (int)TaskStates.backlog || columnOrdinal > (int)TaskStates.done)
            {
                log.Error("GetColumnLimit() failed: '" + columnOrdinal + "' doesn't exist");
                throw new NoSuchElementException("A column '" +
                    columnOrdinal + "' doesn't exist in the Board");
            }
            if (columnLimit[columnOrdinal] == -1)
            {
                log.Error("GetColumnLimit() failed: '" + (TaskStates)columnOrdinal + "' has no limit");
                throw new ArgumentException("A column '" +
                    (TaskStates)columnOrdinal + "' has no limit");
            }
            log.Debug("GetColumnLimit() success");
            return columnLimit[columnOrdinal];
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
            log.Debug("GetColumnName() columnOrdinal: " + columnOrdinal);
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
            log.Debug("GetColumn() columnOrdinal: " + columnOrdinal);
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
            log.Debug("LimitColumn() for column and limit: " + columnOrdinal + ", " + limit);
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
            log.Debug("UnimitColumn() for column: " + columnOrdinal);
            if (columnOrdinal < (int)TaskStates.backlog || columnOrdinal > (int)TaskStates.done)
            {
                log.Error("LimitColumn() failed: '" + columnOrdinal + "' doesn't exist");
                throw new NoSuchElementException("A column '" +
                    columnOrdinal + "' doesn't exist in the Board");
            }
            log.Debug("LimitColumn() success");
            columnLimit[columnOrdinal] = -1;
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
