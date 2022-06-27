using IntroSE.Kanban.Frontend.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Frontend.Model
{
    public class Board
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Owner { get; set; }
        public LinkedList<string>? Joined { get; set; }
        public LinkedList<Task>[]? Columns { get; set; }

        //public ObservableCollection<Task> BackLog
        //{
        //    get
        //    {
        //        return BackLog;
        //    }
        //    set
        //    {
        //        this.BackLog = value;
        //        RaisePropertyChanged("BackLog");
        //    }
        //}
        //public ObservableCollection<Task> InProgress
        //{
        //    get
        //    {
        //        return InProgress;
        //    }
        //    set
        //    {
        //        this.InProgress = value;
        //        RaisePropertyChanged("InProgress");
        //    }
        //}
        //public ObservableCollection<Task> Done
        //{
        //    get
        //    {
        //        return Done;
        //    }
        //    set
        //    {
        //        this.Done = value;
        //        RaisePropertyChanged("Done");
        //    }
        //}

        //public Board (Backend.BusinessLayer.Board BBoard)
        //{
        //    Id = BBoard.Id;
        //    Title = BBoard.Title;
        //    BackLog = BuildColumn (BBoard.Columns[(int)Backend.BusinessLayer.TaskStates.backlog]);
        //    InProgress = BuildColumn(BBoard.Columns[(int)Backend.BusinessLayer.TaskStates.inprogress]);
        //    Done = BuildColumn(BBoard.Columns[(int)Backend.BusinessLayer.TaskStates.done]);
        //}

        //private ObservableCollection<Task> BuildColumn(LinkedList<Backend.BusinessLayer.Task> tasks)
        //{
        //    ObservableCollection < Task > output = new ObservableCollection<Task>();
        //    foreach (var t in tasks)
        //    {
        //        Task task = new(t);
        //        output.Add(task);
        //    }
        //    return output;
        //}

        
    }
}
