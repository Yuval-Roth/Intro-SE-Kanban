using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    internal class Board
    {
        public string Title { get; set; }
        public LinkedList<Task> Backlog { get; set; }
        public LinkedList<Task> InProgress { get; set; }
        public LinkedList<Task> Done { get; set; }

        public LinkedList<Task> getTaskByType(Enum type) { return null; }
        public void addTask(String title, Date duedate, String description) { }
        public void removeTask(String title) { }
        public void advanceTask(String title) { }
        public Task searchTask(String title) { return null; }

    }
}
