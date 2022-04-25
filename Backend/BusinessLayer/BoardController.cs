using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class BoardController
    {
      
        public UserData Boards  { get; set; }
        public void CreateBoard(User user, string title) { }
        public void DeleteBoard(User user, string title) { }
        public LinkedList<Task> GetAllTasksByState(User user, Enum state) { return null; }
        public LinkedList<Board> GetBoards (User user) { return null; }
        public Board SearchBoard(User user, string title) { return null; }

        public BoardController(UserData userData) {
            Boards = new UserData();
            userData = new();
        }

    }
}
