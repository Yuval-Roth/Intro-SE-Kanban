using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{

    /// <summary>
    ///This class controls the actions users' boards.<br/>
    ///<br/>
    ///<code>Supported operations:</code>
    ///<br/>
    /// <list type="bullet">AddBoard()</list>
    /// <list type="bullet">RemoveBoard()</list>
    /// <list type="bullet">GetAllTasksByState()</list>
    /// <list type="bullet">GetBoards()</list>
    /// <list type="bullet">SearchBoard()</list>
    /// <br/><br/>
    /// ===================
    /// <br/>
    /// <c>Ⓒ Kfir Nissim</c>
    /// <br/>
    /// ===================
    /// </summary>

    public class BoardController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Backend\\BusinessLayer\\BoardController.cs");
        UserData userData;

        /// <summary>
        /// Creates an empty <c>BinaryTree</c> userList <br/>
        /// Creates an empty <c>LinkList</c> Boards
        /// </summary>
        public BoardController(UserData userData)
        {
            this.userData = userData;
        }

        /// <summary>
        /// Add new <c>Board</c> to <c>UserData</c> userData <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if the user isn't exists or isn't login or Board already exist
        /// </summary>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException"></exception>
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


        /// <summary>
        /// Remove <c>Board</c> from <c>UserData</c> userData <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if the user isn't exists or isn't login or Board isn't exist
        /// </summary>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Returns <c>tasks' list</c> from <c>UserData</c> userData <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if the user isn't exists or isn't login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="columnOrdinal"></param>
        /// <returns>A list of tasks by specific state, unless an error occurs</returns>
        /// <exception cref="ArgumentException"></exception>
        public LinkedList<Task> GetAllTasksByState(string email, int columnOrdinal)
            {
            log.Debug("GetAllTasksByState() for: " + "Board's name" + (TaskStates)columnOrdinal);
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
            if (columnOrdinal < (int)TaskStates.backlog || columnOrdinal > (int)TaskStates.done)
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


        /// <summary>
        /// Returns <c>boards' list</c> from <c>UserData</c> userData <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if the user isn't exists or isn't login
        /// </summary>
        /// <param name="email"></param>
        /// <returns>A list of Boards, unless an error occurs</returns>
        /// <exception cref="ArgumentException"></exception>
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


        /// <summary>
        /// Returns <c>board</c> from <c>UserData</c> userData <br/> <br/>
        /// <b>Throws</b> <c>Exception</c> if the user isn't exists or isn't login or board isn't exist
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Board, unless an error occurs</returns>
        /// <exception cref="ArgumentException"></exception>
        public Board SearchBoard(string email, string name) {
            log.Debug("SearchBoard() for: " + email + " Board's name " + name);
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

    }
}
