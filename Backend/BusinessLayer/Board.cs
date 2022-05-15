using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
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
            columnLimit[0] = -1;
            columnLimit[1] = -1;
            columnLimit[2] = -1;
            columns.Add(0, new LinkedList<Task>());
            columns.Add(1, new LinkedList<Task>());
            columns.Add(2, new LinkedList<Task>());
        }
        public string Title
        { 
            get { return title; }
            set { title = value; }
        }


        //====================================
        //            Functionality
        //====================================

        public LinkedList<Task> GetTaskByType(Enum type) { return null; }
        public void AddTask(String title, DateTime duedate, String description)
        {
            if (columnLimit[0]!=-1 && columns[0]!=null && columns[0].Count() + 1 == columnLimit[0])
            {
                log.Error("AddTask() failed: board '" + this.title + "' has a limit and can't contains more task");
                throw new ArgumentException("A board titled " +
                        this.title + " has a limit and can't contains more task");
            }
            LinkedList<Task> list = columns[0];
            list.AddLast(new Task(counterID, title, duedate, description));
            counterID++;
            columns[0]= list;
            log.Debug("AddTask() success");
        }
        public void RemoveTask(String title) { }
        public void AdvanceTask(String title) { }
        public Task SearchTask(String title) { return null; }



        //====================================================
        //                  Json related
        //====================================================

        public Serializable.Board_Serializable GetSerializableInstance() 
        {
            LinkedList<Serializable.Task_Serializable> serializableBackLog = new();
            foreach (Task task in Backlog)
            {
                serializableBackLog.AddLast(task.GetSerializableInstance());
            }

            LinkedList<Serializable.Task_Serializable> serializableInProgress = new();
            foreach (Task task in inProgress)
            {
                serializableInProgress.AddLast(task.GetSerializableInstance());
            }

            LinkedList<Serializable.Task_Serializable> serializableDone = new();
            foreach (Task task in done)
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
