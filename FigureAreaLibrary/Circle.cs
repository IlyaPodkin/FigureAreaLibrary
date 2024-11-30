namespace FigureAreaLibrary
{
    public class Circle : IShape
    {
        public double Radius { get; set; }

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
