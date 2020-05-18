using System.Collections.Generic;
using System.Linq;

namespace FlaskChallange
{
    public class FlaskProblemGraph
    {
        public IEnumerable<Coordinate> Vertices { get; }
        public FlaskProblemGraph(int size1, int size2)
        {

            if (size1 <= 0 || size2 <= 0)
            {
                throw new System.ArgumentException("Flask sizes must be larger than 0");
            }

            Vertices = CreateVertices(size1, size2);
        }

        private IEnumerable<Coordinate> CreateVertices(int size1, int size2)
        {
            List<Coordinate> verices = new List<Coordinate>();

            verices = Enumerable.Range(0, size2 + 1).Select(x => new Coordinate(0, x)).ToList();
            verices.AddRange(Enumerable.Range(0, size2 + 1).Select(x => new Coordinate(size1, x)).ToList());
            verices.AddRange(Enumerable.Range(1, size1 - 1).Select(y => new Coordinate(y, 0)).ToList());
            verices.AddRange(Enumerable.Range(1, size1 - 1).Select(y => new Coordinate(y, size2)).ToList());

            return verices;
        }

        public IEnumerable<Coordinate> FindNeighbor(
            Coordinate vertex)
        {
            if(vertex is null)
            {
                throw new System.ArgumentNullException();
            }

            int maxX = Vertices.Select(v => v.X).Max();
            int minX = Vertices.Select(v => v.X).Min();
            int maxY = Vertices.Select(v => v.Y).Max();
            int minY = Vertices.Select(v => v.Y).Min();

            var flaskY = Vertices.Where(v => v.X == vertex.X && (v.Y == maxY || v.Y == minY)).ToList(); // empty or fill flask Y
            var flaskX = Vertices.Where(v => v.Y == vertex.Y && (v.X == maxX || v.X == minX)).ToList(); // empty or fill flask X

            var pour = Vertices.Where(v => (vertex.X + vertex.Y) - v.X == v.Y).ToList(); // pour from one flask to the other

            var neighbors = flaskY.Concat(flaskX).Concat(pour).Where(v => v!=vertex).Distinct();

            return neighbors;
        }
    }

}
