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
                $"VALUES({board.Id}, {board.Title}, {board.Owner}, {board.BackLogLimit}, {board.InProgressLimit}, {board.DoneLimit})");
        }
        public bool RemoveBoard(int id)
        {
            return executer.Execute($"DELETE FROM Boards WHERE Boards.BoardId={id} DELETE FROM UserJoinedBoards WHERE UserJoinedBoards.BoardId={id}");
        }
        public bool JoinBoard(string email, int id)
        {
            return executer.Execute("INSERT into UserJoinedBoards (BoardId, Email)" +
                $"VALUES({id}, {email})");
        }
        public bool LeaveBoard(string email, int id)
        {
            throw new NotImplementedException("No implement yet");
        }
        public bool ChangeOwner(string email, int id)
        {
            throw new NotImplementedException("No implement yet");
        }
        public bool AddTask(int id, TaskDTO task)
        {
            throw new NotImplementedException("No implement yet");
        }
        public bool RemoveTask(int BoardId, int TaskId)
        {
            throw new NotImplementedException("No implement yet");
        }
        public bool LimitColumn(int Id, BusinessLayer.TaskStates state, int limit)
        {
            throw new NotImplementedException("No implement yet");
        }

    }
}
