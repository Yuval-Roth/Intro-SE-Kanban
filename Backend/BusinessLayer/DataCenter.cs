using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{

    //===========================================================================
    //                                DataCenter
    //===========================================================================


    /// <summary>
    /// The class manages a data structure of of <c>User</c>s and <c>Board</c>s. <br/>
    /// <br/>
    /// <code>Supported operations:</code>
    /// <list type="bullet">
    /// <item>SearchUser()</item>
    /// <item>AddUser()</item>
    /// <item>RemoveUser()</item>
    /// <item>ContainsUser()</item>
    /// <item>UserLoggedInStatus()</item>
    /// <item>SetLoggedIn()</item>
    /// <item>SetLoggedOut()</item>
    /// <item>GetAllBoards()</item>
    /// <item>AddBoard()</item>
    /// <item>RemoveBoard()</item>
    /// </list>
    /// <br/><br/>
    /// ===================
    /// <br/>
    /// <c>Ⓒ Yuval Roth</c>
    /// <br/>
    /// ===================
    /// </summary>
    public class DataCenter
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Backend\\BusinessLayer\\DataCenter.cs");

        private struct DataUnit
        {
            public User User { get; init; }
            public LinkedList<Board> MyBoards { get; init; }
            public LinkedList<Board> JoinedBoards { get; init; }
        }
        public struct BoardsDataUnit
        {
            public LinkedList<Board> MyBoards { get; init; }
            public LinkedList<Board> JoinedBoards { get; init; }
        }
        private readonly AVLTree<string, DataUnit> UsersAndBoardPointers;
        private readonly AVLTree<int, Board> Boards;
        private readonly HashSet<string> loggedIn;
        private int nextBoardID;

        public DataCenter()
        {
            UsersAndBoardPointers = new();
            Boards = new();
            loggedIn = new();
        }

        /// <summary>
        /// Auto incrementing counter for boards ID.<br/>
        /// Everytime this method is called, the counter in incremented.
        /// </summary>
        private int GetNextBoardID => nextBoardID++;

        /// <summary>
        /// Searches for a user with the specified email<br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if the user doesn't exist
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User</returns>
        /// <exception cref="UserDoesNotExistException"></exception>
        public User SearchUser(string email)
        {
            try
            {
                log.Debug("SearchUser() for: " + email);
                User output = UsersAndBoardPointers.GetData(email).User;
                log.Debug("SearchUser() success");
                return output;
            }
            catch (KeyNotFoundException)
            {
                log.Error("SearchUser() failed: '" + email + "' doesn't exist in the system");
                throw new UserDoesNotExistException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
        }
        /// <summary>
        /// Adds a user to the system
        /// <br/><br/>
        /// <b>Throws</b> <c>ElementAlreadyExists</c> if a user with this email<br/>
        /// already exists in the system
        /// </summary>
        /// <param name="email"></param>
        /// <exception cref="ElementAlreadyExistsException"></exception>
        /// <returns>The added <c>User</c></returns>
        public User AddUser(string email, string password)
        {
            try
            {
                log.Debug("AddUser() for: " + email);
                DataUnit data = UsersAndBoardPointers.Add(email, new DataUnit()
                {
                    User = new User(email, password),
                    MyBoards = new LinkedList<Board>(),
                    JoinedBoards = new LinkedList<Board>()
                });
                log.Debug("AddUser() success");
                return data.User;
            }
            catch (DuplicateKeysNotSupported)
            {
                log.Error("AddUser() failed: '" + email + "' already exists");
                throw new ElementAlreadyExistsException("A user with the email '" +
                    email + "' already exists in the system");
            }
        }

        /// <summary>
        /// Removes the user with the specified email from the system
        /// <br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if the user doesn't exist in the system
        /// </summary>
        /// <param name="email"></param>
        /// <exception cref="UserDoesNotExistException"></exception>
        public void RemoveUser(string email)
        {
            try
            {
                log.Debug("RemoveUser() for: " + email);
                UsersAndBoardPointers.Remove(email);
                /*
                    TO DO:
                    Take care of boards of deleted users
                 */
                log.Debug("RemoveUser() success");
            }
            catch (KeyNotFoundException)
            {
                log.Error("RemoveUser() failed: '" + email + "' doesn't exist");
                throw new UserDoesNotExistException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
        }

        /// <summary>
        /// Gets the user's logged in status
        /// </summary>
        /// <returns><c>true</c> if the user is logged in, <c>false</c>  otherwise</returns>
        /// <param name="email"></param>
        public bool UserLoggedInStatus(string email)
        {
            log.Debug("UserLoggedInStatus() for: " + email);
            return loggedIn.Contains(email);
        }

        /// <summary>
        /// Sets a user's logged in status to true
        /// <br/><br/>
        /// <b>Throws</b> <c>ArgumentException</c> if the user's logged in status is already true
        /// </summary>
        /// <param name="email"></param>
        /// <exception cref="ArgumentException"></exception>
        public void SetLoggedIn(string email)
        {
            if (UserLoggedInStatus(email) == false)
            {
                log.Info(email + " is now logged in");
                loggedIn.Add(email);
            }
            else
            {
                log.Error("SetLoggedIn() failed: '" + email + "' is already logged in");
                throw new ArgumentException("The user with the email '" + email + "' is already logged in");
            }
        }

        /// <summary>
        /// Sets a user's logged in status to false
        /// <br/><br/>
        /// <b>Throws</b> <c>ArgumentException</c> if the user's logged in status is already false
        /// </summary>
        /// <param name="email"></param>
        /// <exception cref="ArgumentException"></exception>
        public void SetLoggedOut(string email)
        {
            if (UserLoggedInStatus(email) == true)
            {
                log.Info(email + " is now logged out");
                loggedIn.Remove(email);
            }
            else
            {
                log.Error("SetLoggedOut() failed: '" + email + "' is not logged in");
                throw new ArgumentException("The user with the email '" + email + "' is not logged in");
            }
        }

        public bool ContainsUser(string email)
        {
            log.Debug("ContainsUser() for: " + email);
            return UsersAndBoardPointers.Contains(email);
        }

        /// <summary>
        /// Gets all the <c>User</c>'s boards data
        /// <br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if the <c>User</c> does not exist<br/>
        /// in the system
        /// </summary>
        /// <returns>UserData.BoardsDataUnit</returns>
        /// <exception cref="UserDoesNotExistException"></exception>
        public BoardsDataUnit GetBoardsData(string email)
        {
            try
            {
                log.Debug("GetBoardsData() for: " + email);
                DataUnit data = UsersAndBoardPointers.GetData(email);
                log.Debug("GetBoardsData() success");
                return new BoardsDataUnit()
                {
                    MyBoards = data.MyBoards,
                    JoinedBoards = data.JoinedBoards
                };
            }
            catch (KeyNotFoundException)
            {
                log.Error("AddBoard() failed: '" + email + "' doesn't exist");
                throw new UserDoesNotExistException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
        }

        /// <summary>
        /// Gets all the <c>User</c>'s <c>Board</c>s
        /// <br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if the <c>User</c> does not exist<br/>
        /// in the system
        /// </summary>
        /// <returns>LinkedList&lt;Board&gt;</returns>
        /// <exception cref="UserDoesNotExistException"></exception>
        public LinkedList<Board> GetBoards(string email)
        {
            try
            {
                log.Debug("GetBoards() for: " + email);
                LinkedList<Board> output = UsersAndBoardPointers.GetData(email).MyBoards;
                log.Debug("GetBoards() success");
                return output;
            }
            catch (KeyNotFoundException)
            {
                log.Error("GetBoards() failed: '" + email + "' doesn't exist");
                throw new UserDoesNotExistException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
        }


        /// <summary>
        /// Joins a user to an existing board.<br/><br/>
        /// <b>Throws</b> <c>ElementAlreadyExistsException</c> if the user is already joined on the board<br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if the user doesn't exist in the system<br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if a board with that id doesn't exist<br/>
        /// </summary>
        /// <param name="email"></param>
        /// <param name="id"></param>
        /// <exception cref="ElementAlreadyExistsException"></exception>
        /// <exception cref="UserDoesNotExistException"></exception>
        /// <exception cref="NoSuchElementException"></exception>
        public void JoinExistingBoard(string email, int id)
        {
            try
            {
                log.Debug("JoinExistingBoard() for: " + email + ", " + id);

                LinkedList<Board> joinedBoardList = UsersAndBoardPointers.GetData(email).JoinedBoards;
                Board boardToJoin = Boards.GetData(id);

                // Check if the user is joined on the board already
                foreach (Board board in joinedBoardList)
                {
                    if (board.Id == id)
                    {
                        log.Error("JoinExistingBoard() failed: " + email + " is already joined on board nubmer " + id);
                        throw new ElementAlreadyExistsException(email + " is already joined on board nubmer " + id);
                    }
                }
                joinedBoardList.AddLast(boardToJoin);
                log.Debug("JoinExistingBoard() success");
            }
            catch (KeyNotFoundException)
            {
                if (UsersAndBoardPointers.Contains(email) == false)
                {
                    log.Error("JoinExistingBoard() failed: '" + email + "' doesn't exist");
                    throw new UserDoesNotExistException("A user with the email '" +
                        email + "' doesn't exist in the system");
                }
                if (Boards.Contains(id) == false)
                {
                    log.Error("JoinExistingBoard() failed: board number " + id + "doesn't exist");
                    throw new NoSuchElementException("Board number " + id + "doesn't exist");
                }
            }
            
        }

        /// <summary>
        /// Adds a <c>Board</c> to the <c>User</c>.
        ///<br/><br/>
        /// <b>Throws</b> <c>ElementAlreadyExistsException</c> if a <c>Board</c> with that title already exists <br/>
        /// for the <c>User</c><br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if the <c>User</c> doesn't exist <br/>
        /// in the system
        /// </summary>
        /// <returns>The <c>Board</c> that was added</returns>
        /// <exception cref="ElementAlreadyExistsException"></exception>
        /// <exception cref="UserDoesNotExistException"></exception>
        public Board AddNewBoard(string email, string title)
        {
            try
            {
                log.Debug("AddBoard() for: " + email + ", " + title);

                // Fetch the user's boards
                LinkedList<Board> boardList = UsersAndBoardPointers.GetData(email).MyBoards;

                // Check if there's a board with that title already
                foreach (Board board in boardList)
                {
                    if (board.Title == title)
                    {
                        log.Error("AddBoard() failed: board '" + title + "' already exists for " + email);
                        throw new ElementAlreadyExistsException("A board titled " +
                                title + " already exists for the user with the email " + email);
                    }
                }

                // Add a new board and return it
                Board newBoard = new(title, GetNextBoardID);
                Boards.Add(newBoard.Id, newBoard);
                boardList.AddLast(newBoard);
                log.Debug("AddBoard() success");
                return newBoard;
            }
            catch (DuplicateKeysNotSupported)
            {
                log.Fatal("BoardIDCounter is out of sync");
                throw new DataMisalignedException("BoardIDCounter is out of sync");
            }
            catch (KeyNotFoundException)
            {
                log.Error("AddBoard() failed: '" + email + "' doesn't exist");
                throw new UserDoesNotExistException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
        }

        /// <summary>
        /// Removes a <c>User</c>'s <c>Board</c>
        /// <br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if a <c>Board</c> with that title <br/>
        /// doesn't exist for the user<br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if the <c>User</c> doesn't exist <br/>
        /// in the system
        /// </summary>
        /// <exception cref="NoSuchElementException"></exception>
        /// <exception cref="UserDoesNotExistException"></exception>
        public void RemoveBoard(string email, string title)
        {
            /*
            TO DO:                
            update to current requirements:

            1) add deletion by id number
            2) remove pointers from everywhere after deletion
                
             */

            try
            {
                log.Debug("RemoveBoard() for: " + email + ", " + title);
                bool found = false;

                // Fetch the user's boards
                LinkedList<Board> boardList = UsersAndBoardPointers.GetData(email).MyBoards;

                // Search for the specific board
                foreach (Board board in boardList)
                {
                    if (board.Title == title)
                    {
                        boardList.Remove(board);
                        found = true;
                        log.Debug("RemoveBoard() success");
                        break;
                    }
                }

                // didn't find a board by that name
                if (!found)
                {
                    log.Error("RemoveBoard() failed: board '" + title + "' doesn't exist for " + email);
                    throw new NoSuchElementException("A board titled '" +
                                    title + "' doesn't exists for the user with the email " + email);
                }
            }
            catch (KeyNotFoundException)
            {
                log.Error("AddBoard() failed: '" + email + "' doesn't exist");
                throw new UserDoesNotExistException("A user with the email '" +
                    email + "' doesn't exist in the system");

            }
        }
    }
}