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
            leftSubTreeRoot.right = new Node(22);

            Node rightSubTreeRoot = new Node(11);
            rightSubTreeRoot.left = new Node(21);
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

        /// <summary>
        /// Prints the binary tree level by level.
        /// </summary>
        /// <param name="root"></param>
        public void PrintLevelOrder(Node root)
        {
            if (root == null)
                return;

            Queue<Node> nodeQueue = new Queue<Node>();

            nodeQueue.Enqueue(root);

            while (nodeQueue.Count > 0)
            {
                int queueCount = nodeQueue.Count;

                for (int i = 0; i < queueCount; i++)
                {
                    Node currentNode = nodeQueue.Dequeue();

                    Console.Write(currentNode.value + "\t");

                    if(currentNode.left != null)
                    {
                        nodeQueue.Enqueue(currentNode.left);
                    }

                    if (currentNode.right != null)
                    {
                        nodeQueue.Enqueue(currentNode.right);
                    }
                }

                Console.WriteLine();
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
        /// Calculates the Diameter of any binary tree,
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

        public bool IsSameTree(Node? tree1Root, Node? tree2Root)
        {
            if(tree1Root == null || tree2Root == null)
            {
                return tree1Root == tree2Root;
            }

            return (tree1Root.value == tree2Root.value) && IsSameTree(tree1Root.left, tree2Root.left) && IsSameTree(tree1Root.right, tree2Root.right);
        }

        /// <summary>
        /// The function calculates the maximum path between any two nodes for a given tree.
        /// </summary>
        /// <returns></returns>
        public int GetMaxPathSum(Node? root, ref int maxVal)
        {
            if(root == null)
            {
                return 0;
            }

            int leftSum = Math.Max(0, GetMaxPathSum(root.left, ref maxVal));
            int rightSum = Math.Max(0, GetMaxPathSum(root.right, ref maxVal));

            maxVal = Math.Max(maxVal, (root.value + leftSum + rightSum));

            return root.value + Math.Max(leftSum, rightSum);
        }
        #endregion

        #region Boundary Traversals
        private void PrintList(List<int> listToPrint)
        {
            foreach(int item in listToPrint)
            {
                Console.Write(item + "\t");
            }
        }

        private bool IsLeaf(Node root)
        {
            return (root.left == null) && (root.right == null);
        }

        private void AddLeftBoundary(Node root, List<int> res)
        {
            Node? cur = root.left;

            while (cur != null)
            {
                if (IsLeaf(cur) == false)
                {
                    res.Add(cur.value);
                }
                    
                if (cur.left != null)
                {
                    cur = cur.left;
                }
                else
                {
                    cur = cur.right;
                }
            }
        }

        private void AddRightBoundary(Node root, List<int> res)
        {
            Node? currentNode = root.right;

            while (currentNode != null)
            {
                if(IsLeaf(currentNode) == false)
                {
                    res.Add(currentNode.value);
                }

                if(currentNode.right != null)
                {
                    currentNode = currentNode.right;
                }
                else
                {
                    currentNode = currentNode.left;
                }
            }
        }

        private void AddLeaves(Node root, List<int> res)
        {
            if(IsLeaf(root))
            {
                res.Add(root.value);
                return;
            }

            if(root.left != null)
            {
                AddLeaves(root.left, res);
            }

            if (root.right != null)
            {
                AddLeaves(root.right, res);
            }
        }

        /// <summary>
        /// Prints the boundary values of any tree in anti clockwise direction
        /// </summary>
        /// <param name="root"></param>
        public void PrintBoundary(Node root)
        {
            if(root == null)
            {
                return;
            }

            List<int> boundaryValues = new List<int>();
            boundaryValues.Add(root.value);

            if(IsLeaf(root))
            {
                PrintList(boundaryValues);
                return;
            }

            AddLeftBoundary(root, boundaryValues);
            AddLeaves(root, boundaryValues);
            AddRightBoundary(root, boundaryValues);

            PrintList(boundaryValues);
        }

        public void PrintVertical(Node root)
        {

        }

        /// <summary>
        /// Function calculates the maximum and minimum distances from the root and initializes the value
        /// </summary>
        /// <param name="root"></param>
        /// <param name="minDistance"></param>
        /// <param name="maxDistance"></param>
        /// <param name="horizontalDistance"></param>
        private void SetDistances(Node node, ref int minDistance, ref int maxDistance, int horizontalDistance)
        {
            if(node == null)
            {
                return;
            }

            if(horizontalDistance < minDistance)
            {
                minDistance = horizontalDistance;
            }

            if(horizontalDistance > maxDistance)
            {
                maxDistance = horizontalDistance;
            }

            SetDistances(node.left, ref minDistance, ref maxDistance, (horizontalDistance - 1));
            SetDistances(node.right, ref minDistance, ref maxDistance, (horizontalDistance + 1));
        }

        /// <summary>
        /// This functions return the vertical order traversal in unsorted manner
        /// </summary>
        /// <param name="node"></param>
        /// <param name="lineNo"></param>
        /// <param name="horizontalDistance"></param>
        /// <param name="_nodes"></param>
        /// <returns></returns>
        private IList<int> GetNodesByLine(Node node, int lineNo, int horizontalDistance, IList<int> _nodes)
        {
            if(node == null)
            {
                return _nodes;
            }

            if(lineNo == horizontalDistance)
            {
                _nodes.Add(node.value);
            }

            if(node.left != null)
            {
                GetNodesByLine(node.left, lineNo, horizontalDistance - 1, _nodes);
            }
            
            if(node.right != null)
            {
                GetNodesByLine(node.right, lineNo, horizontalDistance + 1, _nodes);
            }

            return _nodes;
        }

        /// <summary>
        /// This functions return the vertical order traversal in sorted manner
        /// </summary>
        /// <param name="node"></param>
        /// <param name="lineNo"></param>
        /// <param name="horizontalDistance"></param>
        /// <param name="_nodes"></param>
        /// <returns></returns>
        private IList<int> GetNodesByLine2(Node node, int horizontalDistance, IList<int> _nodes)
        {
            if (node == null)
            {
                return _nodes;
            }

            Queue<(Node node, int horizontalDistance, int verticalDistance)> levelNodeQueue = new Queue<(Node, int horizontalDistance, int verticalDistance)>();
            
            levelNodeQueue.Enqueue((node, 0, 0));

            while (levelNodeQueue.Count > 0)
            {
                int nodeCount = levelNodeQueue.Count;
                List<int> levelNodes = new List<int>();

                for (int i = 0; i < nodeCount; i++)
                {
                    var nodeToProcess = levelNodeQueue.Dequeue();

                    if(nodeToProcess.horizontalDistance == horizontalDistance)
                    {
                        levelNodes.Add(nodeToProcess.node.value);
                    }

                    if (nodeToProcess.node.left != null)
                    {
                        levelNodeQueue.Enqueue((nodeToProcess.node.left, (nodeToProcess.horizontalDistance - 1), (nodeToProcess.verticalDistance + 1)));
                    }

                    if (nodeToProcess.node.right != null)
                    {
                        levelNodeQueue.Enqueue((nodeToProcess.node.right, (nodeToProcess.horizontalDistance + 1), (nodeToProcess.verticalDistance + 1)));
                    }
                }

                levelNodes.Sort();

                foreach (var item in levelNodes)
                {
                    _nodes.Add(item);
                }

                // levelNodes.Clear();
            }

            return _nodes;
        }

        /// <summary>
        /// This is by brute force.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> VerticalTraversal(Node root)
        {
            IList<IList<int>> nodesList = new List<IList<int>>();

            if (root == null)
                return nodesList;

            int minDistance = 0;
            int maxDistance = 0;

            SetDistances(root, ref minDistance, ref maxDistance, 0);

            for (int i = minDistance; i <= maxDistance; i++)
            {
                List<int> _nodes = new List<int>();
                // var nodes = GetNodesByLine(root, i, 0, _nodes) as List<int> as List<int>;
                var nodes = GetNodesByLine2(root, i, _nodes) as List<int> as List<int>;

                if (nodes.Count > 0)
                {
                    nodesList.Add(nodes);
                }
            }

            return nodesList;
        }

        public IList<IList<int>>? VerticalTraversal2(Node root)
        {
            SortedDictionary<int, List<int>>? nodesList = new SortedDictionary<int,List<int>>();

            if(root == null)
            {
                return nodesList as IList<IList<int>>;
            }

            Queue<(Node node, int horizontalDistance, int verticalDistance)> levelNodeQueue = new Queue<(Node, int horizontalDistance, int verticalDistance)>();
            levelNodeQueue.Enqueue((root, 0, 0));

            while (levelNodeQueue.Count > 0)
            {
                int nodeCount = levelNodeQueue.Count;
                List<int> levelNodes = new List<int>();

                for (int i = 0; i < nodeCount; i++)
                {
                    var nodeToProcess = levelNodeQueue.Dequeue();

                    if(nodesList.ContainsKey(nodeToProcess.horizontalDistance))
                    {
                        nodesList[nodeToProcess.horizontalDistance].Add(nodeToProcess.node.value);
                    }
                    else
                    {
                        nodesList.Add(nodeToProcess.horizontalDistance, new List<int>()
                        {
                            nodeToProcess.node.value
                        });
                    }
                    

                    if (nodeToProcess.node.left != null)
                    {
                        levelNodeQueue.Enqueue((nodeToProcess.node.left, (nodeToProcess.horizontalDistance - 1), (nodeToProcess.verticalDistance + 1)));
                    }

                    if (nodeToProcess.node.right != null)
                    {
                        levelNodeQueue.Enqueue((nodeToProcess.node.right, (nodeToProcess.horizontalDistance + 1), (nodeToProcess.verticalDistance + 1)));
                    }
                }

                //levelNodes.Sort();

                //foreach (var item in levelNodes)
                //{
                //    _nodes.Add(item);
                //}

                // levelNodes.Clear();
            }

            return nodesList as IList<IList<int>>; ;
        }

        #endregion

        #region Print Different Views
        /// <summary>
        /// Function will return a dictionary with node values of all visible nodes if the tree is looked from the top
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public SortedDictionary<int, int> GetTopView(Node root)
        {
            SortedDictionary<int, int> topViewNodes = new SortedDictionary<int, int>();

            if(root == null)
            {
                return topViewNodes;
            }

            Queue<(Node node, int horizontalDistance)> nodeQueue = new Queue<(Node node, int horizontalDistance)>();
            nodeQueue.Enqueue((root, 0));

            while (nodeQueue.Count > 0)
            {
                int nodeCount = nodeQueue.Count;

                for (int i = 0; i < nodeCount; i++)
                {
                    var nodeToProcess = nodeQueue.Dequeue();
                    if(!topViewNodes.ContainsKey(nodeToProcess.horizontalDistance))
                    {
                        topViewNodes.Add(nodeToProcess.horizontalDistance, nodeToProcess.node.value);
                    }

                    if(nodeToProcess.node.left != null)
                    {
                        nodeQueue.Enqueue((nodeToProcess.node.left, nodeToProcess.horizontalDistance - 1));
                    }

                    if (nodeToProcess.node.right != null)
                    {
                        nodeQueue.Enqueue((nodeToProcess.node.right, nodeToProcess.horizontalDistance + 1));
                    }
                }
            }

            return topViewNodes;
        }

        public SortedDictionary<int, int> GetBottomView(Node root)
        {
            SortedDictionary<int, int> bottomView = new SortedDictionary<int, int>();

            if(root == null)
            {
                return bottomView;
            }

            Queue<(Node node, int horizontalDistance)> nodeQueue = new Queue<(Node node, int horizontalDistance)>();

            nodeQueue.Enqueue((root, 0));

            while (nodeQueue.Count > 0)
            {
                int nodeCount = nodeQueue.Count;

                for(int i = 0; i < nodeCount; i++)
                {
                    var nodeToProcess = nodeQueue.Dequeue();

                    if (bottomView.ContainsKey(nodeToProcess.horizontalDistance))
                    {
                        bottomView[nodeToProcess.horizontalDistance] = nodeToProcess.node.value;
                    }
                    else
                    {
                        bottomView.Add(nodeToProcess.horizontalDistance, nodeToProcess.node.value);
                    }

                    if(nodeToProcess.node.left != null)
                    {
                        nodeQueue.Enqueue((nodeToProcess.node.left, nodeToProcess.horizontalDistance - 1));
                    }

                    if (nodeToProcess.node.right != null)
                    {
                        nodeQueue.Enqueue((nodeToProcess.node.right, nodeToProcess.horizontalDistance + 1));
                    }
                }
            }

            return bottomView;
        }

        public IList<int> RightSideView(Node root)
        {
            List<int> rightView = new List<int>();

            GetRightSideView(root, 0, rightView);

            return rightView;
        }

        private void GetRightSideView(Node root, int level, List<int> rightView)
        {
            if (root == null)
            {
                return;
            }

            if (rightView.Count == level)
            {
                rightView.Add(root.value);
            }

            GetRightSideView(root.right, level + 1, rightView);
            GetRightSideView(root.left, level + 1, rightView);
        }
        #endregion
    }
}
