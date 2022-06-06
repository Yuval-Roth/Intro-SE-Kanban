using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class BoardControllerDTO
    {
        private SQLExecuter executer;

        public bool AddBoard(BoardDTO board)
        {
            return executer.Execute ("INSERT into Boards (BoardId, BoardTitle, Owner, BacklogLimit, InprogressLimit, DoneLimit) " +
                $"VALUES({board.Id},'{board.Title}','{board.Owner}',{board.BackLogLimit},{board.InProgressLimit},{board.DoneLimit})");
        }
        public bool RemoveBoard(int id)
        {
            return executer.Execute($"DELETE FROM Boards WHERE Boards.BoardId={id} DELETE FROM UserJoinedBoards WHERE UserJoinedBoards.BoardId={id}");
        }
        public bool JoinBoard(string email, int id)
        {
            return executer.Execute("INSERT into UserJoinedBoards (BoardId, Email)" +
                $"VALUES({id},'{email}')");
        }
        public bool LeaveBoard(string email, int id)
        {
            return executer.Execute("DELETE FROM UserJoinedBoards" +
                $"WHERE BoardId= '{id}' and Email= '{email}'");
        }
        public bool ChangeOwner(string email, int id)
        {
            return executer.Execute("UPDATE Boards"+
            $"SET Owner = '{email}'"+
            $"WHERE TaskId = {id}");
        }
        public bool AddTask(int id, TaskDTO task)
        {
            throw new NotImplementedException("No implement yet");
        }
        public bool RemoveTask(int BoardId, int TaskId)
        {
            return executer.Execute("DELETE FROM Tasks" +
            $"WHERE BoardId = {BoardId} and TaskId = {TaskId}");
        }
        public bool LimitColumn(int id, BusinessLayer.TaskStates state, int limit)
        {
            return executer.Execute("UPDATE Boards" +
            $"SET InprogressLimit = {limit}" +
            $"WHERE BoardId = {id}");
        }

    }
}
