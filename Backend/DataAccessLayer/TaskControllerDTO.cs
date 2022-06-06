using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class TaskControllerDTO
    {
        private SQLExecuter executer;

        public bool AdvanceTask(int boardId, int taskId, TaskStates state)
        {
            string command = "UPDATE Tasks" +
                            $"SET State = {(int)state}" +
                            $"WHERE BoardId = {boardId}, TaskId = {taskId}";

            return executer.Execute(command);
        }
        public bool ChangeTitle(string title, int boardId, int taskId)
        {
            string command = "UPDATE Tasks" +
                            $"SET TaskTitle = {title}" +
                            $"WHERE BoardId = {boardId}, TaskId = {taskId}";

            return executer.Execute(command);
        }
        public bool ChangeDescription(string description, int boardId, int taskId)
        {
            string command = "UPDATE Tasks" +
                            $"SET Description = {description}" +
                            $"WHERE BoardId = {boardId}, TaskId = {taskId}";

            return executer.Execute(command);
        }
        public bool ChangeAssignee(string email, int boardId, int taskId)
        {
            string command = "UPDATE Tasks" +
                            $"SET Assignee = {email}" +
                            $"WHERE BoardId = {boardId}, TaskId = {taskId}";

            return executer.Execute(command);
        }
        public bool ChangeDueDate(DateTime dueDate, int boardId, int taskId)
        {
            string command = "UPDATE Tasks" +
                            $"SET DueDate = {dueDate.Year}/{dueDate.Month}/{dueDate.Day}" +
                            $"WHERE BoardId = {boardId}, TaskId = {taskId}";

            return executer.Execute(command);
        }
    }
}
