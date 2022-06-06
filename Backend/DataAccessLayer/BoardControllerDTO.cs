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
            throw new NotImplementedException("No implement yet");
        }
        public bool JoinBoard(string email, int id)
        {
            throw new NotImplementedException("No implement yet");
        }
        public bool LeaveBoard(string email, int id)
        {
            throw new NotImplementedException("No implement yet");
        }
        public bool ChangeOwner(string email, int id)
        {
            throw new NotImplementedException("No implement yet");
        }
        public bool LimitColumn(int id, BusinessLayer.TaskStates state, int limit)
        {
            executer.Execute("UPDATE Boards" +
            $"SET InprogressLimit = {limit}" +
            $"WHERE BoardId = {id}");
            throw new NotImplementedException("No implement yet");
        }

    }
}
