namespace FigureAreaLibrary
{
    public sealed class Triangle : IShape
    {
        private double SideA { get; }
        private double SideB { get; }
        private double SideC { get; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public double GetShapeArea()
        {
            ValidateSides();
            double perimeter = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(perimeter
                * (perimeter - SideA)
                * (perimeter - SideB)
                * (perimeter - SideC));
        }
        public bool IsRightTriangle()
        {
            ValidateSides();
            double[] sides = [SideA, SideB, SideC];
            Array.Sort(sides);
            return Math.Pow(sides[2], 2) == Math.Pow(sides[1], 2) + Math.Pow(sides[0], 2);
        }
        private void ValidateSides()
        {
            if (SideA <= 0 || SideB <= 0 || SideC <= 0)
            {
                throw new ArgumentException("The sides of a triangle must not be less than or equal to zero");
            }
        }
    }
}
