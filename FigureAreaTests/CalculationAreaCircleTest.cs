using FigureAreaLibrary;

namespace FigureAreaTests
{
    public class CalculationAreaCircleTest
    {
        [Theory]
        [InlineData(8, 201.06193)]
        [InlineData(10, 314.15927)]
        [InlineData(5, 78.53982)]
        public void GetShapeArea_WhenRadiusIsPositive_ReturnsCorrectValue(double radius, double expectedArea)
        {
            Circle circle = new Circle(radius);

            var actual = circle.GetShapeArea();

            Assert.Equal(expectedArea, actual, precision: 5);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void GetShapeArea_WhenRadiusIsZeroOrNegative_ThrowsArgumentException(double radius)
        {
            Circle circle = new Circle(radius);

            var action = (Action)(() => circle.GetShapeArea());

            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void GetShapeArea_WhenCircleIsProvided_ReturnsCorrectValue()
        {
            IShape circle = new Circle(5);

            var actualCircle = CalculationShapeArea.GetShapeArea(circle);

            Assert.Equal(78.53982, actualCircle, precision: 5);
        }

    }
}
