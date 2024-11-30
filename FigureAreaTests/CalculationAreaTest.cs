using FigureAreaLibrary;

namespace FigureAreaTests
{
    /// <summary>
    /// Содержит тесты для проверки вычисления площадей фигур и свойств треугольников.
    /// </summary>
    public class CalculationAreaTest
    {
        /// <summary>
        /// Проверяет, корректно ли вычисляется площадь круга для положительных радиусов.
        /// </summary>
        [Theory]
        [InlineData(8, 201.06193)]
        [InlineData(10, 314.15927)]
        [InlineData(5, 78.53982)]
        public void CalculationArea_ShouldReturnCorrectArea_WhenRadiusCircleIsPositive(double radius, double expected)
        {
            Circle circle = new Circle(radius);
            Assert.Equal(expected, circle.GetShapeArea(), precision: 5);
        }

        /// <summary>
        /// Проверяет, выбрасывается ли исключение для отрицательных или нулевых радиусов круга.
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void CalculationArea_ShouldReturnThrow_WhenRadiusCircleIsNegative(double radius)
        {
            Circle circle = new Circle(radius);
            Assert.Throws<ArgumentException>(() => circle.GetShapeArea());
        }

        /// <summary>
        /// Проверяет, корректно ли вычисляется площадь треугольника для валидных сторон.
        /// </summary>
        [Theory]
        [InlineData(5, 12, 13, 30)]
        [InlineData(7, 24, 25, 84)]
        public void CalculationArea_ShouldReturnCorrectArea_WhenSidesTriangleIsPositive(double sideA, double sideB, double sideC, double expected)
        {
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            Assert.Equal(expected, triangle.GetShapeArea(), precision: 5);
        }

        /// <summary>
        /// Проверяет, выбрасывается ли исключение для треугольников с некорректными сторонами.
        /// </summary>
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, -10, 0)]
        [InlineData(-10, -70, -80)]
        [InlineData(10, 10, 0)]
        public void CalculationArea_ShouldReturnThrow_WhenSidesTriangleIsNegative(double sideA, double sideB, double sideC)
        {
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            Assert.Throws<ArgumentException>(() => triangle.GetShapeArea());
        }

        /// <summary>
        /// Проверяет условие, является ли треугольник прямоугольным.
        /// </summary>
        [Fact]
        public void Test_CheckRightTriangle_Condition()
        {
            Triangle triangle = new Triangle(6, 8, 10);
            Assert.True(triangle.IsRightTriangle());
        }

        /// <summary>
        /// Проверяет условие, если треугольник не является прямоугольным.
        /// </summary>
        [Fact]
        public void Test_CheckIsNotRightTriangle_Condition()
        {
            Triangle triangle = new Triangle(32, 43, 56);
            Assert.False(triangle.IsRightTriangle());
        }

        /// <summary>
        /// Проверяет вычисление площади для разных фигур через общий интерфейс
        /// </summary>
        [Fact]
        public void CalculateArea_ShouldWorkWithDifferentShapes()
        {
            IShape circle = new Circle(5);
            IShape triangle = new Triangle(5, 12, 13);

            Assert.Equal(78.53982, CalculationShapeArea.GetShapeArea(circle), precision: 5);
            Assert.Equal(30, CalculationShapeArea.GetShapeArea(triangle), precision: 5);
        }
    }
}
