// See https://aka.ms/new-console-template for more information
using BInarySearchTree;

Console.WriteLine("Hello, World!");

Node root = new Node(7);
root.left = new Node(3);
root.right = new Node(15);
root.right.right = new Node(20);
root.right.left = new Node(15);

Node root1 = new Node(1);
root1.left = new Node(3); 
root1.left.right = new Node(2);
BST.RecoverTree(root1);


Node root2 = new Node(1);
root2.left = new Node(4);
root2.right = new Node(4);
root2.left.left = new Node(6);
root2.left.right = new Node(8);

Node root3 = new Node(7);
root3.left = new Node(4);
root3.right = new Node(6);
root3.right.right = new Node(9);

Console.WriteLine("Larget BST SIZE");
Console.WriteLine(BST.LargestBst(root1));