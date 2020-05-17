using NUnit.Framework;
using FlaskChallange;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Tests
{
    class FlaskProblemGraphTests
    {
        [Test]
        public void ShouldThrowWithIncorrectInputVAlues()
        {
            Assert.Throws(typeof(ArgumentException), ()=> new FlaskProblemGraph(3, -5));
        }

        [Test]
        public void ShouldReturnCorrectNeighbors()
        {
            var graph = new FlaskProblemGraph(3, 5);

            var neighbors = graph.FindNeighbor(new Coordinate(3, 3)).ToList();

            List<Coordinate> expectedNeighbors = new List<Coordinate>()
            {
                new Coordinate(3, 0),
                new Coordinate(3, 5),
                new Coordinate(0, 3),
                new Coordinate(1, 5),
            };

            Assert.True(neighbors.Count() == expectedNeighbors.Count() &&
                neighbors.All(n => expectedNeighbors.Contains(n)));
        }

        [Test]
        public void ShouldInitializeWithCorrectValues()
        {
            var expectedGraphVertices = new List<Coordinate>()
            {
                new Coordinate(0, 0),
                new Coordinate(1, 0),
                new Coordinate(2, 0),
                new Coordinate(0, 3),
                new Coordinate(1, 3),
                new Coordinate(2, 3),

                new Coordinate(0, 1),
                new Coordinate(0, 2),

                new Coordinate(2, 1),
                new Coordinate(2, 2),
            };

            var graph = new FlaskProblemGraph(2, 3);

            Assert.True(graph.Vertices.Count() == expectedGraphVertices.Count() &&
                graph.Vertices.All(n => expectedGraphVertices.Contains(n)));

        }
    }
}
