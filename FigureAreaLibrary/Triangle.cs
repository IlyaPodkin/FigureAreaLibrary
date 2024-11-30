namespace FigureAreaLibrary
{
    public class Triangle : IShape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

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
            double[] sides = new double[] { SideA, SideB, SideC };
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
