using System;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class TaskControllerDTO
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Backend\\DataAccessLayer\\TaskControllerDTO.cs");

        private SQLExecuter executer;

        public TaskControllerDTO(SQLExecuter executer)
        {
            this.executer = executer;
        }

        public bool AddTask(int boardId, int taskId, string title, string assignee, string description, DateTime CreationTime, DateTime duedate, BoardColumnNames state)
        {
            log.Debug($"AddTask() for: {boardId}, {taskId}, {title}, {assignee}, {description}, {CreationTime}, {duedate}, {state}");
            string command = "INSERT INTO Tasks(BoardId, TaskId, TaskTitle, Assignee, Description, CreationTime, DueDate, State) "+
                             $"VALUES({boardId},{taskId},'{title}','{assignee}','{description}','{CreationTime}'," +
                             $"'{duedate}',{(int)state})";

            return executer.ExecuteWrite(command);
        }
        public bool RemoveTask(int boardId, int TaskId)
        {
            log.Debug($"RemoveTask() for: {boardId}, {TaskId}");
            return executer.ExecuteWrite("DELETE FROM Tasks " +
                                        $"WHERE BoardId = {boardId} and TaskId = {TaskId}");
        }
        public bool ChangeTaskState(int boardId, int taskId, BoardColumnNames state)
        {
            log.Debug($"ChangeTaskState() for: {boardId}, {taskId}, {state}");
            string command = "UPDATE Tasks " +
                            $"SET State = {(int)state} " +
                            $"WHERE BoardId = {boardId} and TaskId = {taskId}";

            return executer.ExecuteWrite(command);
        }
        public bool ChangeTitle(string title, int boardId, int taskId)
        {
            log.Debug($"ChangeTitle() for: {title}, {boardId}, {taskId}");
            string command = "UPDATE Tasks " +
                            $"SET TaskTitle = '{title}' " +
                            $"WHERE BoardId = {boardId} and TaskId = {taskId}";

            return executer.ExecuteWrite(command);
        }
        public bool ChangeDescription(string description, int boardId, int taskId)
        {
            log.Debug($"ChangeDescription() for: {description}, {boardId}, {taskId}");
            string command = "UPDATE Tasks " +
                            $"SET Description = '{description}' " +
                            $"WHERE BoardId = {boardId} and TaskId = {taskId}";

            return executer.ExecuteWrite(command);
        }
        public bool ChangeAssignee(string email, int boardId, int taskId)
        {
            log.Debug($"ChangeAssignee() for: {email}, {boardId}, {taskId}");
            string command = "UPDATE Tasks " +
                            $"SET Assignee = '{email}' " +
                            $"WHERE BoardId = {boardId} and TaskId = {taskId}";

            return executer.ExecuteWrite(command);
        }
        public bool ChangeDueDate(DateTime dueDate, int boardId, int taskId)
        {
            log.Debug($"ChangeDueDate() for: {dueDate}, {boardId}, {taskId}");
            string command = "UPDATE Tasks " +
                            $"SET DueDate = '{dueDate}' " +
                            $"WHERE BoardId = {boardId} and TaskId = {taskId}";

            return executer.ExecuteWrite(command);
        }
    }
}
