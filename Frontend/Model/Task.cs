using IntroSE.Kanban.Frontend.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Frontend.Model
{
    public class Task : Notifier
    {
        public int Id {
            get
            {
                return Id;
            }
            set
            {
                this.Id = value;
                RaisePropertyChanged("Id");
            }
        }
        public string Title {
            get
            {
                return Title;
            }
            set
            {
                this.Title = value;
                RaisePropertyChanged("Title");
            }
        }
        public string Description {
            get
            {
                return Title;
            }
            set
            {
                this.Title = value;
                RaisePropertyChanged("Title");
            }
        }
        public DateTime CreationTime {
            get
            {
                return CreationTime;
            }
            set
            {
                this.CreationTime = value;
                RaisePropertyChanged("CreationTime");
            }
        }
        public DateTime DueDate {
            get
            {
                return DueDate;
            }
            set
            {
                this.DueDate = value;
                RaisePropertyChanged("DueDate");
            }
        }
        public string Assignee {
            get
            {
                return Assignee;
            }
            set
            {
                this.Assignee = value;
                RaisePropertyChanged("Assignee");
            }
        }

        public Task(Backend.BusinessLayer.Task bTask)
        {
            Id = bTask.Id;
            Title = bTask.Title;
            Description = bTask.Description;
            CreationTime = bTask.CreationTime;
            DueDate = bTask.DueDate;
            Assignee = bTask.Assignee;
        }

    }


}
