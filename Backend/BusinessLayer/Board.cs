using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class Board
    {
        private string title;
        public Board(string title)
        {
            this.title = title;
        }
        public string GetTitle() { return title; }
        public void SetTitle() { }
        public LinkedList<Task> Backlog { get; set; }
        public LinkedList<Task> InProgress { get; set; }
        public LinkedList<Task> Done { get; set; }

        public LinkedList<Task> GetTaskByType(Enum type) { return null; }
        public void AddTask(String title, Date duedate, String description) { }
        public void RemoveTask(String title) { }
        public void AdvanceTask(String title) { }
        public Task SearchTask(String title) { return null; }

    }
}
