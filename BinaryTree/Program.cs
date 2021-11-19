// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

BinaryTree.BinaryTree helper = new BinaryTree.BinaryTree();

var tree = helper.CreateBinaryTree();

// In Order Traversal
helper.InOrder(tree);
Console.WriteLine();
helper.InOrder2(tree);

Console.WriteLine();
Console.WriteLine();

// Pre Order Traversal
helper.PreOrder(tree);
Console.WriteLine();
helper.PreOrder2(tree);

Console.WriteLine();
Console.WriteLine();

// Post Order Traversal
helper.PostOrder(tree);
Console.WriteLine();
helper.PostOrder2(tree);
Console.WriteLine();
helper.PostOrder3(tree);
Console.WriteLine();

Console.WriteLine();
// print level order traversal
helper.PrintLevelOrder(tree);
Console.WriteLine();
Console.WriteLine();

// Get height of a binary tree
Console.WriteLine(helper.GetTreeHeight(tree));

// Check if the tree is balanced
Console.WriteLine(helper.CheckBalancedTree(tree)  == 1 ? false : true);

// Calculate the diameter of a binary tree
Console.WriteLine(helper.GetTreeDiameter(tree));