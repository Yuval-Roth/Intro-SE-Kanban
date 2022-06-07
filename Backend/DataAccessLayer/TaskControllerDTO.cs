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

        public bool AddTask(int boardId, TaskDTO task)
        {
            string command = "INSERT INTO Tasks(BoardId, TaskId, TaskTitle, Assignee, Description, CreationTime, DueDate, State)"+
                             $"VALUES({boardId},{task.Id},'{task.Title}','{task.Assignee}','{task.Description}','{task.CreationTime}'," +
                             $"'{task.DueDate.Year}/{task.DueDate.Month}/{task.DueDate.Day}',{(int)task.State})";

            return executer.ExecuteWrite(command);
        }
        public bool RemoveTask(int boardId, int TaskId)
        {
            return executer.ExecuteWrite("DELETE FROM Tasks" +
            $"WHERE BoardId = {boardId} and TaskId = {TaskId}");
        }
        public bool ChangeTaskState(int boardId, int taskId, BoardColumnNames state)
        {
            string command = "UPDATE Tasks" +
                            $"SET State = {(int)state}" +
                            $"WHERE BoardId = '{boardId}' and TaskId = '{taskId}'";

            return executer.ExecuteWrite(command);
        }
        public bool ChangeTitle(string title, int boardId, int taskId)
        {
            string command = "UPDATE Tasks" +
                            $"SET TaskTitle = '{title}' " +
                            $"WHERE BoardId = {boardId} and TaskId = {taskId}";

            return executer.ExecuteWrite(command);
        }
        public bool ChangeDescription(string description, int boardId, int taskId)
        {
            string command = "UPDATE Tasks" +
                            $"SET Description = '{description}'" +
                            $"WHERE BoardId = {boardId} and TaskId = {taskId}";

            return executer.ExecuteWrite(command);
        }
        public bool ChangeAssignee(string email, int boardId, int taskId)
        {
            string command = "UPDATE Tasks" +
                            $"SET Assignee = '{email}'" +
                            $"WHERE BoardId = {boardId} and TaskId = {taskId}";

            return executer.ExecuteWrite(command);
        }
        public bool ChangeDueDate(DateTime dueDate, int boardId, int taskId)
        {
            string command = "UPDATE Tasks" +
                            $"SET DueDate = '{dueDate.Year}/{dueDate.Month}/{dueDate.Day}'" +
                            $"WHERE BoardId = {boardId} and TaskId = {taskId}";

            return executer.ExecuteWrite(command);
        }
    }
}
