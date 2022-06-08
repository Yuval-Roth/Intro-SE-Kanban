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
        BoardDataOperations boardData;
        /// <summary>
        /// Initialize a new BoardController <br/><br/>
        /// </summary>
        /// <param name="userData"></param>
        public BoardController(BoardDataOperations boardData)
        {
            this.boardData = boardData;
        }

        /// <summary>
        /// Add new <c>Board</c> to <c>UserData</c> userData <br/> <br/>
        /// <b>Throws</b> <c>ArgumentException</c> if a<c> Board</c> with that title already exists<br/>
        /// for the <c>User</c><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if the user doesn't exist<br/>
        /// <b>Throws</b> <c>AccessViolationException</c> if the user isn't logged in<br/>
        /// in the system
        /// </summary>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NoSuchElementException"></exception>
        /// <exception cref="AccessViolationException"></exception>
        public void AddBoard(string email, string name)
        {

            log.Debug("AddBoard() for: " + email + "Board's name" + name);
            ValidateUser(email);
            if (name.Length == 0)
            {
                log.Error("AddBoard() failed: board name is empty");
                throw new ArgumentException("board name is empty");
            }

            try
            {
                boardData.AddNewBoard(email, name);
                log.Debug("AddBoard() success");
            }
            catch (ElementAlreadyExistsException)
            {
                log.Error("AddBoard() failed: board '" + name + "' already exists for " + email);
                throw;
            }
            catch (DataMisalignedException)
            {
                log.Fatal("AddBoard() failed: BoardIDCounter is out of sync");
                throw;
            }
            catch (UserDoesNotExistException e)
            {
                log.Error("AddNewBoard() failed: " + e.Message);
            }
        }


        /// <summary>
        /// Remove <c>Board</c> from <c>UserData</c> userData <br/> <br/>
        /// <b>Throws</b> <c>ArgumentException</c> if a <c>Board</c> with that title <br/>
        /// doesn't exist for the user<br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if the user doesn't exist<br/>
        /// <b>Throws</b> <c>AccessViolationException</c> if the user isn't logged in<br/>
        /// in the system
        /// </summary>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NoSuchElementException"></exception>
        /// <exception cref="AccessViolationException"></exception>
        public void RemoveBoard(string email, string name)
        {

            log.Debug("RemoveBoard() for: " + email + "Board's name" + name);
            ValidateUser(email);

            try
            {
                boardData.NukeBoard(email, name);
                log.Debug("RemoveBoard() success");
            }
            catch (NoSuchElementException)
            {
                log.Error("RemoveBoard() failed: '" + email + "' doesn't exist");
                throw;
            }
            catch (OperationCanceledException)
            {
                log.Error("RemoveBoard() failed: board '" + name + "' doesn't exist for " + email);
                throw;
            }
        }

        /// <summary>
        /// Returns <c>tasks' list</c> from <c>UserData</c> userData <br/> <br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if the user doesn't exist<br/>
        /// <b>Throws</b> <c>AccessViolationException</c> if the user isn't logged in<br/>
        /// <b>Throws</b> <c>IndexOutOfRangeException</c> if the column is not a valid column number
        /// </summary>
        /// <param name="email"></param>
        /// <param name="columnOrdinal"></param>
        /// <returns>A list of tasks by specific state, unless an error occurs</returns>
        /// <exception cref="NoSuchElementException"></exception>
        /// <exception cref="AccessViolationException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public LinkedList<Task> GetAllTasksByState(string email, int columnOrdinal)
            {
            log.Debug("GetAllTasksByState() for: " + "Board's name" + columnOrdinal);
            ValidateUser(email);
            ValidateColumnOrdinal(columnOrdinal);
            
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
        /// <b>Throws</b> <c>NoSuchElementException</c> if the user doesn't exist<br/>
        /// <b>Throws</b> <c>AccessViolationException</c> if the user isn't logged in
        /// </summary>
        /// <param name="email"></param>
        /// <returns>A list of Boards, unless an error occurs</returns>
        /// <exception cref="NoSuchElementException"></exception>
        /// <exception cref="AccessViolationException"></exception>
        public LinkedList<Board> GetBoards (string email) {

            log.Debug("GetBoards() for: " + email);
            ValidateUser(email);

            try
            {
                LinkedList<Board> output = boardData.GetBoardsDataUnit(email).MyBoards;
                log.Debug("GetBoards() success");
                return output;
                //return null;
            }
            catch (NoSuchElementException)
            {
                log.Error("GetBoards() failed: '" + email + "' doesn't exist");
                throw;
            }
        }


        /// <summary>
        /// Returns <c>board</c> from <c>UserData</c> userData <br/> <br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if the user or the board doesn't exist<br/>
        /// <b>Throws</b> <c>AccessViolationException</c> if the user isn't logged in
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Board, unless an error occurs</returns>
        /// <exception cref="NoSuchElementException"></exception>
        public Board SearchBoard(string email, string name)
        {
            log.Debug("SearchBoard() for: " + email + " Board's name " + name);
            ValidateUser(email);

            LinkedList<Board> boardList = boardData.GetBoardsDataUnit(email).MyBoards;
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

        /// <summary>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if the user doesn't exist<br/>
        /// <b>Throws</b> <c>AccessViolationException</c> if the user isn't logged in
        /// </summary>
        /// <param name="email"></param>
        /// <exception cref="UserDoesNotExistException"></exception>
        /// <exception cref="AccessViolationException"></exception>
        private void ValidateUser(string email)
        {
            if (!boardData.UserExists(email))
            {
                log.Error("ValidateUser() failed: a user with the email '" +
                    email + "' doesn't exist in the system");
                throw new UserDoesNotExistException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
            if (!boardData.UserLoggedInStatus(email))
            {
                log.Error("ValidateUser() failed: user '" + email + "' isn't logged in");
                throw new AccessViolationException("user '" + email + "' isn't logged in");
            }
        }

        public void ChangeOwner(string currentOwnerEmail, string newOwnerEmail, string boardName)
        {
            log.Debug("ChangeOwner() for board: " + boardName + "from: " + currentOwnerEmail + "to: " + newOwnerEmail);
            if (!this.joined.Contains(newOwnerEmail))
            {
                log.Error("ChangeOwner() failed: '" + newOwnerEmail + "' isn't joined to the board");
                throw new ArgumentException("the user " + newOwnerEmail + " isn't joined to the board");
            }
            this.owner = newOwnerEmail;
            this.joined.AddLast(currentOwnerEmail);
            this.joined.Remove(newOwnerEmail);
        }

        /// <summary>
        /// <b>Throws</b> <c>IndexOutOfRangeException</c> if the column is not a valid column number
        /// </summary>
        /// <param name="columnOrdinal"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        private void ValidateColumnOrdinal(int columnOrdinal)
        {
            if (columnOrdinal < (int)TaskStates.backlog | columnOrdinal > (int)TaskStates.done)
            {
                log.Error("ValidateColumnOrdinal() failed: '" + columnOrdinal + "' is not a valid column number");
                throw new IndexOutOfRangeException("The column '" + columnOrdinal + "' is not a valid column number");
            }
        }

    }
}
