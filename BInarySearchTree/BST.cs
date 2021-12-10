using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BInarySearchTree
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

    public class BST
    {
        public Node Insert(Node? root, int val)
        {
            if(root == null)
            {
                return new Node(val);
            }

            Node currentNode = root;

            while (true)
            {
                if(currentNode.value < val)
                {
                    if(currentNode.right != null)
                    {
                        currentNode = currentNode.right;
                    }
                    else
                    {
                        currentNode.right = new Node(val);
                        break;
                    }
                }
                else
                {
                    if(currentNode.left != null)
                    {
                        currentNode = currentNode.left;
                    }
                    else
                    {
                        currentNode.left = new Node(val);
                        break;
                    }
                }
            }

            return root;
        }

        public Node? DeleteNode(Node? root, int key)
        {
            if(root == null)
            {
                return null;
            }

            while (root != null)
            {
                if(root.value > key)
                {
                    if(root.left != null && root.left.value == key)
                    {
                        root.left = DeleteHelper(root.left);
                        break;
                    }
                    else
                    {
                        root = root.left;
                    }
                }
                else
                {
                    if(root.right != null && root.right.value == key)
                    {
                        root.right = DeleteHelper(root.right);
                        break;
                    }
                    else
                    {
                        root = root.right;
                    }
                }
            }

            return root;
        }

        private Node? DeleteHelper(Node root)
        {
            if(root.left == null)
            {
                return root.right;
            }

            if(root.right == null)
            {
                return root.left;
            }

            Node rightChild = root.right;
            Node nodeToAttachAfter = FindLastRight(root.left);

            nodeToAttachAfter.right = rightChild;

            return root.left;
        }

        private Node FindLastRight(Node root)
        {
            if(root.right == null)
            {
                return root;
            }

            return FindLastRight(root.right);
        }

        public Node? SearchBST(Node? root, int val)
        {
            while (root != null && root.value != val)
            {
                root = val < root.value ? root.left : root.right;
            }

            return root;
        }

        public int FindCeil(Node? root, int val)
        {
            int ceil = Int32.MinValue;

            while(root != null)
            {
                if(root.value == val)
                {
                    ceil = val;
                    return ceil;
                }

                if(val > root.value)
                {
                    root = root.right;
                }
                else
                {
                    ceil = root.value;
                    root = root.left;
                }
            }

            return ceil;
        }

        public int FindFloor(Node? root, int key)
        {
            int floor = Int32.MinValue;

            while (root != null)
            {
                if(root.value == key)
                {
                    floor = key;
                    return floor;
                }

                if(key < root.value)
                {
                    root = root.left;
                }
                else
                {
                    floor = root.value;
                    root = root.right;
                }
            }

            return floor;
        }

        public int? KthSmallest(Node root, int k)
        {
            if(root == null)
            {
                return null;
            }

            int counter = 0;

            Stack<Node> inOrderNodeStack = new Stack<Node>();
            Node? nodeToTraverse = root;

            while(true)
            {
                if(nodeToTraverse != null)
                {
                    inOrderNodeStack.Push(nodeToTraverse);
                    nodeToTraverse = nodeToTraverse.left;
                }
                else
                {
                    var node = inOrderNodeStack.Pop();
                    counter++;

                    if(counter == k)
                    {
                        return node.value;
                    }

                    nodeToTraverse = node.right;
                }
            }

            // return null;
        }

        public bool IsValidBST(Node root)
        {
            return IsValidBST(root, Int32.MinValue, Int32.MaxValue);
        }

        private bool IsValidBST(Node root, int minRange, int maxRange)
        {
            if (root == null)
            {
                return true;
            }

            if(root.value < minRange || root.value > maxRange)
            {
                return false;
            }

            return IsValidBST(root.left, minRange, root.value) && IsValidBST(root.right, root.value, maxRange);
        }

        public Node? LowestCommonAncestor(Node root, Node p, Node q)
        {
            if (root == null)
            {
                return null;
            }
            int curr = root.value;

            if (curr < p.value && curr < q.value)
            {
                return LowestCommonAncestor(root.right, p, q);
            }

            if (curr > p.value && curr > q.value)
            {
                return LowestCommonAncestor(root.left, p, q);
            }

            return root;
        }

        public Node? InOrderSuccessor(Node? root, Node? nodeForSearch)
        {
            if (root == null || nodeForSearch == null)
            {
                return null;
            }

            Node? successor = null;

            while(root != null)
            {
                if(nodeForSearch.value >= root.value)
                {
                    root = root.right;
                }
                else
                {
                    successor = root;
                    root = root.left;
                }
            }

            return successor;
        }

        public Node? BstFromPreorder(int[] preorder)
        {
            int index = 0;

            return BstFromPreorder(preorder, Int32.MaxValue, ref index);
        }

        private Node? BstFromPreorder(int[] preOrder, int bound, ref int index)
        {
            if(index == preOrder.Length || preOrder[index] > bound)
            {
                return null;
            }

            Node root = new Node(preOrder[index]);
            index++;

            root.left = BstFromPreorder(preOrder, root.value, ref index);
            root.right = BstFromPreorder(preOrder, bound, ref index);

            return root;
        }

        static Node? first = null;
        static Node? middle = null;
        static Node? last = null;
        static Node? prev = new Node(Int32.MinValue);

        public static void RecoverTree(Node root)
        {
            InOrder(root);

            if(last == null && first != null && middle != null)
            {
                int temp = first.value;
                first.value = middle.value;
                middle.value = first.value;
            }
            else if(last != null && first != null)
            {
                int temp = last.value;
                last.value = first.value;
                first.value = last.value;
            }
        }

        private static void InOrder(Node root)
        {
            if(root == null)
            {
                return;
            }

            InOrder(root.left);

            if(prev != null && root.value < prev.value)
            {
                if(first == null)
                {
                    first = prev;
                    middle = root;
                }
                else
                {
                    last = root;
                }
            }

            prev = root;
            InOrder(root.right);
        }

        public static int LargestBst(Node root)
        {
            return LargestBSTHelper(root).size;
        }

        public static NodeVal LargestBSTHelper(Node root)
        {
            if(root == null)
            {
                return new NodeVal(Int32.MaxValue, Int32.MinValue, 0);
            }

            NodeVal left = LargestBSTHelper(root.left);
            NodeVal right = LargestBSTHelper(root.right);

            if(left.maxVal < root.value && right.minVal > root.value)
            {
                // This Node is a valid BST
                return new NodeVal(Math.Min(left.minVal, root.value), Math.Max(root.value, right.maxVal), (1 + left.size + right.size));
            }

            return new NodeVal(Int32.MinValue, Int32.MaxValue, Math.Max(left.size, right.size));
        }
    }

    public class NodeVal
    {
        public int minVal;
        public int maxVal;
        public int size;

        public NodeVal(int minimum, int maximum, int size)
        {
            this.minVal = minimum;
            this.maxVal = maximum;
            this.size = size;
        }
    }
}
