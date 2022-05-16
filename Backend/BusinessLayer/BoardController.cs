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
            if (!userData.ContainsUser(email))
            {
                log.Error("AddBoard() failed: '" + email + "' doesn't exist");
                throw new NoSuchElementException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
            if (!userData.UserLoggedInStatus(email))
            {
                log.Error("AddBoard() failed: '" + email + "' doesn't login");
                throw new NoSuchElementException("A user with the email '" +
                    email + "' doesn't login to the system");
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
            if (!userData.ContainsUser(email))
            {
                log.Error("RemoveBoard() failed: '" + email + "' doesn't exist");
                throw new NoSuchElementException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
            if (!userData.UserLoggedInStatus(email))
            {
                log.Error("RemoveBoard() failed: '" + email + "' doesn't login");
                throw new NoSuchElementException("A user with the email '" +
                    email + "' doesn't login to the system");
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
        public LinkedList<Task> GetAllTasksByState(string email, int columnOrdinal)
            {
            log.Debug("GetAllTasksByState() for: " + "Board's name" + columnOrdinal);
            if (!userData.ContainsUser(email))
            {
                log.Error("GetAllTasksByState() failed: '" + email + "' doesn't exist");
                throw new NoSuchElementException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
            if (!userData.UserLoggedInStatus(email))
            {
                log.Error("GetAllTasksByState() failed: '" + email + "' doesn't login");
                throw new NoSuchElementException("A user with the email '" +
                    email + "' doesn't login to the system");
            }
            if (columnOrdinal < 0 || columnOrdinal > 2)
            {
                log.Error("GetAllTasksByState() failed: '" + columnOrdinal + "' doesn't exist");
                throw new NoSuchElementException("A column '" +
                    columnOrdinal + "' doesn't exist in the Board");
            }
            
                LinkedList<Task> tasks = new LinkedList<Task>();
                LinkedList<Board> boards = GetBoards(email);
                foreach (Board board in boards)
                {
                    foreach (Task task in board.GetColumn(columnOrdinal))
                    {
                        tasks.AddLast(task);
                    }
                }
            log.Debug("GetAllTasksByState() success");
            return tasks;
        }
        public LinkedList<Board> GetBoards (string email) {
            log.Debug("GetBoards() for: " + email);
            if (!userData.ContainsUser(email))
            {
                log.Error("GetBoards() failed: '" + email + "' doesn't exist");
                throw new NoSuchElementException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
            if (!userData.UserLoggedInStatus(email))
            {
                log.Error("GetBoards() failed: '" + email + "' doesn't login");
                throw new NoSuchElementException("A user with the email '" +
                    email + "' doesn't login to the system");
            }
            try
            {
                LinkedList<Board> output = userData.GetBoards(email);
                log.Debug("GetBoards() success");
                return output;
            }
            catch (NoSuchElementException)
            {
                log.Error("GetBoards() failed: '" + email + "' doesn't exist");
                throw new NoSuchElementException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
        }
        public Board SearchBoard(string email, string name) {
            log.Debug("SearchBoard() for: " + email + "Board's name" + name);
            if (!userData.ContainsUser(email))
            {
                log.Error("SearchBoard() failed: '" + email + "' doesn't exist");
                throw new NoSuchElementException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
            if (!userData.UserLoggedInStatus(email))
            {
                log.Error("SearchBoard() failed: '" + email + "' doesn't login");
                throw new NoSuchElementException("A user with the email '" +
                    email + "' doesn't login to the system");
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
