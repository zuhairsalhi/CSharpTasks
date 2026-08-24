using System;

namespace Task12.App
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberRange numbers = new NumberRange(1, 5);

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}