using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{

    //===========================================================================
    //                                BoardTree
    //===========================================================================


    ///// <summary>
    ///// This class extends BinaryNode.<br/>
    ///// The class manages a data structure of of <c>Board</c>s. <br/>
    ///// The key used in all operations of this class is a <c>User</c> object. <br/>
    ///// every unique <c>User</c> has his own set of <c>Board</c>s.
    ///// 
    ///// <code>Supported operations:</code>
    ///// <list type="bullet">AddBoard()</list>
    ///// <list type="bullet">RemoveBoard()</list>
    ///// <list type="bullet">GetAllBoards()</list>
    ///// <br/><br/>
    ///// ===================
    ///// <br/>
    ///// <c>Ⓒ Yuval Roth</c>
    ///// <br/>
    ///// ===================
    ///// </summary>
    public class UserData
    {
        private class DataUnit
        {
            public User User { get; set; }
            public LinkedList<Board> boards { get; set; }
        }
        private BinaryTree<string, DataUnit> tree;

        /// <summary>
        /// Creates an empty <c>BoardTree</c>
        /// </summary>
        public UserData()
        {
            tree = new BinaryTree<string, DataUnit>();
        }
        public User SearchUser(string email)
        {
            return tree.GetData(email).User;
        }
        public void AddUser(string email)
        {
            
        
        }
        public LinkedList<Board> GetAllBoards(string email)
        {
            return tree.GetData(email).boards;
        }
    }
}
//        /// <summary>
//        /// Gets all the <c>User</c>'s <c>Board</c>s
//        /// <br/><br/>
//        /// <b>Throws</b> <c>ArgumentException</c> if the <c>User</c> has no boards
//        /// </summary>
//        /// <returns><c>LinkedList</c> of type <c>Board</c></returns>
//        /// <exception cref="ArgumentException"></exception>
//        public LinkedList<Board> GetAllBoards(User user) 
//        {
//            //===================================================================
//            // TO DO: verify the user exists in the system through UserController
//            //===================================================================

//            try
//            {
//                LinkedList<Board> AllBoards = (root.Search(user.GetEmail()) as BoardTreeNode).GetAllBoards();
//                if (AllBoards.Count == 0)
//                {
//                    throw new ArgumentException("User has no boards");
//                }
//                return AllBoards;
//            }
//            catch (NoSuchElementException)
//            {
//                throw new ArgumentException("User has no boards");
//            }
//            catch (NullReferenceException) 
//            {
//                throw new ArgumentException("User has no boards");
//            }
//            catch (ArgumentException)
//            {
//                throw;
//            }


//        }

//        /// <summary>
//        /// Adds a <c>Board</c> to the <c>User</c>. If the <c>User</c> doesn't have any boards yet <br/>
//        /// The first one will be added to him.
//        ///<br/><br/>
//        ///<b>Throws</b> <c>ArgumentException</c> if <c>Board</c> with that title already exists <br/>
//        /// for the <c>User</c>
//        /// </summary>
//        /// <returns>The <c>Board</c> that was added</returns>
//        /// <exception cref="ArgumentException"></exception>
//        public Board AddBoard(User user, string title)
//        {
//            if (root == null)
//            {
//                root = new BoardTreeNode(user.GetEmail());
//                return (root as BoardTreeNode).AddBoard(title);
//            }
//            else 
//            {
//                try
//                {
//                    return (root.Search(user.GetEmail()) as BoardTreeNode).AddBoard(title);
//                }
//                catch (NoSuchElementException)
//                {
//                    return (root.Add(user.GetEmail()) as BoardTreeNode).AddBoard(title);
//                }
//                catch (ArgumentException)
//                {
//                    throw;
//                }
                
//            }
//        }


//        /// <summary>
//        /// Removes a <c>User</c>'s <c>Board</c>
//        /// <br/><br/>
//        /// <b>Throws</b> <c>ArgumentException</c> if a <c>Board</c> with that title <br/>
//        /// doesn't exist for the user
//        /// </summary>
//        /// <exception cref="ArgumentException"></exception>
//        public void RemoveBoard(User user, string title)
//        {
//            try
//            {
//                (root.Search(user.GetEmail()) as BoardTreeNode).RemoveBoard(title);
//            }
//            catch (ArgumentException)
//            {
//                throw;
//            }
//            catch (NoSuchElementException)
//            {
//                throw new ArgumentException("Board titled " + title + " doesn't exist for that user");
//            }
//            catch (NullReferenceException)
//            {
//                throw new ArgumentException("Board titled " + title + " doesn't exist for that user");
//            }
            
//        }


//        //===========================================================================
//        //                                BoardTreeNode
//        //===========================================================================



//        private class BoardTreeNode : BinaryTreeNode
//        {
//            private readonly LinkedList<Board> boards;

//            internal BoardTreeNode(string email) : base(email)
//            {
//                boards = new LinkedList<Board>();
//            }
//            /// <summary>
//            /// Gets all the boards from the BoardTreeNode
//            /// </summary>
//            /// <returns><c>LinkedList</c> of type <c>Board</c></returns>
//            internal LinkedList<Board> GetAllBoards()
//            {
//                return boards;
//            }

//            /// <summary>
//            /// Adds a <c>Board</c> to the BoardTreeNode
//            ///<br/><br/>
//            ///<b>Throws</b> <c>ArgumentException</c> if a board with that title already exists
//            /// </summary>
//            /// <returns>The <c>Board</c> that was added</returns>
//            /// <exception cref="ArgumentException"></exception>
//            internal Board AddBoard(string title)
//            {
//                foreach (Board board in boards)
//                {
//                    if (board.Title == title)
//                    {
//                        throw new ArgumentException("A board titled "+title+" already exists");
//                    }
//                }
//                Board toAdd = new Board(title);
//                boards.AddLast(toAdd);
//                return toAdd;
//            }

//            /// <summary>
//            /// Removes a board from the BoardTreeNode
//            /// <br/><br/>
//            /// <b>Throws</b> <c>ArgumentException</c> if a board with that title doesn't exist
//            /// </summary>
//            /// <exception cref="ArgumentException"></exception>
//            internal void RemoveBoard(string title)
//            {
//                bool found = false;
//                foreach (Board board in boards)
//                {
//                    if (board.Title == title)
//                    {
//                        found = true;
//                        boards.Remove(board);
//                        break;
//                    }
//                }
//                if (! found)
//                {
//                    throw new ArgumentException("Board titled "+title+" doesn't exist for that user");
//                }
//            }
//        }
//    }
//}
