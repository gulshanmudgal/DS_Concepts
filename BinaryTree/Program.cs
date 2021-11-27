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

// Check if two tree are same(value wise)
Console.WriteLine(helper.IsSameTree(tree, null));

// Print Max Path sum for a given tree
int maxPathSum = Int32.MinValue;
helper.GetMaxPathSum(tree, ref maxPathSum);
Console.WriteLine(maxPathSum);

// Print Tree Boundary nodes
helper.PrintBoundary(tree);

// Vertical tree traversal
var nodes = helper.VerticalTraversal2(tree);
Console.WriteLine(); Console.WriteLine();
if(nodes != null)
{
    foreach (var level in nodes)
    {
        foreach (var node in level)
        {
            Console.Write(node + "\t");
        }

        Console.WriteLine();
    }
}

Console.WriteLine(); Console.WriteLine();

// Printing Top View of the tree
var topView = helper.GetTopView(tree);
Console.WriteLine("Printing Top View");
if(topView != null)
{
    foreach (var item in topView)
    {
        Console.Write(item.Value + "\t");
    }
}

Console.WriteLine(); Console.WriteLine();
// Printing Top View of the tree
var bottomView = helper.GetBottomView(tree);
Console.WriteLine("Printing Top View");
if (bottomView != null)
{
    foreach (var item in bottomView)
    {
        Console.Write(item.Value + "\t");
    }
}
