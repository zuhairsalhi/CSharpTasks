using System;
using System.Collections.Generic;

namespace Task09.App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Circle(5));
            shapes.Add(new Rectangle(10, 5));
            shapes.Add(new Triangle(8, 4));

            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"{shape.Name} Area = {shape.CalculateArea()}");
            }
        }
    }
}