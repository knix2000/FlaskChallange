using System.Collections.Generic;
using System.Linq;

namespace FlaskChallange
{
    /// <summary>
    /// Caltulates the least number of iterations to get to each point in the grid
    /// </summary>
    public static class BreadthFirstSearch
    {
        public static Dictionary<Coordinate, int> CalculateAllIterations(FlaskProblemGraph graph)
        {
            Dictionary<Coordinate, Coordinate> previousVertex = new Dictionary<Coordinate, Coordinate>();
            Dictionary<Coordinate, int> dist = graph.Vertices.ToDictionary(x => x, x => int.MaxValue);
            Dictionary<Coordinate, VertexStatus> vertexStatus = graph.Vertices.ToDictionary(x => x, x => VertexStatus.NotVisited);
            Dictionary<Coordinate, int> noIterations = new Dictionary<Coordinate, int>();

            dist[graph.Vertices.First()] = 0;

            Queue<Coordinate> Q = new Queue<Coordinate>();
            Q.Enqueue(graph.Vertices.First());

            while (Q.Count > 0)
            {
                var u = Q.First();

                foreach (var neighbor in graph.FindNeighbor(u))
                {
                    if (vertexStatus[neighbor] == VertexStatus.NotVisited)
                    {
                        dist[neighbor] = dist[u] + 1;
                        previousVertex[neighbor] = u;
                        vertexStatus[neighbor] = VertexStatus.Visited;
                        Q.Enqueue(neighbor);
                        noIterations[neighbor] = dist[neighbor];
                    }
                }
                Q.Dequeue();
                vertexStatus[u] = VertexStatus.AllNeighborsVisited;
            }
            return noIterations;
        }

        public enum VertexStatus
        {
            NotVisited,
            Visited,
            AllNeighborsVisited,
        }

    }
}
