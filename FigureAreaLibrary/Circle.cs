namespace FigureAreaLibrary
{
    public sealed class Circle : IShape
    {
        private double Radius { get; }

        public Circle(double radius) 
        {
            Radius = radius;
        }

        public double GetShapeArea()
        {
            if (Radius <= 0) 
            {
                throw new ArgumentException("Radius must be greater than zero");
            }
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
