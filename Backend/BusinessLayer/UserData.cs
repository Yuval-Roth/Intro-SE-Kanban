using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{

    //===========================================================================
    //                                UserData
    //===========================================================================


    /// <summary>
    /// The class manages a data structure of of <c>User</c>s and their <c>Board</c>s. <br/>
    /// every unique <c>User</c> has his own set of <c>Board</c>s.
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
    public class UserData
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Backend\\BusinessLayer\\UserData.cs");

        private class DataUnit
        {
            public User User { get; set; }
            public LinkedList<Board> Boards { get; set; }
        }
        private AVLTree<string, DataUnit> tree;
        private HashSet<string> loggedIn;

        public UserData()
        {
            tree = new AVLTree<string, DataUnit>();
            loggedIn = new HashSet<string>();
        }

        /// <summary>
        /// Searches for a user with the specified email<br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if the user doesn't exist
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User</returns>
        /// <exception cref="NoSuchElementException"></exception>
        public User SearchUser(string email)
        {
            try
            {
                log.Debug("SearchUser() for: " + email);
                User output = tree.GetData(email).User;
                log.Debug("SearchUser() success");
                return output;
            }
            catch (NoSuchElementException)
            {
                log.Error("SearchUser() failed: '" + email + "' doesn't exist in the system");
                throw new NoSuchElementException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }   
        }
        /// <summary>
        /// Adds a user to the system
        /// <br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if a user with this email<br/>
        /// already exists in the system
        /// </summary>
        /// <param name="email"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>The added <c>User</c></returns>
        public User AddUser(string email, string password)
        {
            try
            {
                log.Debug("AddUser() for: " + email);
                DataUnit data = tree.Add(email, new DataUnit());
                data.User = new User(email, password);
                data.Boards = new LinkedList<Board>();
                log.Debug("AddUser() success");
                return data.User;
            }
            catch (ArgumentException) 
            {
                log.Error("AddUser() failed: '" + email + "' already exists");
                throw new ArgumentException("A user with the email '" +
                    email + "' already exists in the system");
            }        
        }

        /// <summary>
        /// Removes the user with the specified email from the system
        /// <br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if the user doesn't exist in the system
        /// </summary>
        /// <param name="email"></param>
        /// <exception cref="NoSuchElementException"></exception>
        public void RemoveUser(string email) 
        {
            try
            {
                log.Debug("RemoveUser() for: " + email);
                tree.Remove(email);
                log.Debug("RemoveUser() success");
            }
            catch (NoSuchElementException) 
            {
                log.Error("RemoveUser() failed: '" + email + "' doesn't exist");
                throw new NoSuchElementException("A user with the email '" +
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
                log.Info(email+ " is now logged in");
                loggedIn.Add(email);
            }
                
            else 
            {
                log.Error("SetLoggedIn() failed: '"+ email + "' is already logged in");
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
            return tree.Contains(email);
        }

        /// <summary>
        /// Gets all the <c>User</c>'s <c>Board</c>s
        /// <br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if the <c>User</c> does not exist<br/>
        /// in the system
        /// </summary>
        /// <returns><c>LinkedList</c> of type <c>Board</c></returns>
        /// <exception cref="NoSuchElementException"></exception>
        public LinkedList<Board> GetBoards(string email)
        {
            try
            {
                log.Debug("GetBoards() for: " + email);
                LinkedList<Board> output = tree.GetData(email).Boards;
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
        /// Adds a <c>Board</c> to the <c>User</c>.
        ///<br/><br/>
        /// <b>Throws</b> <c>ArgumentException</c> if a <c>Board</c> with that title already exists <br/>
        /// for the <c>User</c><br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if the <c>User</c> doesn't exist <br/>
        /// in the system
        /// </summary>
        /// <returns>The <c>Board</c> that was added</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NoSuchElementException"></exception>
        public Board AddBoard(string email,string title) 
        {
            try
            {
                log.Debug("AddBoard() for: " + email + ", " + title);

                // Fetch the user's boards
                LinkedList<Board> boardList = tree.GetData(email).Boards;

                // Check if there's a board with that title already
                foreach (Board board in boardList) 
                {
                    if (board.Title == title)
                    {
                        log.Error("AddBoard() failed: board '" + title + "' already exists for " + email);
                        throw new ArgumentException("A board titled " +
                                title + " already exists for the user with the email " + email);
                    }
                }

                // Add a new board and return it
                Board toReturn = new(title);
                boardList.AddLast(toReturn);
                log.Debug("AddBoard() success");
                return toReturn;
            }
            catch (NullReferenceException)
            {
                throw new NoSuchElementException();
            }
            catch (NoSuchElementException)
            {
                log.Error("AddBoard() failed: '" + email + "' doesn't exist");
                throw new NoSuchElementException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
        }

        /// <summary>
        /// Removes a <c>User</c>'s <c>Board</c>
        /// <br/><br/>
        /// <b>Throws</b> <c>ArgumentException</c> if a <c>Board</c> with that title <br/>
        /// doesn't exist for the user<br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if the <c>User</c> doesn't exist <br/>
        /// in the system
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NoSuchElementException"></exception>
        public void RemoveBoard(string email, string title)
        {
            try
            {
                log.Debug("RemoveBoard() for: " + email + ", " + title);
                bool found = false;

                // Fetch the user's boards
                LinkedList<Board> boardList = tree.GetData(email).Boards;

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
                if (! found)
                {
                    log.Error("RemoveBoard() failed: board '" + title + "' doesn't exist for " + email);
                    throw new ArgumentException("A board titled '" +
                                    title + "' doesn't exists for the user with the email " + email);
                }  
            }
            catch (NoSuchElementException)
            {
                log.Error("AddBoard() failed: '" + email + "' doesn't exist");
                throw new NoSuchElementException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
        }
    }
}