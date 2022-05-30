using System;
using System.Collections.Generic;

namespace IntroSE.Kanban.Backend.BusinessLayer
{

    //===========================================================================
    //                                DataCenter
    //===========================================================================


    /// <summary>
    /// The class manages a data structure of of <c>User</c>s and <c>Board</c>s. <br/><br/>
    /// The class provides an interface for the inner data structures and performs most of the<br/>
    /// basic operations needed.<br/><br/>
    /// 
    /// <b>No checks are being done to ensure whether or not those operations are legal or sensible.</b><br/>
    /// for example: the class does not check whether or not a user is logged in before performing operations.<br/>
    /// this class is simply a tool for using the inner data structures
    /// 
    /// <code>Supported operations:</code>
    /// <b>-------------User Related--------------</b>
    /// <list type="bullet">
    /// <item>SearchUser(email)</item>
    /// <item>AddUser(email,password)</item>
    /// <item>RemoveUser(email)</item>
    /// <item>ContainsUser(email)</item>
    /// <item>UserLoggedInStatus(email)</item>
    /// <item>SetLoggedIn(email)</item>
    /// <item>SetLoggedOut(email)</item>
    /// </list>
    /// <b>-------------Boards Related--------------</b>
    /// <list type="bullet">
    /// <item>GetBoardsDataUnit(email)</item>
    /// <item>SearchBoardById(board_id)</item>
    /// <item>AddNewBoard(email,board_title)</item>
    /// <item>AddPointerToJoinedBoard(email,board_id)</item>
    /// <item>RemovePointerToJoinedBoard(email,board_id)</item>
    /// <item>NukeBoard(email,board_title)</item>
    /// <item>NukeBoard(board_id)</item>
    /// <item>ChangeOwnerPointer(old_owner,board_title,new_owner)</item>
    /// </list>
    /// <br/>
    /// ===================
    /// <br/>
    /// <c>Ⓒ Yuval Roth</c>
    /// <br/>
    /// ===================
    /// </summary>
    public class DataCenter : UserDataOperations, BoardDataOperations
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Backend\\BusinessLayer\\DataCenter.cs");

        private struct DataUnit
        {
            public User User { get; init; }
            public BoardsDataUnit BoardsDataUnit { get; init; }
        }
        public struct BoardsDataUnit
        {
            public LinkedList<Board> MyBoards { get; init; }
            public LinkedList<Board> JoinedBoards { get; init; }
        }
        private readonly AVLTree<string, DataUnit> UsersAndBoardsTree;
        private readonly AVLTree<int, Board> OnlyBoardsTree;
        private readonly HashSet<string> loggedIn;
        private int nextBoardID;

