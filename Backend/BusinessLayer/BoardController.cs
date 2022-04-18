using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    internal class BoardController
    {
        public BoardTree<Board> Boards  { get; set; }
        public void createBoard(User user, string title) { }
        public void deleteBoard(User user, string title) { }
        public LinkedList<Task> getAllTasksByState(User user, Enum state) { return null; }
        public LinkedList<Board> getBoards (User user) { return null; }
        public Board searchBoard(User user, string title) { return null; }

    }
}
