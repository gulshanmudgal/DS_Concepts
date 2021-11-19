using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Node
    {
        internal int value;
        internal Node? left;
        internal Node? right;

        public Node(int nodeValue)
        {
            value = nodeValue;
            left = null;
            right = null;
        }
    }

    public class BinaryTree
    {
        public Node CreateBinaryTree()
        {
            Node rootNode = new Node(0);

            Node leftSubTreeRoot = new Node(10);
            leftSubTreeRoot.left = new Node(20);
            leftSubTreeRoot.right = new Node(21);

            Node rightSubTreeRoot = new Node(11);
            rightSubTreeRoot.left = new Node(22);
            rightSubTreeRoot.right = new Node(23);

            rootNode.left = leftSubTreeRoot;
            rootNode.right = rightSubTreeRoot;

            return rootNode;
        }

        #region Tree Traversal Algorithms
        /// <summary>
        /// Recursive InOrder Traversal
        /// Left -> Root -> Right
        /// </summary>
        /// <param name="root"></param>
        public void InOrder(Node root)
        {
            if (root != null)
            {
                InOrder(root.left);
                Console.Write(root.value + "\t");
                InOrder(root.right);
            }
        }

        /// <summary>
        /// Recursive PreOrder Traversal
        /// Root -> Left -> Right
        /// </summary>
        /// <param name="root"></param>
        public void PreOrder(Node root)
        {
            if(root != null)
            {
                Console.Write(root.value + "\t");
                PreOrder(root.left);
                PreOrder(root.right);
            }
        }

        /// <summary>
        /// Recursive Post Order Traversal
        /// Left -> Right -> Root
        /// </summary>
        /// <param name="root"></param>
        public void PostOrder(Node root)
        {
            if(root != null)
            {
                PostOrder(root.left);
                PostOrder(root.right);
                Console.Write(root.value + "\t");
            }
        }

        /// <summary>
        /// Iterative InOrder Traversal
        /// </summary>
        /// <param name="root"></param>
        public void InOrder2(Node root)
        {
            List<int> inOrder = new List<int>();
            Stack<Node> stack = new Stack<Node>();

            Node? node = root;

            while (true)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        break;
                    }

                    node = stack.Pop();
                    inOrder.Add(node.value);
                    node = node.right;
                }
            }

            foreach (var item in inOrder)
            {
                Console.Write(item + "\t");
            }
        }

        /// <summary>
        /// Iterative PreOrder Traversal
        /// </summary>
        /// <param name="root"></param>
        public void PreOrder2(Node root)
        {
            if(root == null)
            {
                return;
            }

            Stack<Node> nodes = new Stack<Node>();
            List<int> preOrder = new List<int>();

            nodes.Push(root);

            while (nodes.Count > 0)
            {
                root = nodes.Pop();
                preOrder.Add(root.value);

                if(root.right != null)
                {
                    nodes.Push(root.right);
                }

                if (root.left != null)
                {
                    nodes.Push(root.left);
                }
            }

            foreach (var item in preOrder)
            {
                Console.Write(item + "\t");
            }
        }

        /// <summary>
        /// Iterative Post Order Traversal using 2 Stacks
        /// </summary>
        /// <param name="root"></param>
        public void PostOrder2(Node root)
        {
            if(root == null)
            {
                return;
            }

            Stack<Node> stack1 = new Stack<Node>();
            Stack<Node> stack2 = new Stack<Node>();

            stack1.Push(root);

            while(stack1.Count != 0)
            {
                root = stack1.Pop();
                stack2.Push(root);

                if(root.left != null)
                {
                    stack1.Push(root.left);
                }

                if (root.right != null)
                {
                    stack1.Push(root.right);
                }
            }

            while(stack2.Count != 0)
            {
                Node node = stack2.Pop();

                Console.Write(node.value + "\t");
            }
        }

        /// <summary>
        /// Iterative Post Order Traversal using 1 Stacks
        /// </summary>
        /// <param name="root"></param>
        public void PostOrder3(Node root)
        {
            if(root == null)
            {
                return;
            }

            Node? currentNode = root;
            Stack<Node> nodeStack = new Stack<Node>();
            List<int> postOrder = new List<int>();

            while(currentNode != null || nodeStack.Count != 0)
            {
                if(currentNode != null)
                {
                    nodeStack.Push(currentNode);
                    currentNode = currentNode.left;
                }
                else
                {
                    Node? temp = nodeStack.Peek().right;

                    if(temp != null)
                    {
                        currentNode = temp;
                    }
                    else
                    {
                        temp = nodeStack.Pop();
                        postOrder.Add(temp.value);

                        while (nodeStack.Count != 0 && temp == nodeStack.Peek().right)
                        {
                            temp = nodeStack.Pop();
                            postOrder.Add(temp.value);
                        }
                    }
                }
            }

            foreach(var item in postOrder)
            {
                Console.Write(item + "\t");
            }
        }
        #endregion

        #region Tree Algorithms

        /// <summary>
        /// Functions returns the height of any binary tree.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int GetTreeHeight(Node root)
        {
            if(root == null)
                return 0;

            return 1 + Math.Max(GetTreeHeight(root.left), GetTreeHeight(root.right));
        }

        /// <summary>
        /// Check if the tree is Balanced.
        /// </summary>
        /// <param name="root"></param>
        /// <returns>
        /// If the tree is unbalanced -> -1 
        /// If the tree is balanced -> height of the tree
        /// </returns>
        public int CheckBalancedTree(Node root)
        {
            if(root == null)
            {
                return 0;
            }

            int leftHeight = CheckBalancedTree(root.left);
            if (leftHeight == -1)
            {
                return -1;
            }

            int rightHeight = CheckBalancedTree(root.right);
            if (rightHeight == -1)
            {
                return -1;
            }

            if(Math.Abs(leftHeight - rightHeight) > 1)
            {
                return -1;
            }

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        /// <summary>
        /// Calculates the Diameter of any binary tree
        /// Diameter of a tree is the maximum distance between two nodes, the path to those two nodes may or man not pass through the root node.
        /// </summary>
        /// <param name="root"></param>
        /// <returns>return the diameter of the tree</returns>
        public int GetTreeDiameter(Node root)
        {
            int diameter = 0;

            GetHeight(root, ref diameter);

            return diameter;
        }

        private int GetHeight(Node root, ref int diameter)
        {
            if (root == null)
                return 0;

            int lh = GetHeight(root.left, ref diameter);
            int rh = GetHeight(root.right, ref diameter);

            diameter = Math.Max((lh + rh), diameter);

            return Math.Max(lh, rh) + 1;
        }
        #endregion
    }
}
