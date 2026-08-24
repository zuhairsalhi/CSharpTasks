using System;

namespace Task10.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository<Product> repository = new Repository<Product>();

            repository.Add(new Product(1, "Laptop", 1000));
            repository.Add(new Product(2, "Mouse", 25));
            repository.Add(new Product(3, "Keyboard", 50));

            Console.WriteLine("All Products:");

            foreach (Product product in repository.GetAll())
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();

            Product found = repository.GetById(2);

            Console.WriteLine("Found:");
            Console.WriteLine(found);

            repository.Remove(1);

            Console.WriteLine();

            Console.WriteLine("After Remove:");

            foreach (Product product in repository.GetAll())
            {
                Console.WriteLine(product);
            }
        }
    }
}