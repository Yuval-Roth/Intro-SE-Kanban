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
        private string title;
        private LinkedList<Task> backLog;
        private LinkedList<Task> inProgress;
        private LinkedList<Task> done;

        public Board(string title)
        {
            this.title = title;
        }
        public string Title
        { 
            get { return title; }
            set { title = value; }
        }
        public LinkedList<Task> Backlog
        { 
            get { return backLog; }
            set { backLog = value; }
        }
        public LinkedList<Task> InProgress
        {
            get { return inProgress; }
            set { inProgress = value; }
        }
        public LinkedList<Task> Done 
        {
            get { return done; } 
            set { done = value; }
        }

        public LinkedList<Task> GetTaskByType(Enum type) { return null; }
        public void AddTask(String title, Date duedate, String description) { }
        public void RemoveTask(String title) { }
        public void AdvanceTask(String title) { }
        public Task SearchTask(String title) { return null; }



        //====================================================
        //                  Json related
        //====================================================

        //[JsonConstructor]
        //public Board(string title, LinkedList<Task> backLog, LinkedList<Task> inProgress, LinkedList<Task> done)
        //{
        //    this.title = title;
        //    this.backLog = backLog;
        //    this.inProgress = inProgress;
        //    this.done = done;
        //}
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
