using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    internal class Graph<T>
    {
        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

        public Graph()
        {
        }

        /// <summary>
        /// Constructor to create a unweighted graph.
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="edges"></param>
        public Graph(IEnumerable<T> vertices, IEnumerable<(T source, T destination)> edges)
        {
            foreach (var vertex in vertices)
            {
                AddVertex(vertex);
            }

            foreach (var edge in edges)
            {
                AddEdge(edge.source, edge.destination);
            }
        }

        /// <summary>
        /// Method to add a vertex.
        /// </summary>
        /// <param name="vertexKey"></param>
        private void AddVertex(T vertexKey)
        {
            if(!AdjacencyList.ContainsKey(vertexKey))
            {
                AdjacencyList[vertexKey] = new HashSet<T>();
            }
        }

        /// <summary>
        /// Method to add an edge.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        private void AddEdge(T source, T destination)
        {
            AdjacencyList[source].Add(destination);
        }
    }

    internal class WeightedGraph<T>
    {
        public Dictionary<T, HashSet<(T node, int weight)>> AdjacencyList { get; } = new Dictionary<T, HashSet<(T node, int weight)>>();

        public WeightedGraph()
        {
        }

        public WeightedGraph(IEnumerable<T> vertices, IEnumerable<(T source, T destination, int weight)> edges)
        {
            foreach (var vertex in vertices)
            {
                AddVertex(vertex);
            }

            foreach (var edge in edges)
            {
                AddEdge(edge.source, edge.destination, edge.weight);
            }
        }

        /// <summary>
        /// Method to add a vertex.
        /// </summary>
        /// <param name="vertexKey"></param>
        private void AddVertex(T vertexKey)
        {
            if (!AdjacencyList.ContainsKey(vertexKey))
            {
                AdjacencyList[vertexKey] = new HashSet<(T node, int weight)>();
            }
        }

        /// <summary>
        /// Method to add an edge.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="weight"></param>
        private void AddEdge(T source, T destination, int weight)
        {
            AdjacencyList[source].Add((destination, weight));
        }
    }

    internal static class GraphExtensions<T>
    {
        public static List<T> BFSOfGraph(Dictionary<T, HashSet<T>> AdjacencyList, T start)
        {
            HashSet<T> visited = new HashSet<T>();

            if (!AdjacencyList.ContainsKey(start))
            {
                return visited.ToList();
            }

            foreach (var item in AdjacencyList)
            {
                if(!visited.Contains(item.Key))
                {
                    Queue<T> neighborVertexQueue = new Queue<T>();
                    neighborVertexQueue.Enqueue(item.Key);

                    while (neighborVertexQueue.Count > 0)
                    {
                        var vertexToProcess = neighborVertexQueue.Dequeue();

                        if (!visited.Contains(vertexToProcess))
                        {
                            visited.Add(vertexToProcess);

                            foreach (var vertex in AdjacencyList[vertexToProcess])
                            {
                                neighborVertexQueue.Enqueue(vertex);
                            }
                        }
                    }
                }
            }

            return visited.ToList();
        }

        public static List<T> DFSOfGraph(Dictionary<T, HashSet<T>> AdjacencyList)
        {
            HashSet<T> visited = new HashSet<T>();

            foreach(var keyValPair in AdjacencyList)
            {
                DFS(AdjacencyList, visited, keyValPair.Key);
            }

            return visited.ToList();
        }

        private static void DFS(Dictionary<T, HashSet<T>> AdjacencyList, HashSet<T> visited, T node)
        {
            if(!visited.Contains(node))
            {
                visited.Add(node);

                foreach(var item in AdjacencyList[node])
                {
                    DFS(AdjacencyList, visited, item);
                }
            }
        }

        /// <summary>
        /// Driver code for Cycle Detection using DFS Algorithm.
        /// </summary>
        /// <param name="AdjacencyList"></param>
        /// <returns></returns>
        public static bool IsCyclicDFS(Dictionary<T, HashSet<T>> AdjacencyList)
        {
            HashSet<T> visitedNodes = new HashSet<T>();

            foreach (var vertex in AdjacencyList)
            {
                if(!visitedNodes.Contains(vertex.Key))
                {
                    if(DetectCycle(AdjacencyList, vertex.Key, default(T), visitedNodes))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Detects cycle in a graph using DFS algorithm.
        /// </summary>
        /// <returns></returns>
        private static bool DetectCycle(Dictionary<T, HashSet<T>> AdjacencyList, T startVertex, T parentVertex, HashSet<T> visitedNodes)
        {
            visitedNodes.Add(startVertex);

            foreach(var neighbor in AdjacencyList[startVertex])
            {
                if(!visitedNodes.Contains(neighbor))
                {
                    if (DetectCycle(AdjacencyList, neighbor, startVertex, visitedNodes))
                    {
                        return true;
                    }
                }
                else
                {
                    if(!neighbor.Equals(parentVertex))
                    {
                        return true;
                    }
                }
                
            }

            return false;
        }

        public static bool IsCyclicBFS(Dictionary<T, HashSet<T>> AdjacencyList)
        {
            HashSet<T> visitedNodes = new HashSet<T>();

            foreach (var vertex in AdjacencyList)
            {
                if(!visitedNodes.Contains(vertex.Key))
                {
                    if (DetectCycle(vertex.Key, default(T), visitedNodes, AdjacencyList))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool DetectCycle(T startVertex, T parentVertex, HashSet<T> visitedNodes, Dictionary<T, HashSet<T>> AdjacencyList)
        {
            Queue<(T node, T parent)> neighborVertexQueue = new Queue<(T node, T parentNode)>();
            neighborVertexQueue.Enqueue((startVertex, parentVertex));


            return false;
        }

        /// <summary>
        /// Driver code to detect if a tree is bipartite or not.
        /// </summary>
        /// <param name="AdjacencyList"></param>
        /// <returns></returns>
        public static bool CheckBiPartite(Dictionary<T, HashSet<T>> AdjacencyList)
        {
            bool isBipartite = true;
            Dictionary<T, int> coloredVertexSet = new Dictionary<T, int>();

            foreach (var vertex in AdjacencyList)
            {
                if(!coloredVertexSet.ContainsKey(vertex.Key))
                {
                    if(!BiPartiteCheckBFS(AdjacencyList, vertex.Key, coloredVertexSet))
                    {
                        isBipartite = false;
                        return isBipartite;
                    }
                }
            }

            return isBipartite;
        }

        /// <summary>
        /// In a given graph component, it checks if the graph component is bipartite or not.(Using BFS)
        /// </summary>
        /// <param name="AdjacencyList"></param>
        /// <param name="start"></param>
        /// <param name="coloredVertexSet"></param>
        /// <returns></returns>
        private static bool BiPartiteCheckBFS(Dictionary<T, HashSet<T>> AdjacencyList, T start, Dictionary<T, int> coloredVertexSet)
        {
            Queue<T> neighborVetexQueue = new Queue<T>();

            neighborVetexQueue.Enqueue(start);
            coloredVertexSet.Add(start, 1);

            while (neighborVetexQueue.Count > 0)
            {
                var vertexKey = neighborVetexQueue.Dequeue();
                var colorToSet = 1 - coloredVertexSet[vertexKey];

                foreach (var neighborVertex in AdjacencyList[vertexKey])
                {
                    if (!coloredVertexSet.ContainsKey(neighborVertex))
                    {
                        coloredVertexSet.Add(neighborVertex, colorToSet);
                        neighborVetexQueue.Enqueue(neighborVertex);
                    }
                    else if (colorToSet != coloredVertexSet[neighborVertex])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Driver code to detect if a tree is bipartite or not.
        /// </summary>
        /// <param name="AdjacencyList"></param>
        /// <returns></returns>
        public static bool CheckIsGraphBiPartite(Dictionary<T, HashSet<T>> AdjacencyList)
        {

            bool isBipartite = true;
            Dictionary<T, int> coloredVertexSet = new Dictionary<T, int>();

            foreach (var vertex in AdjacencyList)
            {
                if (!coloredVertexSet.ContainsKey(vertex.Key))
                {
                    if (!BiPartiteCheckDFS(AdjacencyList, vertex.Key, coloredVertexSet))
                    {
                        isBipartite = false;
                        return isBipartite;
                    }
                }
            }

            return isBipartite;
        }

        /// <summary>
        /// In a given graph component, it checks if the graph component is bipartite or not.(Using DFS)
        /// </summary>
        /// <param name="AdjacencyList"></param>
        /// <param name="start"></param>
        /// <param name="coloredVertexSet"></param>
        /// <returns></returns>
        private static bool BiPartiteCheckDFS(Dictionary<T, HashSet<T>> AdjacencyList, T start, Dictionary<T, int> coloredVertexSet)
        {
            if(!coloredVertexSet.ContainsKey(start))
            {
                coloredVertexSet.Add(start, 1);
            }

            int colorToSet = 1 - coloredVertexSet[start];

            foreach (var neighborVertex in AdjacencyList[start])
            {
                if(!coloredVertexSet.ContainsKey(neighborVertex))
                {
                    coloredVertexSet[neighborVertex] = colorToSet;

                    if (!BiPartiteCheckDFS(AdjacencyList, neighborVertex, coloredVertexSet))
                    {
                        return false;
                    }
                }
                else if (colorToSet != coloredVertexSet[neighborVertex])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Function to check if they directed graph contains any cycles.
        /// </summary>
        /// <param name="AdjacencyList"></param>
        /// <returns></returns>
        public static bool IsCyclic(Dictionary<T, HashSet<T>> AdjacencyList)
        {
            HashSet<T> visited = new HashSet<T>();
            HashSet<T> dfsVisited = new HashSet<T>();

            foreach (var vertex in AdjacencyList)
            {
                if(!visited.Contains(vertex.Key))
                {
                    if(CheckCycle(AdjacencyList, visited, dfsVisited, vertex.Key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool CheckCycle(Dictionary<T, HashSet<T>> AdjacencyList, HashSet<T> visited, HashSet<T> dfsVisited, T node)
        {
            visited.Add(node);
            dfsVisited.Add(node);

            foreach (var neighbor in AdjacencyList[node])
            {
                if(!visited.Contains(neighbor))
                {
                    if (CheckCycle(AdjacencyList, visited, dfsVisited, neighbor))
                    {
                        return true;
                    }
                }
                else if(dfsVisited.Contains(neighbor))
                {
                    return true;
                }
            }

            dfsVisited.Remove(node);
            return false;
        }

        /// <summary>
        /// Topo Sort using DFS algorithm
        /// </summary>
        /// <param name="AdjacencyList"></param>
        /// <returns></returns>
        public static List<T> GetTopoSort(Dictionary<T, HashSet<T>> AdjacencyList)
        {
            Stack<T> topoStack = new Stack<T>();
            HashSet<T> visited = new HashSet<T>();

            foreach (var vertex in AdjacencyList)
            {
                if(!visited.Contains(vertex.Key))
                {
                    GetTopoSort(AdjacencyList, visited, topoStack, vertex.Key);
                }
            }

            return topoStack.ToList();
        }

        private static void GetTopoSort(Dictionary<T, HashSet<T>> AdjacencyList, HashSet<T> visited, Stack<T> topoStack, T startNode)
        {
            visited.Add(startNode);

            foreach(var neighbor in AdjacencyList[startNode])
            {
                if(!visited.Contains(neighbor))
                {
                    GetTopoSort(AdjacencyList, visited, topoStack, neighbor);
                }
            }

            topoStack.Push(startNode);
        }

        /// <summary>
        /// Topo sort using BFS/ Kahn's Algorithm.
        /// </summary>
        /// <param name="AdjacencyList"></param>
        /// <returns></returns>
        public static List<T> GetTopoSortBFS(Dictionary<T, HashSet<T>> AdjacencyList)
        {
            Dictionary<T, int> inDegree = new Dictionary<T, int>();
            GetInDegree(AdjacencyList, inDegree);

            Queue<T> topo = new Queue<T>();

            foreach (var vertex in inDegree)
            {
                if(inDegree[vertex.Key] == 0)
                {
                    topo.Enqueue(vertex.Key);
                }
            }

            List<T> topoSort = new List<T>();

            while (topo.Count > 0)
            {
                var node = topo.Dequeue();
                topoSort.Add(node);

                foreach(var connection in AdjacencyList[node])
                {
                    inDegree[connection] = inDegree[connection] - 1;

                    if(inDegree[connection] == 0)
                    {
                        topo.Enqueue(connection);
                    }
                }
            }

            return topoSort;
        }

        /// <summary>
        /// Function to calculate in degree of a directed graph
        /// </summary>
        /// <param name="AdjacencyList"></param>
        /// <param name="inDegree"></param>
        private static void GetInDegree(Dictionary<T, HashSet<T>> AdjacencyList, Dictionary<T, int> inDegree)
        {
            foreach (var vertex in AdjacencyList)
            {
                inDegree[vertex.Key] = 0;
            }

            foreach (var vertex in AdjacencyList)
            {
                foreach (var node in AdjacencyList[vertex.Key])
                {
                    if (inDegree.ContainsKey(node))
                    {
                        inDegree[node] = inDegree[node] + 1;
                    }
                    else
                    {
                        inDegree[node] = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Returns an list with minimum weight to each node from source node.
        /// </summary>
        /// <param name="AdjacencyList"></param>
        /// <param name="source"></param>
        public static void GetShortestPath(Dictionary<T, HashSet<T>> AdjacencyList, T source)
        {
            Dictionary<T, int> distance = new Dictionary<T, int>();
            Queue<T> bfsQueue = new Queue<T> ();

            distance.Add(source, 0);
            bfsQueue.Enqueue(source);

            while (bfsQueue.Count > 0)
            {
                T node = bfsQueue.Dequeue();

                foreach (var neighborVertex in AdjacencyList[node])
                {
                    if((!distance.ContainsKey(neighborVertex)) || (distance.ContainsKey(neighborVertex) && distance[node] + 1 < distance[neighborVertex]))
                    {
                        distance[neighborVertex] = distance[node] + 1;
                        bfsQueue.Enqueue(neighborVertex);
                    }
                }
            }

            Console.WriteLine("Printing Distance of Nodes from Source");
            foreach (var vertex in AdjacencyList)
            {
                Console.WriteLine($"Distance between {source} -> {vertex.Key} = {distance[vertex.Key]}");
            }

            Console.WriteLine();
        }
    }
}
