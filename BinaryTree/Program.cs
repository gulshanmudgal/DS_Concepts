// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

BinaryTree.BinaryTree helper = new BinaryTree.BinaryTree();

var tree = helper.CreateBinaryTree();

// In Order Traversal
helper.InOrder(tree);
Console.WriteLine();
helper.InOrder2(tree);

Console.WriteLine();

// Pre Order Traversal
helper.PreOrder(tree);
Console.WriteLine();
helper.PreOrder2(tree);

Console.WriteLine();

// Post Order Traversal
helper.PostOrder(tree);
Console.WriteLine();
helper.PostOrder2(tree);
Console.WriteLine();
helper.PostOrder3(tree);