using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{

    //===========================================================================
    //                                AVLTree
    //===========================================================================



    /// <summary>
    /// ======================================================<br/>
    /// This class implements a generic AVL Tree that that is ordered with a key that is IComparable<br/>
    /// <b>The class does not support duplicate keys</b>
    /// <code>Supported operations:</code>
    /// <list type="bullet">Add()</list>
    /// <list type="bullet">Remove()</list>
    /// <list type="bullet">Contains()</list>
    /// <list type="bullet">GetData()</list>
    /// <list type="bullet">IsEmpty()</list>
    /// <br/><br/>
    /// ===================
    /// <br/>
    /// <c>Ⓒ Yuval Roth</c>
    /// <br/>
    /// ===================
    /// </summary>
    public class AVLTree<Key,Data> where Key : IComparable
    {
        private AVLTreeNode root;

        /// <summary>
        /// Creates an empty <c>AVLTree</c>
        /// </summary>
        public AVLTree()
        {
            root = null;
        }

        ///<summary>
        /// Adds an element into the <c>AVLTree</c>.<br/><br/>
        ///<b>throws</b> <c>ArgumentException</c> if an element with the same key already exists in the tree
        ///</summary>
        ///<exception cref="ArgumentException"></exception>
        ///<returns>A pointer to the new user's data</returns>
        public Data Add(Key key, Data data)
        {
            //check if element already exists in the tree
            //if (Contains(key)) throw new ArgumentException("Element already exists in the tree");

            // if tree is empty, add to the root
            if (root == null)
            {
                root = new AVLTreeNode(key,data, this);
                return root.Data;
            }
            //otherwise pass it down
            else
            {
                try
                {
                    return root.Add(key,data,this).Data;
                }
                catch(ArgumentException)
                {
                    throw;
                }
            }

        }

        ///<summary>
        ///Removes the element with this key from the <c>AVLTree</c><br/><br/>
        ///<b>Throws</b> <c>NoSuchElementException</c> if the element is not in the <c>AVLTree</c>
        ///</summary>
        ///<exception cref="NoSuchElementException"></exception>
        public void Remove(Key key)
        {
            if(root == null) throw new NoSuchElementException("No such element in the tree");
            try
            {
                root.Search(key).Remove();
            }
            catch (NoSuchElementException)
            {
                throw;
            }

            ////if the root is the target for removal
            //if (root.Key.CompareTo(key) == 0)
            //{
            //    //case 1: root has no children
            //    if (root.Left == null & root.Right == null)
            //    {
            //        root = null;
            //    }

            //    //case 2: root has only a right child
            //    else if (root.Left == null)
            //    {
            //        root = root.Right;
            //        root.Parent = null;
            //    }

            //    //case 3: root has only a left child
            //    else if (root.Right == null)
            //    {
            //        root = root.Left;
            //        root.Parent = null;
            //    }

            //    //case 4: root has 2 children
            //    else
            //    {
            //        AVLTreeNode successor = root.Successor().Remove();

            //        // copy children of old root
            //        if (root.Left != successor) successor.Left = root.Left;
            //        if (root.Right != successor) successor.Right = root.Right;

            //        // set children's parent to successor
            //        if (root.Left != null) root.Left.Parent = successor;
            //        if (root.Right != null) root.Right.Parent = successor;

            //        // make the swap
            //        root = successor;
            //        root.Parent = null;
            //    }
            //}
            //// root isn't the target for removal -> pass it down
            //else
            //{
            //    try
            //    {
            //        root.Search(key).Remove();
            //    }
            //    catch (NoSuchElementException)
            //    {
            //        throw;
            //    }
            //}


        }

        ///<summary>Check if the <c>AVLTree</c> contains an element with this key<br/><br/>
        /// </summary>
        ///<returns><c>true</c> if an element with this key exists in the tree and <c>false</c> otherwise</returns>
            public bool Contains(Key key)
        {
            if (root != null) return root.Contains(key);
            else return false;
        }

        ///<summary>Check if the <c>AVLTree</c> is empty</summary>
        ///<returns><c>true</c> if the tree is empty and <c>false</c> otherwise</returns>
        public bool IsEmpty()
        {
            return root == null;
        }

        /// <summary>
        /// search for an element with the specified key and get its <c>Data</c><br/><br/>
        /// <br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if there is no element<br/>
        /// with this key in the <c>AVLTree</c>
        /// </summary>
        /// <returns><c>The element's <c>Data</c></c></returns>
        /// <exception cref="NoSuchElementException"></exception>
        public Data GetData(Key key)
        {
            try
            {
                if(root != null) return root.Search(key).Data;
                else throw new NoSuchElementException("No such element in the tree");
            }
            catch (NoSuchElementException)
            {
                throw;
            }
        }
        public void PrintTree()
        {
            if (root != null) root.PrintTree();
            else Console.WriteLine("EmptyTree");
        }

        //===========================================================================
        //                                AVLTreeNode
        //===========================================================================

        private class AVLTreeNode
        {
            private readonly AVLTree<Key,Data> tree;
            private readonly Key key;
            private readonly Data data;
            private AVLTreeNode left;
            private AVLTreeNode right;
            private AVLTreeNode parent;
            private int height;

            public AVLTreeNode(Key key,Data data, AVLTree<Key,Data> tree)
            {
                this.tree = tree;
                left = null;
                right = null;
                parent = null;
                this.key = key;
                this.data = data;
                height = 0;
            }
            //======================================
            //            Getters / Setters
            //======================================

           
            public Key Key
            {
                get { return key; }
            }
            public Data Data
            {
                get { return data; }
            }
            public AVLTreeNode Left
            {
                get { return left; }
                set { left = value; }
            }
            public AVLTreeNode Right
            {
                get { return left; }
                set { left = value; }
            }
            public AVLTreeNode Parent
            {
                get { return parent; }
                set { parent = value; }
            }
            public int Height
            {
                get { return height; }
                set { height = value; }
            }

            //======================================
            //            Functionality
            //======================================



            ///<summary>
            /// Adds an element into the <c>AVLTree</c>.<br/><br/>
            ///<b>throws</b> <c>ArgumentException</c> if an element with the same key already exists in the tree
            ///</summary>
            ///<exception cref="ArgumentException"></exception>
            public AVLTreeNode Add(Key key, Data data, AVLTree<Key,Data> tree)
            {
                if (Key.CompareTo(key) == 0) throw new ArgumentException("");

                //find a place to add it
                if (this.key.CompareTo(key) > 0)
                {
                    //empty spot
                    if (left == null)
                    {
                        left = new AVLTreeNode(key, data, tree)
                        {
                            parent = this
                        };
                        //height++;
                        FixHeights();
                        if (parent != null) Balance();
                        return left;
                    }

                    //pass it down
                    else return left.Add(key, data,tree);
                }
                else
                {
                    //empty spot
                    if (right == null)
                    {
                        right = new AVLTreeNode(key, data, tree)
                        {
                            parent = this
                        };
                        //height++;
                        FixHeights();
                        if (parent != null) Balance();
                        return right;
                    }

                    //pass it down
                    else return right.Add(key, data, tree);
                }
            }

            ///<summary>Check if the <c>AVLTree</c> contains a node with this key</summary>
            ///<returns><c>true</c> if the node with this key exists in the tree and <c>false</c> otherwise</returns>
            public bool Contains(Key key)
            {
                try
                {
                    return Search(key) != null;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
          
            }

            /// <summary>
            /// search for a node with the specified key<br/><br/>
            /// <b>Throws</b> <c>NoSuchElementException</c> if a node with this key does not exist in the <c>AVLTree</c>
            /// </summary>
            /// <returns>AVLTreeNode</returns>
            /// <exception cref="NoSuchElementException"></exception>
            public AVLTreeNode Search(Key key)
            {
                //check if the current node is the target
                if (this.key.CompareTo(key) == 0)
                {
                    return this;
                }
                //binary search for it
                else if (left != null && this.key.CompareTo(key) > 0)
                {
                    return left.Search(key);
                }
                else if (right != null)
                {
                    return right.Search(key);
                }
                //can't find it
                else throw new NoSuchElementException("No such element in the tree");
            }

            ///<summary>
            ///Removes a node from the <c>AVLTree</c><br/><br/>
            ///
            ///<b>Warning:</b> Only works on a node that is in a tree.<br/>
            ///can throw unexpected exceptions if misused
            ///</summary>
            ///<returns>The removed AVLTreeNode</returns>
            public AVLTreeNode Remove()
            {
                // case 1: node has no children
                if (left == null & right == null)
                {
                    if (ThisNodeIsALeftSon())
                    {
                        parent.left = null;
                    }
                    else if (ThisNodeIsARightSon())
                    {
                        parent.right = null;
                    }
                    else tree.root = null;
                }

                // case 2: node only has a right child
                else if (right != null)
                {
                    if (ThisNodeIsALeftSon())
                    {
                        parent.left = right;
                    }
                    else if (ThisNodeIsARightSon())
                    {
                        parent.right = right;
                    }
                    else tree.root = right;
                    right.parent = parent;
                }

                // case 3: node only has a left child
                else if (left != null)
                {
                    if (ThisNodeIsALeftSon())
                    {
                        parent.left = left;
                    }
                    else if (ThisNodeIsARightSon())
                    {
                        parent.right = left;
                    }
                    else tree.root = left;
                    left.parent = parent;
                }

                // case 4: node has 2 children
                else
                {
                    AVLTreeNode successor = Successor().Remove();
                    if (this == tree.root) tree.root = successor;

                    // make the successor the child of the old node's parent
                    if (ThisNodeIsALeftSon()) parent.left = successor;
                    else if (ThisNodeIsARightSon()) parent.right = successor;

                    // copy children of old node
                    if (successor != left) successor.left = left;
                    if (successor != right) successor.right = right;

                    // set children's parent to successor
                    if (left != null) left.parent = successor;
                    if (right != null) right.parent = successor;

                    //copy parent of old node
                    successor.parent = parent;
                    
                }
                FixHeights();
                AVLTreeNode current = this;
                while (current.Balance())
                {
                    while (current != null && current.IsBalanced() == true) current = current.parent;
                    if (current == null) break;
                }
                return this;
            }
            private void FixHeights() 
            {
                AVLTreeNode current = this;
                while (current != null)
                {
                    if (current.left == null & current.right == null) current.height = 0;
                    else
                    {
                        int leftHeight = 0;
                        int rightHeight = 0;
                        if (current.left != null) leftHeight = current.left.Height;
                        if (current.right != null) rightHeight = current.right.Height;
                        if (leftHeight >= rightHeight) current.height = leftHeight + 1;
                        else current.height = rightHeight + 1;
                    }
                    current = current.parent;
                }
            }
            /// <summary>
            /// Find the successor of a node <br/><br/>
            /// <b>Throws</b> <c>NoSuchElementException</c> if there is no successor
            /// </summary>
            /// <returns>AVLTreeNode</returns>
            public AVLTreeNode Successor()
            {
                // if there is a right child
                // the minimum of the right subtree is the successor
                if (right != null)
                {
                    return right.Minimum();
                }

                // if the node is a left son the parent is the successor
                else if (ThisNodeIsALeftSon())
                {
                    return parent;
                }

                // the first bigger ancestor is the successor
                // if there is no bigger ancestor, return null
                else
                {
                    AVLTreeNode current = parent;
                    while (current != null && key.CompareTo(current.key) > 0)
                    {
                        current = current.parent;
                    }
                    if (current == null) throw new NoSuchElementException("No such element in the tree");
                    return current;
                }
            }

            /// <summary>
            /// Find the minimum in the <c>AVLTree</c>
            /// </summary>
            /// <returns>AVLTreeNode</returns>
            private AVLTreeNode Minimum()
            {

                // go left until there is more left to go
                AVLTreeNode current = this;
                while (current.left != null) 
                { 
                    current = current.left;
                }
                return current;
            }
            private bool ThisNodeIsARightSon() 
            {
                if (parent != null) return parent.right == this;
                
                return false;
            }
            private bool ThisNodeIsALeftSon()
            {
                if (parent != null) return parent.left == this;

                return false;
            }

            private bool IsBalanced()
            {
                int leftHeight = 0;
                int rightHeight = 0;
                if (left != null) leftHeight = left.Height;
                if (right != null) rightHeight = right.Height;

                if (Math.Abs(leftHeight - rightHeight) > 1)
                {
                    return false;
                }
                else return true;
            }
            /// <summary>
            /// Balances the current node or the first unbalanced ancestor it finds
            /// </summary>
            /// <returns>true if any balancing was done, false otherwise</returns>
            private bool Balance()
            {
                int leftHeight = 0;
                int rightHeight = 0;
                if (left != null) leftHeight = left.Height;
                if (right != null) rightHeight = right.Height;

                if (Math.Abs(leftHeight - rightHeight) > 1)
                {
                    if (leftHeight > rightHeight)
                    {
                        int leftLeftHeight = 0;
                        int leftRightHeight = 0;
                        if (left.left != null) leftLeftHeight = left.left.Height;
                        if (left.right != null) leftRightHeight = left.right.Height;
                        if (leftLeftHeight > leftRightHeight) LeftLeftRotation();
                        else LeftRightRotation();
                    }
                    else
                    {
                        int rightLeftHeight = 0;
                        int rightRightHeight = 0;
                        if (right.left != null) rightLeftHeight = right.left.Height;
                        if (right.right != null) rightRightHeight = right.right.Height;
                        if (rightRightHeight > rightLeftHeight) RightRightRotation();
                        else RightLeftRotation();
                    }
                    FixHeights();
                    return true;
                }
                else
                {
                    if (parent != null) return parent.Balance();
                    else return false;
                } 
            }
            private void LeftLeftRotation()
            {
                RightRotate();
            }
            private void LeftRightRotation()
            {
                left.LeftRotate();
                RightRotate();
            }
            private void RightRightRotation()
            {
                LeftRotate();
            }
            private void RightLeftRotation()
            {
                right.RightRotate();
                LeftRotate();
            }
            private void RightRotate()
            {
                AVLTreeNode leftRightChild = left.right;
                left.right = this;
                left.parent = parent;
                if (ThisNodeIsALeftSon()) parent.left = left;
                else if (ThisNodeIsARightSon()) parent.right = left;
                else tree.root = left;
                parent = left;
                left = leftRightChild;
                if (leftRightChild != null) leftRightChild.parent = this;
            }
            private void LeftRotate()
            {
                AVLTreeNode rightLeftChild = right.left;
                right.left = this;
                right.parent = parent;
                if (ThisNodeIsALeftSon()) parent.left = right;
                else if (ThisNodeIsARightSon()) parent.right = right;
                else tree.root = right;
                parent = right;
                right = rightLeftChild;
                if(rightLeftChild != null) rightLeftChild.parent = this;
            }
            public void PrintTree()
            {
                PrintTree("  ");
            }
            private void PrintTree(string spaces)
            {
                if(right != null) right.PrintTree(spaces + "     ");
                Console.WriteLine(spaces + Key.ToString());
                if(left != null) left.PrintTree(spaces + "     ");
            }
        }
        
    }
}
