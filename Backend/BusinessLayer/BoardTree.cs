using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class BoardTree : BinaryTree<string> 
    {
       
        public BoardTree()
        {
            root = null;
        }
        public LinkedList<Board> GetAllBoards(User user)
        {
            try
            {
                LinkedList<Board> AllBoards = (root.Search(user.getEmail()) as BoardTreeNode).GetAllBoards();
                if (AllBoards.Count == 0)
                {
                    throw new ArgumentException("User has no boards");
                }
                return AllBoards;
            }
            catch (NoSuchElementException)
            {
                throw new ArgumentException("User not found");
            }
            catch (ArgumentException) 
            {
                throw;
            }

        }
        public void AddBoard(User user, string name)
        {
            if (root == null)
            {
                root = new BoardTreeNode(user.getEmail());
                (root as BoardTreeNode).AddBoard(name);
            }
            else 
            {
                try
                {
                    (root.Search(user.getEmail()) as BoardTreeNode).AddBoard(name);
                }
                catch (NoSuchElementException)
                {
                    (root.Add(user.getEmail()) as BoardTreeNode).AddBoard(name);
                }
                catch (ArgumentException)
                {
                    throw;
                }
                
            }
        }
        public void RemoveBard(User user, string name)
        {
            try
            {
                (root.Search(user.getEmail()) as BoardTreeNode).RemoveBoard(name);
            }
            catch (NoSuchElementException)
            {
                throw new ArgumentException("User not found");
            }
            catch (ArgumentException) 
            {
                throw;
            }
        }
        private class BoardTreeNode : BinaryTreeNode
        {
            private readonly LinkedList<Board> boards;

            internal BoardTreeNode(string email) : base(email)
            {
                boards = new LinkedList<Board>();
            }
            internal LinkedList<Board> GetAllBoards()
            {
                return boards;
            }
            internal void AddBoard(string name)
            {
                foreach (Board board in boards)
                {
                    if (board.Title == name)
                    {
                        throw new ArgumentException("A board named "+name+" already exists");
                    }
                }
                boards.AddLast(new Board(name));
            }
            internal void RemoveBoard(string name)
            {
                bool found = false;
                foreach (Board board in boards)
                {
                    if (board.Title == name)
                    {
                        found = true;
                        boards.Remove(board);
                        break;
                    }
                }
                if (! found)
                {
                    throw new ArgumentException("Board named "+name+" doesn't exist");
                }
            }
        }
    }
}
