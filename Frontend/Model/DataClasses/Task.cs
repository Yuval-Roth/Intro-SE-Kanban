using IntroSE.Kanban.Frontend.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Frontend.Model.DataClasses
{
    public class Task
    {

        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        //public int Id
        //{
        //    get
        //    {
        //        return Id;
        //    }
        //    set
        //    {
        //        Id = value;
        //        RaisePropertyChanged("Id");
        //    }
        //}
        //public string Title
        //{
        //    get
        //    {
        //        return Title;
        //    }
        //    set
        //    {
        //        Title = value;
        //        RaisePropertyChanged("Title");
        //    }
        //}
        //public string Description
        //{
        //    get
        //    {
        //        return Title;
        //    }
        //    set
        //    {
        //        Title = value;
        //        RaisePropertyChanged("Title");
        //    }
        //}
        //public DateTime CreationTime
        //{
        //    get
        //    {
        //        return CreationTime;
        //    }
        //    set
        //    {
        //        CreationTime = value;
        //        RaisePropertyChanged("CreationTime");
        //    }
        //}
        //public DateTime DueDate
        //{
        //    get
        //    {
        //        return DueDate;
        //    }
        //    set
        //    {
        //        DueDate = value;
        //        RaisePropertyChanged("DueDate");
        //    }
        //}
        //public string Assignee
        //{
        //    get
        //    {
        //        return Assignee;
        //    }
        //    set
        //    {
        //        Assignee = value;
        //        RaisePropertyChanged("Assignee");
        //    }
        //}

        //public Task(Backend.BusinessLayer.Task bTask)
        //{
        //    Id = bTask.Id;
        //    Title = bTask.Title;
        //    Description = bTask.Description;
        //    CreationTime = bTask.CreationTime;
        //    DueDate = bTask.DueDate;
        //    Assignee = bTask.Assignee;
        //}

    }


}
