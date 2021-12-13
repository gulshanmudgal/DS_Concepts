// See https://aka.ms/new-console-template for more information
using Graph;

Console.WriteLine("Hello, World!");

Dictionary<int, HashSet<int>> adjacencyList = new Dictionary<int, HashSet<int>>();

adjacencyList.Add(1, new HashSet<int>() { 2, 3, 6});
adjacencyList.Add(2, new HashSet<int>() { 1, 5, 6 });
adjacencyList.Add(3, new HashSet<int>() { 1, 6 });
adjacencyList.Add(4, new HashSet<int>() { 7 });
adjacencyList.Add(5, new HashSet<int>() { 2 });
adjacencyList.Add(6, new HashSet<int>() { 1, 2, 3 });
adjacencyList.Add(7, new HashSet<int>() { 4 });

var bfs = GraphExtensions<int>.BFSOfGraph(adjacencyList, 1);

foreach (var item in bfs)
{
    Console.Write(item + "\t");
}
Console.WriteLine();
Console.WriteLine();

var dfs = GraphExtensions<int>.DFSOfGraph(adjacencyList);

foreach (var item in dfs)
{
    Console.Write(item + "\t");
}
Console.WriteLine();
Console.WriteLine("Graph contains cycles : " +GraphExtensions<int>.IsCyclic(adjacencyList));