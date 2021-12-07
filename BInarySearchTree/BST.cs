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
    }
}
