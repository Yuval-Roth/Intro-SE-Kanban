﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class TaskDTO
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public DateTime CreationTime { set; get; }
        public DateTime DueDate { set; get; }
        public BoardColumnNames State { set; get; }
        public string Assignee { set; get; }
    }
}
