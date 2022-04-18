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
    /// This class implements a generic binary tree that that is ordered with CompareTo()<br/>
    /// Therefore, it can only work with objects that are <c>IComparable</c><br/>
    /// <b>The class does not support duplicate elements</b>
    /// <code>Supported operations:</code>
    /// <list type="bullet">Add()</list>
    /// <list type="bullet">Remove()</list>
    /// <list type="bullet">Contains()</list>
    /// <list type="bullet">Search() - behavior is likely going to change in the near future</list>
    /// <list type="bullet">IsEmpty()</list>
    /// <list type="bullet">ToStringInOrder()</list>
    /// <list type="bullet">ToStringPreOrder()</list>
    /// </summary>
    public class BinaryTree<T> where T : IComparable
    {
        private BinaryTreeNode root;

        public BinaryTree()
        {
            root = null;
        }

        ///<summary>
        ///Adds an element into the <c>BinaryTree</c>.<br/><br/>
        ///<b>throws</b> <c>ArgumentException</c> if the element already exists in the tree
        ///</summary>
        public void Add(T element)
        {
            // if tree is empty, add to the root
            if (root == null)
            {
                root = new BinaryTreeNode(element);
            }
            //otherwise pass it down
            else
            {
                try
                {
                    root.Add(element);
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Element already exists");
                }
            }

        }

        ///<summary>Removes an element from the <c>BinaryTree</c></summary>
        public void Remove(T element)
        {
            //if the root is the target for removal
            if (root.GetElement().CompareTo(element) == 0)
            {
                //case 1: root has no children
                if (root.GetLeft() == null & root.GetRight() == null)
                {
                    root = null;
                }

                //case 2: root has only a right child
                else if (root.GetLeft() == null)
                {
                    root = root.GetRight();
                    root.SetParent(null);
                }

                //case 3: root has only a left child
                else if (root.GetRight() == null)
                {
                    root = root.GetLeft();
                    root.SetParent(null);
                }

                //case 4: root has 2 children
                else
                {

                    BinaryTreeNode successor = root.Successor();
                    successor.Remove();

                    // copy children of old root
                    if (root.GetLeft() != successor) successor.SetLeft(root.GetLeft());
                    if (root.GetRight() != successor) successor.SetRight(root.GetRight());

                    // set children's parent to successor
                    if (root.GetLeft() != null) root.GetLeft().SetParent(successor);
                    if (root.GetRight() != null) root.GetRight().SetParent(successor);

                    // make the swap
                    root = successor;
                    root.SetParent(null); 

             
                }
            }
            // root isn't the target for removal -> pass it down
            else root.Search(element).Remove();
        }

        ///<summary>Check if the <c>BinaryTree</c> contains an element</summary>
        ///<returns><c>true</c> if the element exists in the tree and <c>false</c> otherwise</returns>
        public Boolean Contains(T element)
        {
            return root.Contains(element);
        }

        ///<summary>Check if the <c>BinaryTree</c> is empty</summary>
        ///<returns><c>true</c> if the tree is empty and <c>false</c> otherwise</returns>
        public Boolean IsEmpty()
        {
            return root == null;
        }

        public BinaryTreeNode Search(T element) 
        { 
            return root.Search(element);
        }

        ///<summary>A string of all the elements in the tree in "in order"</summary>
        ///<returns><c>string</c></returns>
        public string ToStringInOrder()
        {
            return root.ToStringInOrder();
        }

        ///<summary>A string of all the elements in the tree in "pre order"</summary>
        ///<returns><c>string</c></returns>
        public string ToStringPreOrder() 
        {
            return root.ToStringPreOrder();
        }



                        //===========================================================================
                        //                                BinaryTreeNode
                        //===========================================================================

        public class BinaryTreeNode
        {

            private T element;
            private BinaryTreeNode left;
            private BinaryTreeNode right;
            private BinaryTreeNode parent;

            public BinaryTreeNode(T element)
            {
                left = null;
                right = null;
                parent = null;
                this.element = element;
            }
                                        //======================================
                                        //            Getters / Setters
                                        //======================================


            public T GetElement() { return element; }
            public BinaryTreeNode GetLeft() { return left; }
            public BinaryTreeNode GetRight() { return right; }
            public void SetParent(BinaryTreeNode parent) { this.parent = parent; }
            public void SetLeft(BinaryTreeNode left) { this.left = left; }
            public void SetRight(BinaryTreeNode right) { this.right = right; }
 



                                        //======================================
                                        //            Functionality
                                        //======================================



            ///<summary>
            ///Adds an element into the <c>BinaryTree</c>.<br/><br/>
            ///<b>throws</b> <c>ArgumentException</c> if the element already exists in the tree
            ///</summary>
            public void Add(T element)
            {
                //check if element already exists in the tree
                if (this.element.CompareTo(element) == 0)
                {
                    throw new ArgumentException("Element already exists");
                }

                //find a place to add it
                else if (this.element.CompareTo(element) > 0)
                {
                    //empty spot
                    if (left == null) 
                    { 
                        left = new BinaryTreeNode(element);
                        left.parent = this;
                    }

                    //pass it down
                    else left.Add(element);
                }
                else
                {
                    //empty spot
                    if (right == null)
                    {
                        right = new BinaryTreeNode(element);
                        right.parent = this;
                    }

                    //pass it down
                    else right.Add(element);
                }
            }

            ///<summary>Check if the <c>BinaryTree</c> contains an element</summary>
            ///<returns><c>true</c> if the element exists in the tree and <c>false</c> otherwise</returns>
            public Boolean Contains(T element)
            {
                return Search(element) != null;
            }

            /// <summary>
            /// search for a node with the specified element
            /// </summary>
            /// <param name="element"></param>
            /// <returns>BinaryTreeNode</returns>
            public BinaryTreeNode Search(T element)
            {
                //check if the current node is the target
                if (this.element.CompareTo(element) == 0)
                {
                    return this;
                }

                //binary search for it
                else if (left != null && this.element.CompareTo(element) > 0)
                {
                    return left.Search(element);
                }
                else if (right != null)
                {
                    return right.Search(element);
                }

                //can't find it
                else return null;
            }

            ///<summary>Removes an element from the <c>BinaryTree</c></summary>
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
                        parent.left = this.right;
                    }
                    else parent.right = this.right;
                }

                // case 3: node only has a left child
                else if (right == null)
                {
                    if (ThisNodeIsALeftSon())
                    {
                        parent.left = this.left;
                    }
                    else parent.right = this.left;
                }

                // case 4: node has 2 children
                else
                {
                    BinaryTreeNode successor = this.Successor();
                    successor.Remove();
                    
                    // make the successor the child of the old node's parent
                    if (ThisNodeIsALeftSon()) parent.left = successor;
                    else if (ThisNodeIsARightSon()) parent.right = successor;

                    // copy children of old node
                    if (successor != this.left) successor.left = this.left;
                    if (successor != this.right) successor.right = this.right;

                    // set children's parent to successor
                    if (left != null) left.parent = successor;
                    if (right != null) right.parent = successor;

                    //copy parent of old node
                    successor.parent = this.parent;

                    
                }

            }

            /// <summary>
            /// Find the successor of a node, if it exists
            /// </summary>
            /// <returns>BinaryTreeNode if a successor is found
            /// <c>null</c>  otherwise</returns>
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
                    BinaryTreeNode current = this.parent;
                    while (current != null && this.element.CompareTo(current.element) > 0)
                    {
                        current = current.parent;
                    }
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

            ///<summary>A string of all the elements in the tree in "in order"</summary>
            ///<returns><c>string</c></returns>
            public string ToStringInOrder()
            {
                return ToStringInOrder("");
            }
            private string ToStringInOrder(string output)
            {       
                if(left != null)
                 output = left.ToStringInOrder(output);

                output += element.ToString() + " ";

                if (right != null)
                 output = right.ToStringInOrder(output);
                return output;
            }

            ///<summary>A string of all the elements in the tree in "pre order"</summary>
            ///<returns><c>string</c></returns>
            public string ToStringPreOrder()
            {
                return ToStringPreOrder("");
            }
            private string ToStringPreOrder(string output)
            {
                output += element.ToString() + " ";
                if (left != null)
                    output = left.ToStringPreOrder(output);
                if (right != null)
                    output = right.ToStringPreOrder(output);
                return output;
            }
            private Boolean ThisNodeIsARightSon() 
            {
                if (parent != null) return parent.right == this;
                
                return false;
            }
            private Boolean ThisNodeIsALeftSon()
            {
                if (parent != null) return parent.left == this;

                return false;
            }
        }
    }
}