        public DataCenter()
        {
            UsersAndBoardsTree = new();
            OnlyBoardsTree = new();
            loggedIn = new();
            //LoadData();
        }


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
                User output = UsersAndBoardsTree.GetData(email).User;
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
                DataUnit data = UsersAndBoardsTree.Add(email, new DataUnit()
                {
                    User = new User(email, password),
                    BoardsDataUnit = new()
                    {
                        MyBoards = new LinkedList<Board>(),
                        JoinedBoards = new LinkedList<Board>()
                    }
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
            throw new NotImplementedException("Not updated to support current implementation");
            try
            {
                log.Debug("RemoveUser() for: " + email);
                UsersAndBoardsTree.Remove(email);
                /*
                    TO DO:
                    Take care of boards of deleted users, including joined
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

        /// <summary>
        /// Check if a user exists in the system
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true or false</returns>
        public bool ContainsUser(string email)
        {
            log.Debug("ContainsUser() for: " + email);
            return UsersAndBoardsTree.Contains(email);
        }

        /// <summary>
        /// Gets all the <c>User</c>'s boards data
        /// <br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if the <c>User</c> does not exist<br/>
        /// in the system
        /// </summary>
        /// <returns><see cref="BoardsDataUnit"/></returns>
        /// <exception cref="UserDoesNotExistException"></exception>
        public BoardsDataUnit GetBoardsDataUnit(string email)
        {
            try
            {
                log.Debug("GetBoardsDataUnit() for: " + email);
                DataUnit data = UsersAndBoardsTree.GetData(email);
                log.Debug("GetBoardsDataUnit() success");
                return data.BoardsDataUnit;
            }
            catch (KeyNotFoundException)
            {
                log.Error("GetBoardsDataUnit() failed: '" + email + "' doesn't exist");
                throw new UserDoesNotExistException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
        }

        /// <summary>
        /// Gets all the <c>User</c>'s <c>Board</c>s
        /// <br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if the <c>User</c> does not exist<br/>
        /// in the system
        /// </summary>
        /// <returns><see cref="Board"/></returns>
        /// <exception cref="NoSuchElementException"></exception>
        public Board SearchBoardById(int id)
        {
            try
            {
                log.Debug("SearchBoardById() for: " + id);
                Board output = OnlyBoardsTree.GetData(id);
                log.Debug("SearchBoardById() success");
                return output;
            }
            catch (KeyNotFoundException)
            {
                log.Error("SearchBoardById() failed: board number '" + id + "' doesn't exist");
                throw new NoSuchElementException("Board number '" + id + "' doesn't exist");
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
                log.Debug("AddNewBoard() for: " + email + ", " + title);

                // Fetch the user's boards
                LinkedList<Board> myBoardList = UsersAndBoardsTree.GetData(email).BoardsDataUnit.MyBoards;

                // Check if there's a board with that title already
                foreach (Board board in myBoardList)
                {
                    if (board.Title == title)
                    {
                        log.Error("AddNewBoard() failed: board '" + title + "' already exists for " + email);
                        throw new ElementAlreadyExistsException("A board titled " +
                                title + " already exists for the user with the email " + email);
                    }
                }

                // Add a new board and return it
                Board newBoard = new(title, GetNextBoardID);
                OnlyBoardsTree.Add(newBoard.Id, newBoard);
                myBoardList.AddLast(newBoard);
                log.Debug("AddNewBoard() success");
                return newBoard;
            }
            catch (DuplicateKeysNotSupported)
            {
                log.Fatal("AddNewBoard() failed: BoardIDCounter is out of sync");
                throw new DataMisalignedException("BoardIDCounter is out of sync");
            }
            catch (KeyNotFoundException)
            {
                log.Error("AddNewBoard() failed: '" + email + "' doesn't exist");
                throw new UserDoesNotExistException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
        }

        /// <summary>
        /// Adds a pointer of an existing board to the user's JoinedBoards.<br/><br/>
        /// <b>Throws</b> <c>ElementAlreadyExistsException</c> if the user is already joined on the board<br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if the user doesn't exist in the system<br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if a board with that id doesn't exist<br/>
        /// </summary>
        /// <param name="email"></param>
        /// <param name="id"></param>
        /// <exception cref="ElementAlreadyExistsException"></exception>
        /// <exception cref="UserDoesNotExistException"></exception>
        /// <exception cref="NoSuchElementException"></exception>
        public Board AddPointerToJoinedBoard(string email, int id)
        {
            try
            {
                log.Debug("AddPointerToJoinedBoard() for: " + email + ", " + id);

                LinkedList<Board> joinedBoardList = UsersAndBoardsTree.GetData(email).BoardsDataUnit.JoinedBoards;
                Board boardToJoin = OnlyBoardsTree.GetData(id);

                // Check if the user is joined on the board already
                foreach (Board board in joinedBoardList)
                {
                    if (board.Id == id)
                    {
                        log.Error("AddPointerToJoinedBoard() failed: " + email + " is already joined on board nubmer " + id);
                        throw new ElementAlreadyExistsException(email + " is already joined on board nubmer " + id);
                    }
                }
                joinedBoardList.AddLast(boardToJoin);
                log.Debug("AddPointerToJoinedBoard() success");
                return boardToJoin;
            }
            catch (KeyNotFoundException)
            {
                if (UsersAndBoardsTree.Contains(email) == false)
                {
                    log.Error("AddPointerToJoinedBoard() failed: '" + email + "' doesn't exist");
                    throw new UserDoesNotExistException("A user with the email '" +
                        email + "' doesn't exist in the system");
                }
                else if (OnlyBoardsTree.Contains(id) == false)
                {
                    log.Error("AddPointerToJoinedBoard() failed: board number " + id + "doesn't exist");
                    throw new NoSuchElementException("Board number " + id + "doesn't exist");
                }
                else {
                    log.Fatal("AddPointerToJoinedBoard(): Unexpected error");
                    throw new OperationCanceledException("Unexpected error");
                } 
            }  
        }

        /// <summary>
        /// Removes the pointer of the joined board from the user's JoinedBoards<br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if the user doesn't exist in the system<br/>
        /// <b>Throws</b> <c>ArgumentException</c> if the user is not joined on a board with that id<br/>
        /// </summary>
        /// <param name="email"></param>
        /// <param name="id"></param>
        /// <returns>The unjoined board</returns>
        /// <exception cref="UserDoesNotExistException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Board RemovePointerToJoinedBoard(string email, int id) 
        {
            try
            {
                log.Debug("RemovePointerToJoinedBoard() for: " + email + ", " + id);

                // Fetch the user's boards
                LinkedList<Board> joinedBoardList = UsersAndBoardsTree.GetData(email).BoardsDataUnit.JoinedBoards;
            
                // Search for the specific board
                for (LinkedListNode<Board> node = joinedBoardList.First; node != null; node = node.Next)
                {
                    if (node.Value.Id == id)
                    {
                        Board output = node.Value;
                        joinedBoardList.Remove(node);
                        log.Debug("RemovePointerToJoinedBoard() success");
                        return output;
                    }
                }

                // didn't find a board by that id
                log.Error("RemovePointerToJoinedBoard() failed: " + email + " is not joined to board nubmer " + id);
                throw new ArgumentException(email + " is not joined to board nubmer " + id);
            }
            catch (KeyNotFoundException)
            {
                log.Error("RemovePointerToJoinedBoard() failed: '" + email + "' doesn't exist");
                throw new UserDoesNotExistException("A user with the email '" +
                    email + "' doesn't exist in the system");

            }
        }

        /// <summary>
        /// Removes a <c>Board</c> from the <b>entire system</b><br/>
        /// <br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if,  for some reason, a board with that id <br/>
        /// doesn't exist in the system in general or specifically for its owner<br/><br/>
        /// <b>Throws</b> <c>ArgumentException</c> if, for some reason, a board with that id doesn't<br/>
        /// exist for any of the joined users<br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if, for some reason, one of the board's joined users doesn't exist <br/>
        /// in the system
        /// </summary>
        /// <exception cref="NoSuchElementException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="UserDoesNotExistException"></exception>
        public void NukeBoard(int id)
        {
            try
            {
                Board removed = RemoveBoardById(id);
                RemoveBoardFromOwner(removed.Owner, removed.Title);
                foreach (string joinedEmail in removed.Joined)
                {
                    RemovePointerToJoinedBoard(joinedEmail, removed.Id);
                }
            }
            catch (NoSuchElementException) { throw; }
            catch (UserDoesNotExistException) { throw; }
            catch (ArgumentException) { throw; }
        }

        /// <summary>
        ///  Completly removes a <c>Board</c> from the <b>entire system</b><br/>
        /// <br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if,  for some reason, a board with that id <br/>
        /// doesn't exist in the system in general or specifically for its owner<br/><br/>
        /// <b>Throws</b> <c>ArgumentException</c> if, for some reason, a board with that id doesn't<br/>
        /// exist for any of the joined users<br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if, for some reason, one of the board's joined users doesn't exist <br/>
        /// in the system
        /// </summary>
        /// <exception cref="NoSuchElementException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="UserDoesNotExistException"></exception>
        public void NukeBoard(string email, string title)
        {
            try
            {
                Board removed = RemoveBoardFromOwner(email, title);
                RemoveBoardById(removed.Id);
                foreach (string joinedEmail in removed.Joined)
                {
                    RemovePointerToJoinedBoard(joinedEmail, removed.Id);
                }
            }
            catch (NoSuchElementException) { throw; }
            catch (UserDoesNotExistException) { throw; }
            catch (ArgumentException) { throw; }
        }

        /// <summary>
        /// Remove pointer from old owner and add pointer to new owner<br/><br/>
        /// <b>Throws</b> <c>ElementAlreadyExistsException</c> if a board with that title already exists for the newOwner<br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if a user with that email doesn't exist<br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if a <c>Board</c> with that title <br/>
        /// doesn't exist for the oldOwner<br/><br/>
        /// </summary>
        /// <param name="oldOwner"></param>
        /// <param name="boardName"></param>
        /// <param name="newOwner"></param>
        public void ChangeOwnerPointer(string oldOwner,string boardName, string newOwner)
        {
            try
            {
                AddExistingBoard(newOwner, RemoveBoardFromOwner(oldOwner, boardName));
            }
            catch (NoSuchElementException) { throw; }
            catch (UserDoesNotExistException) { throw; }
            catch (ElementAlreadyExistsException) { throw; }
        }

        /// <summary>
        /// <b>Throws</b> <c>ElementAlreadyExistsException</c> if a board with that title already exists for the user<br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if a user with that email doesn't exist
        /// </summary>
        /// <param name="email"></param>
        /// <param name="newBoard"></param>
        /// <exception cref="ElementAlreadyExistsException"></exception>
        /// <exception cref="UserDoesNotExistException"></exception>
        private void AddExistingBoard(string email, Board newBoard)
        {
            try
            {
                log.Debug("AddExistingBoard() for: " + email + ", " + newBoard.Title);

                // Fetch the user's boards
                LinkedList<Board> myBoardList = UsersAndBoardsTree.GetData(email).BoardsDataUnit.MyBoards;

                // Check if there's a board with that title already
                foreach (Board board in myBoardList)
                {
                    if (board.Title == newBoard.Title)
                    {
                        log.Error("AddExistingBoard() failed: board '" + newBoard.Title + "' already exists for " + email);
                        throw new ElementAlreadyExistsException("A board titled " +
                                newBoard.Title + " already exists for the user with the email " + email);
                    }
                }

                // Add the board
                myBoardList.AddLast(newBoard);
                log.Debug("AddExistingBoard() success");
            }
            catch (KeyNotFoundException)
            {
                log.Error("AddExistingBoard() failed: '" + email + "' doesn't exist");
                throw new UserDoesNotExistException("A user with the email '" +
                    email + "' doesn't exist in the system");
            }
        }

        /// <summary>
        /// Removes a board from BoardTree
        /// <br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if a <c>Board</c> with that id <br/>
        /// doesn't exist in the system<br/><br/>
        /// </summary>
        /// <exception cref="NoSuchElementException"></exception>
        /// <returns>The removed Board</returns>
        private Board RemoveBoardById(int id)
        {
            try
            {
                log.Debug("RemoveBoardById() for: "+ id);
                Board output = OnlyBoardsTree.Remove(id);
                log.Debug("RemoveBoardById() success");
                return output;
            }
            catch (KeyNotFoundException)
            {
                log.Error("RemoveBoard() failed: board numbered '" + id + "' doesn't exist in the system");
                throw new UserDoesNotExistException("board numbered '" + id + "' doesn't exist in the system");
            }
        }

        /// <summary>
        /// Removes a board from the owner inside UsersAndBoardsTree
        /// <br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if a <c>Board</c> with that title <br/>
        /// doesn't exist for the user<br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if the <c>User</c> doesn't exist <br/><br/>
        /// in the system
        /// </summary>
        /// <exception cref="NoSuchElementException"></exception>
        /// <exception cref="UserDoesNotExistException"></exception>
        /// <returns>The removed Board</returns>
        private Board RemoveBoardFromOwner(string email, string title)
        {
            try
            {
                log.Debug("RemoveBoardByEmailAndTitle() for: " + email + ", " + title);

                // Fetch the user's boards
                LinkedList<Board> myBoardList = UsersAndBoardsTree.GetData(email).BoardsDataUnit.MyBoards;

                // Search for the specific board
                for (LinkedListNode<Board> node = myBoardList.First; node != null; node = node.Next)
                {
                    if (node.Value.Title == title)
                    {
                        Board output = node.Value;
                        myBoardList.Remove(node);
                        log.Debug("RemoveBoardByEmailAndTitle() success");
                        return output;
                    }
                }

                // didn't find a board by that name
 
                log.Error("RemoveBoardByEmailAndTitle() failed: board '" + title + "' doesn't exist for " + email);
                throw new NoSuchElementException("A board titled '" +
                                title + "' doesn't exists for the user with the email " + email);
            }
            catch (KeyNotFoundException)
            {
                log.Error("RemoveBoardByEmailAndTitle() failed: '" + email + "' doesn't exist in the system");
                throw new UserDoesNotExistException("A user with the email '" +
                    email + "' doesn't exist in the system");

            }
        }

        /// <summary>
        /// Auto incrementing counter for boards ID.<br/>
        /// Everytime this method is called, the counter in incremented.
        /// </summary>
        private int GetNextBoardID => nextBoardID++;
        
        private void LoadData()
        {
            throw new NotImplementedException();
        }

    }
    public interface UserDataOperations
    {
        /// <summary>
        /// Searches for a user with the specified email<br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if the user doesn't exist
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User</returns>
        /// <exception cref="UserDoesNotExistException"></exception>
        public User SearchUser(string email);

        /// <summary>
        /// Adds a user to the system
        /// <br/><br/>
        /// <b>Throws</b> <c>ElementAlreadyExists</c> if a user with this email<br/>
        /// already exists in the system
        /// </summary>
        /// <param name="email"></param>
        /// <exception cref="ElementAlreadyExistsException"></exception>
        /// <returns>The added <c>User</c></returns>
        public User AddUser(string email, string password);

        /// <summary>
        /// Removes the user with the specified email from the system
        /// <br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if the user doesn't exist in the system
        /// </summary>
        /// <param name="email"></param>
        /// <exception cref="UserDoesNotExistException"></exception>
        public void RemoveUser(string email);

        /// <summary>
        /// Check if a user exists in the system
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true or false</returns>
        public bool ContainsUser(string email);

        /// <summary>
        /// Gets the user's logged in status
        /// </summary>
        /// <returns><c>true</c> if the user is logged in, <c>false</c>  otherwise</returns>
        /// <param name="email"></param>
        public bool UserLoggedInStatus(string email);

        /// <summary>
        /// Sets a user's logged in status to true
        /// <br/><br/>
        /// <b>Throws</b> <c>ArgumentException</c> if the user's logged in status is already true
        /// </summary>
        /// <param name="email"></param>
        /// <exception cref="ArgumentException"></exception>
        public void SetLoggedIn(string email);

        /// <summary>
        /// Sets a user's logged in status to false
        /// <br/><br/>
        /// <b>Throws</b> <c>ArgumentException</c> if the user's logged in status is already false
        /// </summary>
        /// <param name="email"></param>
        /// <exception cref="ArgumentException"></exception>
        public void SetLoggedOut(string email);
    }
    public interface BoardDataOperations 
    {
        /// <summary>
        /// Gets the user's logged in status
        /// </summary>
        /// <returns><c>true</c> if the user is logged in, <c>false</c>  otherwise</returns>
        /// <param name="email"></param>
        public bool UserLoggedInStatus(string email);

        /// <summary>
        /// Gets all the <c>User</c>'s boards data
        /// <br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if the <c>User</c> does not exist<br/>
        /// in the system
        /// </summary>
        /// <returns><see cref="BoardsDataUnit"/></returns>
        /// <exception cref="UserDoesNotExistException"></exception>
        public DataCenter.BoardsDataUnit GetBoardsDataUnit(string email);

        /// <summary>
        /// Gets all the <c>User</c>'s <c>Board</c>s
        /// <br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if the <c>User</c> does not exist<br/>
        /// in the system
        /// </summary>
        /// <returns><see cref="Board"/></returns>
        /// <exception cref="NoSuchElementException"></exception>
        public Board SearchBoardById(int board_id);

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
        public Board AddNewBoard(string email,string board_title);

        /// <summary>
        /// Adds a pointer of an existing board to the user's JoinedBoards.<br/><br/>
        /// <b>Throws</b> <c>ElementAlreadyExistsException</c> if the user is already joined on the board<br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if the user doesn't exist in the system<br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if a board with that id doesn't exist<br/>
        /// </summary>
        /// <param name="email"></param>
        /// <param name="id"></param>
        /// <exception cref="ElementAlreadyExistsException"></exception>
        /// <exception cref="UserDoesNotExistException"></exception>
        /// <exception cref="NoSuchElementException"></exception>
        public Board AddPointerToJoinedBoard(string email,int board_id);

        /// <summary>
        /// Removes the pointer of the joined board from the user's JoinedBoards<br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if the user doesn't exist in the system<br/>
        /// <b>Throws</b> <c>ArgumentException</c> if the user is not joined on a board with that id<br/>
        /// </summary>
        /// <param name="email"></param>
        /// <param name="id"></param>
        /// <returns>The unjoined board</returns>
        /// <exception cref="UserDoesNotExistException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Board RemovePointerToJoinedBoard(string email,int board_id);

        /// <summary>
        /// Removes a <c>Board</c> from the <b>entire system</b><br/>
        /// <br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if,  for some reason, a board with that id <br/>
        /// doesn't exist in the system in general or specifically for its owner<br/><br/>
        /// <b>Throws</b> <c>ArgumentException</c> if, for some reason, a board with that id doesn't<br/>
        /// exist for any of the joined users<br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if, for some reason, one of the board's joined users doesn't exist <br/>
        /// in the system
        /// </summary>
        /// <exception cref="NoSuchElementException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="UserDoesNotExistException"></exception>
        public void NukeBoard(string email,string board_title);

        /// <summary>
        ///  Completly removes a <c>Board</c> from the <b>entire system</b><br/>
        /// <br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if,  for some reason, a board with that id <br/>
        /// doesn't exist in the system in general or specifically for its owner<br/><br/>
        /// <b>Throws</b> <c>ArgumentException</c> if, for some reason, a board with that id doesn't<br/>
        /// exist for any of the joined users<br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if, for some reason, one of the board's joined users doesn't exist <br/>
        /// in the system
        /// </summary>
        /// <exception cref="NoSuchElementException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="UserDoesNotExistException"></exception>
        public void NukeBoard(int board_id);

        /// <summary>
        /// Remove pointer from old owner and add pointer to new owner<br/><br/>
        /// <b>Throws</b> <c>ElementAlreadyExistsException</c> if a board with that title already exists for the newOwner<br/><br/>
        /// <b>Throws</b> <c>UserDoesNotExistException</c> if a user with that email doesn't exist<br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if a <c>Board</c> with that title <br/>
        /// doesn't exist for the oldOwner<br/><br/>
        /// </summary>
        /// <param name="oldOwner"></param>
        /// <param name="boardName"></param>
        /// <param name="newOwner"></param>
        public void ChangeOwnerPointer(string old_owner,string board_title,string new_owner);
    }
}