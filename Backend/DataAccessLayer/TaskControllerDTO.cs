using System;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class TaskControllerDTO
    {
        private SQLExecuter executer;

        public TaskControllerDTO(SQLExecuter executer)
        {
            this.executer = executer;
        }

        public bool AddTask(int boardId, int taskId, string title, string assignee, string description, DateTime CreationTime, DateTime duedate, BoardColumnNames state)
        {
            string command = "INSERT INTO Tasks(BoardId, TaskId, TaskTitle, Assignee, Description, CreationTime, DueDate, State) "+
                             $"VALUES({boardId},{taskId},'{title}','{assignee}','{description}','{CreationTime}'," +
                             $"'{duedate}',{(int)state})";

            return executer.ExecuteWrite(command);
        }
        public bool RemoveTask(int boardId, int TaskId)
        {
            return executer.ExecuteWrite("DELETE FROM Tasks " +
                                        $"WHERE BoardId = {boardId} and TaskId = {TaskId}");
        }
        public bool ChangeTaskState(int boardId, int taskId, BoardColumnNames state)
        {
            string command = "UPDATE Tasks " +
                            $"SET State = {(int)state} " +
                            $"WHERE BoardId = {boardId} and TaskId = {taskId}";

            return executer.ExecuteWrite(command);
        }
        public bool ChangeTitle(string title, int boardId, int taskId)
        {
            string command = "UPDATE Tasks " +
                            $"SET TaskTitle = '{title}' " +
                            $"WHERE BoardId = {boardId} and TaskId = {taskId}";

            return executer.ExecuteWrite(command);
        }
        public bool ChangeDescription(string description, int boardId, int taskId)
        {
            string command = "UPDATE Tasks " +
                            $"SET Description = '{description}' " +
                            $"WHERE BoardId = {boardId} and TaskId = {taskId}";

            return executer.ExecuteWrite(command);
        }
        public bool ChangeAssignee(string email, int boardId, int taskId)
        {
            string command = "UPDATE Tasks " +
                            $"SET Assignee = '{email}' " +
                            $"WHERE BoardId = {boardId} and TaskId = {taskId}";

            return executer.ExecuteWrite(command);
        }
        public bool ChangeDueDate(DateTime dueDate, int boardId, int taskId)
        {
            string command = "UPDATE Tasks " +
                            $"SET DueDate = '{dueDate}' " +
                            $"WHERE BoardId = {boardId} and TaskId = {taskId}";

            return executer.ExecuteWrite(command);
        }
    }
}
