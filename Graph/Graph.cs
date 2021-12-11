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
}
