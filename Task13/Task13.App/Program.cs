using System;

namespace Task13.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Extension Methods");

            string text = "hello world from csharp";
            
            Console.WriteLine();
            Console.WriteLine("Original:");
            Console.WriteLine(text);

            Console.WriteLine();
            Console.WriteLine("Title Case:");
            Console.WriteLine(text.ToTitleCase());

            Console.WriteLine();
            Console.WriteLine("Truncate:");
            Console.WriteLine(text.Truncate(10));

            Console.WriteLine();
            Console.WriteLine("Valid Email:");
            Console.WriteLine("test@gmail.com".IsValidEmail());

            Console.WriteLine();
            Console.WriteLine("Slug:");
            Console.WriteLine(text.ToSlug());
        }
    }
}