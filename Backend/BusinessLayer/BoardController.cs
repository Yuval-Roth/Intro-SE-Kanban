using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class BoardController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Backend\\BusinessLayer\\BoardController.cs");
        UserData userData;
        public BoardController(UserData userData)
        {
            this.userData = userData;
        }
        public void AddBoard(string email, string name)
        {
            log.Debug("AddBoard() for: " + email + "Board's name" + name);
            if (email == null)
            {
                log.Error("AddBoard() failed: '" + email + "' is null");
                throw new ArgumentNullException("Email is null");
            }
            if (name == null)
            {
                log.Error("AddBoard() failed: '" + name + "' is null");
                throw new ArgumentNullException("name is null");
            }
            try
            {
                userData.AddBoard(email, name);
                log.Debug("AddBoard() success");
            }
            catch (NoSuchElementException)
            {
                log.Error("AddBoard() failed: '" + email + "' doesn't exist");
                throw new NoSuchElementException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
            catch (ArgumentException)
            {
                log.Error("AddBoard() failed: board '" + name + "' already exists for " + email);
                throw new ArgumentException("A board titled " +
                        name + " already exists for the user with the email " + email);
            }
        }
        public void RemoveBoard(string email, string name)
        {
            log.Debug("RemoveBoard() for: " + email + "Board's name" + name);
            if (email == null)
            {
                log.Error("RemoveBoard() failed: '" + email + "' is null");
                throw new ArgumentNullException("Email is null");
            }
            if (name == null)
            {
                log.Error("RemoveBoard() failed: '" + name + "' is null");
                throw new ArgumentNullException("name is null");
            }
            try
            {
                userData.RemoveBoard(email, name);
                log.Debug("RemoveBoard() success");
            }
            catch (NoSuchElementException)
            {
                log.Error("RemoveBoard() failed: '" + email + "' doesn't exist");
                throw new NoSuchElementException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
            catch (ArgumentException)
            {
                log.Error("RemoveBoard() failed: board '" + name + "' doesn't exist for " + email);
                throw new ArgumentException("A board titled '" +
                                name + "' doesn't exists for the user with the email " + email);
            }
        }
        public LinkedList<Task> GetAllTasksByState(User user, Enum state) { return null; }
        public LinkedList<Board> GetBoards (User user) { return null; }
        public Board SearchBoard(string email, string name) {
            log.Debug("SearchBoard() for: " + email + "Board's name" + name);
            if (email == null)
            {
                log.Error("SearchBoard() failed: '" + email + "' is null");
                throw new ArgumentNullException("Email is null");
            }
            if (name == null)
            {
                log.Error("SearchBoard() failed: '" + name + "' is null");
                throw new ArgumentNullException("name is null");
            }
            try
            {
                LinkedList<Board> boardList = userData.GetBoards(email);
                foreach (Board board in boardList)
                {
                    if (board.Title == name)
                    {
                        log.Debug("SearchBoard() success");
                        return board;
                    }
                }
                log.Error("SearchBoard() failed: '" + name + "' doesn't exist");
                throw new NoSuchElementException("A board titled '" +
                                name + "' doesn't exists for the user with the email " + email);
            }
            catch (NoSuchElementException)
            {
                log.Error("SearchBoard() failed: '" + email + "' doesn't exist");
                throw new NoSuchElementException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
        }

    }
}
