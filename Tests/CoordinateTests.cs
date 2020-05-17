using NUnit.Framework;
using FlaskChallange;

namespace Tests
{
    public class CoordinateTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Datapoint]
        public int zero = 0;
        public int positive = 1;
        public int negative = -1;
        public int maxvalue = int.MaxValue;
        public int minvalue = int.MinValue;


        [Theory]
        public void ShouldInitializeWithCorrectValues(int x, int y)
        {
            var coord = new Coordinate(x, y);

            Assert.AreEqual(coord.X, x);
            Assert.AreEqual(coord.Y, y);
        }

        [Theory]
        public void SamePositionShouldBeSame(int x, int y)
        {
            var coord1 = new Coordinate(x, y);
            var coord2 = new Coordinate(x, y);

            Assert.True(coord1==coord2);
        }

        [Theory]
        public void DifferenPositionShouldBeDifferent(int x, int y)
        {
            var coord1 = new Coordinate(x, y);
            var coord2 = new Coordinate(2*x+1, y);

            Assert.True(coord1!=coord2);
        }

    }
}