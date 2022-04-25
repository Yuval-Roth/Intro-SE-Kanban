using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{

    //===========================================================================
    //                                BinaryTree
    //===========================================================================



    /// <summary>
    /// ======================================================<br/>
    /// This class implements a generic binary tree that that is ordered with a key that is IComparable<br/>
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
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class BinaryTree<Key,Data> where Key : IComparable
    {
        private BinaryTreeNode root;

        /// <summary>
        /// Creates an empty <c>BinaryTree</c>
        /// </summary>
        public BinaryTree()
        {
            root = null;
        }

        ///<summary>
        /// Adds an element into the <c>BinaryTree</c>.<br/><br/>
        ///<b>throws</b> <c>ArgumentException</c> if an element with the same key already exists in the tree
        ///</summary>
        ///<exception cref="ArgumentException"></exception>
        ///<returns>A pointer to the new user's data</returns>
        public Data Add(Key key, Data data)
        {
            // if tree is empty, add to the root
            if (root == null)
            {
                root = new BinaryTreeNode(key,data);
                return root.Data;
            }
            //otherwise pass it down
            else
            {
                try
                {
                    return root.Add(key,data).Data;
                }
                catch(ArgumentException)
                {
                    throw;
                }
            }

        }

        ///<summary>
        ///Removes the element with this key from the <c>BinaryTree</c><br/><br/>
        ///<b>Throws</b> <c>NoSuchElementException</c> if the element is not in the <c>BinaryTree</c>
        ///</summary>
        ///<exception cref="NoSuchElementException"></exception>
        public void Remove(Key key)
        {
            if(root == null) throw new NoSuchElementException("No such element in the tree");

            //if the root is the target for removal
            if (root.Key.CompareTo(key) == 0)
            {
                //case 1: root has no children
                if (root.Left == null & root.Right == null)
                {
                    root = null;
                }

                //case 2: root has only a right child
                else if (root.Left == null)
                {
                    root = root.Right;
                    root.Parent = null;
                }

                //case 3: root has only a left child
                else if (root.Right == null)
                {
                    root = root.Left;
                    root.Parent = null;
                }

                //case 4: root has 2 children
                else
                {
                    BinaryTreeNode successor = root.Successor();
                    successor.Remove();

                    // copy children of old root
                    if (root.Left != successor) successor.Left = root.Left;
                    if (root.Right != successor) successor.Right = root.Right;

                    // set children's parent to successor
                    if (root.Left != null) root.Left.Parent = successor;
                    if (root.Right != null) root.Right.Parent = successor;

                    // make the swap
                    root = successor;
                    root.Parent = null;
                }
            }
            // root isn't the target for removal -> pass it down
            else
            {
                try
                {
                    root.Search(key).Remove();
                }
                catch (NoSuchElementException)
                {
                    throw;
                }
            }
            
               
        }

        ///<summary>Check if the <c>BinaryTree</c> contains an element with this key<br/><br/>
        /// </summary>
        ///<returns><c>true</c> if an element with this key exists in the tree and <c>false</c> otherwise</returns>
        public bool Contains(Key key)
        {
           return root.Contains(key);
        }

        ///<summary>Check if the <c>BinaryTree</c> is empty</summary>
        ///<returns><c>true</c> if the tree is empty and <c>false</c> otherwise</returns>
        public bool IsEmpty()
        {
            return root == null;
        }

        /// <summary>
        /// search for an element with the specified key and get its <c>Data</c><br/><br/>
        /// <br/><br/>
        /// <b>Throws</b> <c>NoSuchElementException</c> if there is no element<br/>
        /// with this key in the <c>BinaryTree</c>
        /// </summary>
        /// <returns><c>The element's <c>Data</c></c></returns>
        /// <exception cref="NoSuchElementException"></exception>
        public Data GetData(Key key) 
        {
            try
            {
                return root.Search(key).Data;
            }
            catch (NoSuchElementException)
            {
                throw;
            } 
        }

        //===========================================================================
        //                                BinaryTreeNode
        //===========================================================================

        private class BinaryTreeNode
        {

            private readonly Key key;
            private readonly Data data;
            private BinaryTreeNode left;
            private BinaryTreeNode right;
            private BinaryTreeNode parent;

            public BinaryTreeNode(Key key,Data data)
            {
                left = null;
                right = null;
                parent = null;
                this.key = key;
                this.data = data;
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
            public BinaryTreeNode Left
            {
                get { return left; }
                set { left = value; }
            }
            public BinaryTreeNode Right
            {
                get { return left; }
                set { left = value; }
            }
            public BinaryTreeNode Parent
            {
                get { return parent; }
                set { parent = value; }
            }


            //======================================
            //            Functionality
            //======================================



            ///<summary>
            /// Adds an element into the <c>BinaryTree</c>.<br/><br/>
            ///<b>throws</b> <c>ArgumentException</c> if an element with the same key already exists in the tree
            ///</summary>
            ///<exception cref="ArgumentException"></exception>
            public BinaryTreeNode Add(Key key, Data data)
            {
                //check if element already exists in the tree
                if (this.key.CompareTo(key) == 0)
                {
                    throw new ArgumentException("Element already exists in the tree");
                }

                //find a place to add it
                else if (this.key.CompareTo(key) > 0)
                {
                    //empty spot
                    if (left == null) 
                    { 
                        left = new BinaryTreeNode(key,data) 
                        {
                            parent = this
                        };
                        return left;
                    }

                    //pass it down
                    else left.Add(key,data);
                }
                else
                {
                    //empty spot
                    if (right == null)
                    {
                        right = new BinaryTreeNode(key,data)
                        {
                            parent = this
                        };
                        return right;
                    }

                    //pass it down
                    else return right.Add(key,data);
                }
            }

            ///<summary>Check if the <c>BinaryTree</c> contains a node with this key</summary>
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
            /// <b>Throws</b> <c>NoSuchElementException</c> if a node with this key does not exist in the <c>BinaryTree</c>
            /// </summary>
            /// <returns>BinaryTreeNode</returns>
            /// <exception cref="NoSuchElementException"></exception>
            public BinaryTreeNode Search(Key key)
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
            ///Removes a node from the <c>BinaryTree</c><br/><br/>
            ///
            ///<b>Warning:</b> Only works on a node that is in a tree.<br/>
            ///can throw unexpected exceptions if misused
            ///
            ///</summary>
            public void Remove()
            {
                // case 1: node has no children
                if (left == null & right == null)
                {
                    if (ThisNodeIsALeftSon())
                    {
                        parent.left = null;
                    }
                    else parent.right = null;
                }

                // case 2: node only has a right child
                else if (left == null)
                {
                    if (ThisNodeIsALeftSon())
                    {
                        parent.left = right;
                    }
                    else parent.right = right;
                }

                // case 3: node only has a left child
                else if (right == null)
                {
                    if (ThisNodeIsALeftSon())
                    {
                        parent.left = left;
                    }
                    else parent.right = left;
                }

                // case 4: node has 2 children
                else
                {
                    BinaryTreeNode successor = Successor();
                    successor.Remove();

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

            }

            /// <summary>
            /// Find the successor of a node <br/><br/>
            /// <b>Throws</b> <c>NoSuchElementException</c> if there is no successor
            /// </summary>
            /// <returns>BinaryTreeNode</returns>
            public BinaryTreeNode Successor()
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
                    BinaryTreeNode current = parent;
                    while (current != null && key.CompareTo(current.key) > 0)
                    {
                        current = current.parent;
                    }
                    if (current == null) throw new NoSuchElementException("No such element in the tree");
                    return current;
                }
            }

            /// <summary>
            /// Find the minimum in the <c>BinaryTree</c>
            /// </summary>
            /// <returns>BinaryTreeNode</returns>
            private BinaryTreeNode Minimum()
            {

                // go left until there is more left to go
                BinaryTreeNode current = this;
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
        }
    }
}
