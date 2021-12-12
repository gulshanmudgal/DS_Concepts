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
    }
}
