using System;

namespace Task09.App
{
    public class Circle : Shape, IDrawable, IResizable
    {
        public double Radius { get; set; }

        public Circle(double radius) : base("Circle")
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public void Draw()
        {
            Console.WriteLine("Drawing Circle");
        }

        public void Resize(double factor)
        {
            Radius *= factor;
        }
    }
}