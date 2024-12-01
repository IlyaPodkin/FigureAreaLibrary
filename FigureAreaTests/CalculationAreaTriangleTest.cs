using FigureAreaLibrary;

namespace FigureAreaTests
{
    public class CalculationAreaTriangleTest
    {
        [Theory]
        [InlineData(5, 12, 13, 30)]
        [InlineData(7, 24, 25, 84)]
        public void GetShapeArea_WhenTriangleSidesAreValid_ReturnsCorrectValue(double sideA, double sideB, double sideC, double expected)
        {
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            var actual = triangle.GetShapeArea();

            Assert.Equal(expected, actual, precision: 5);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, -10, 0)]
        [InlineData(-10, -70, -80)]
        [InlineData(10, 10, 0)]
        public void GetShapeArea_WhenTriangleSidesAreInvalid_ThrowsArgumentException(double sideA, double sideB, double sideC)
        {
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            var action = (Action)(() => triangle.GetShapeArea());

            Assert.Throws<ArgumentException>(action);

        }

        [Fact]
        public void IsRightTriangle_WhenTriangleIsRight_ReturnsTrue()
        {
            Triangle triangle = new Triangle(6, 8, 10);

            var actual = triangle.IsRightTriangle();

            Assert.True(actual);
        }

        [Fact]
        public void IsRightTriangle_WhenTriangleIsNotRight_ReturnsFalse()
        {
            Triangle triangle = new Triangle(32, 43, 56);

            var actual = triangle.IsRightTriangle();

            Assert.False(actual);
        }

        [Fact]
        public void GetShapeArea_WhenTriangleIsProvided_ReturnsCorrectValue()
        {
            IShape triangle = new Triangle(5, 12, 13);

            var actualTriangle = CalculationShapeArea.GetShapeArea(triangle);

            Assert.Equal(30, actualTriangle, precision: 5);
        }
    }
}
