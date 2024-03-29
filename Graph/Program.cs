﻿// See https://aka.ms/new-console-template for more information
using Graph;

Console.WriteLine("Hello, World!");

Dictionary<int, HashSet<int>> adjacencyList = new Dictionary<int, HashSet<int>>();

adjacencyList.Add(1, new HashSet<int>() { 2, 3, 6 });
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


Dictionary<int, HashSet<int>> adjacencyList2 = new Dictionary<int, HashSet<int>>();
adjacencyList2.Add(1, new HashSet<int>() { 2, 5 });
adjacencyList2.Add(2, new HashSet<int>() { 1, 2 });
adjacencyList2.Add(3, new HashSet<int>() { 2, 4 });
adjacencyList2.Add(4, new HashSet<int>() { 3, 5 });
adjacencyList2.Add(5, new HashSet<int>() { 1, 4 });

Console.WriteLine("Graph contains cycles : " + GraphExtensions<int>.IsCyclicDFS(adjacencyList2));

Console.WriteLine();
Console.WriteLine(GraphExtensions<int>.CheckBiPartite(adjacencyList));
Console.WriteLine(GraphExtensions<int>.CheckIsGraphBiPartite(adjacencyList));



Dictionary<int, HashSet<int>> directedAdjacencyList = new Dictionary<int, HashSet<int>>();
directedAdjacencyList.Add(1, new HashSet<int>() { 2 });
directedAdjacencyList.Add(2, new HashSet<int>() { 3 });
directedAdjacencyList.Add(3, new HashSet<int>() { 4, 6 });
directedAdjacencyList.Add(4, new HashSet<int>() { 5 });
directedAdjacencyList.Add(5, new HashSet<int>() { });
directedAdjacencyList.Add(6, new HashSet<int>() { 5 });
directedAdjacencyList.Add(7, new HashSet<int>() { 2, 8 });
directedAdjacencyList.Add(8, new HashSet<int>() { 9 });
directedAdjacencyList.Add(9, new HashSet<int>() { 7 });

Console.WriteLine();
Console.WriteLine("Does Graph has cycles: ");
Console.WriteLine(GraphExtensions<int>.IsCyclic(directedAdjacencyList));

Dictionary<int, HashSet<int>> directedAcyclicAdjacencyList = new Dictionary<int, HashSet<int>>();
directedAcyclicAdjacencyList.Add(0, new HashSet<int>() {  });
directedAcyclicAdjacencyList.Add(1, new HashSet<int>() {  });
directedAcyclicAdjacencyList.Add(2, new HashSet<int>() { 3 });
directedAcyclicAdjacencyList.Add(3, new HashSet<int>() { 1 });
directedAcyclicAdjacencyList.Add(4, new HashSet<int>() { 0, 1 });
directedAcyclicAdjacencyList.Add(5, new HashSet<int>() { 0, 2 });

Console.WriteLine();
Console.WriteLine("Printing Topo sort");
var topo = GraphExtensions<int>.GetTopoSort(directedAcyclicAdjacencyList);

foreach (var item in topo)
{
    Console.Write(item + "\t");
}

Console.WriteLine();
Console.WriteLine("Printing Topo sort");
var topo2 = GraphExtensions<int>.GetTopoSortBFS(directedAcyclicAdjacencyList);
foreach (var item in topo2)
{
    Console.Write(item + "\t");
}


Dictionary<int, HashSet<int>> adj5 = new Dictionary<int, HashSet<int>>();
adj5.Add(0, new HashSet<int>() { 1, 3 });
adj5.Add(1, new HashSet<int>() { 0, 2 });
adj5.Add(2, new HashSet<int>() { 1, 6 });
adj5.Add(3, new HashSet<int>() { 0, 4 });
adj5.Add(4, new HashSet<int>() { 3, 5 });
adj5.Add(5, new HashSet<int>() { 4, 6 });
adj5.Add(6, new HashSet<int>() { 2, 5, 7, 8 });
adj5.Add(7, new HashSet<int>() { 6, 8 });
adj5.Add(8, new HashSet<int>() { 6, 7 });

GraphExtensions<int>.GetShortestPath(adj5, 0);

Dictionary<int, HashSet<(int node, int weight)>> adj6 = new Dictionary<int, HashSet<(int node, int weight)>>();
adj6.Add(1, new HashSet<(int node, int weight)>() { (2, 2), (4, 1) });
adj6.Add(2, new HashSet<(int node, int weight)>() { (1, 2), (3, 4), (5, 5) });
adj6.Add(3, new HashSet<(int node, int weight)>() { (2, 4), (4, 3), (5, 1) });
adj6.Add(4, new HashSet<(int node, int weight)>() { (1, 1), (3, 3) });
adj6.Add(5, new HashSet<(int node, int weight)>() { (2, 5), (3, 1) });
GraphExtensions<int>.GetShortestPathInWeightedGraph(adj6, 1);
