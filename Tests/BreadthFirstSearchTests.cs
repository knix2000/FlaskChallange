using NUnit.Framework;
using FlaskChallange;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    class BreadthFirstSearchTests
    {
        [Test]
        public void ShouldReturnCorrectNoIterations()
        {
            var expectedIterations = new Dictionary<Coordinate, int>()
            {
                { new Coordinate(1,0), 1 },
                { new Coordinate(0,1), 1 },
                { new Coordinate(1,1), 2 },
            };

            var breadthFirstSearch = BreadthFirstSearch.CalculateAllIterations(new FlaskProblemGraph(1, 1));

            Assert.True(breadthFirstSearch.Count == expectedIterations.Count);
            Assert.True(breadthFirstSearch.All(i => expectedIterations.Contains(i)));
        }
        [Test]
        public void ShouldReturnFalse()
        {
            var expectedIterations = new Dictionary<Coordinate, int>()
            {
                { new Coordinate(1,0), 1 },
                { new Coordinate(0,1), 1 },
                { new Coordinate(1,1), 2 },
                { new Coordinate(2,1), 2 },
            };

            var breadthFirstSearch = BreadthFirstSearch.CalculateAllIterations(new FlaskProblemGraph(1, 1));

            Assert.False(breadthFirstSearch.Count == expectedIterations.Count &&
                breadthFirstSearch.All(i => expectedIterations.Contains(i)));
        }

    }
}
