using System;

namespace Task08.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Struct");

            Color color1 = new Color(255, 0, 0);
            Color color2 = color1;

            color2.R = 100;

            Console.WriteLine($"Color 1: {color1}");
            Console.WriteLine($"Color 2: {color2}");

            Console.WriteLine();

            Console.WriteLine("Class");

            ColorClass color3 = new ColorClass(255, 0, 0);
            ColorClass color4 = color3;

            color4.R = 100;

            Console.WriteLine($"Color 3: RGB({color3.R}, {color3.G}, {color3.B})");

            Console.WriteLine($"Color 4: RGB({color4.R}, {color4.G}, {color4.B})");
        }
    }
}