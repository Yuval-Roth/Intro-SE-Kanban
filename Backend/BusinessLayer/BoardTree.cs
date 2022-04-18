using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    internal class BoardTree<T> : BinaryTree<T> 
    {
       
        public BoardTree() 
        {
        }
        public LinkedList<Board> getAllBoards(User user)
        {
        }
        public void addBoard(User user, Board toAdd)
        { 
        }
        public void removeBard(User user, Board toRemove)
        { 
        }
        private class BoardTreeNode : BinaryTreeNode<>
        {
            internal BoardTreeNode()
            {
            }
            internal LinkedList<Board> getAllBoards(User user)
            {
            }
            internal void addBoard(User user, Board toAdd)
            {
            }
            internal void removeBard(User user, Board toRemove)
            {
            }
        }
    }
}
