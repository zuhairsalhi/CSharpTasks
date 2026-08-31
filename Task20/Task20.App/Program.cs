using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Task20.App
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - ${Price}";
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Task 20 JSON");
            Console.WriteLine();
            
            List<Product> products = new List<Product>
            {
                new Product(1, "Laptop", 850),
                new Product(2, "Mouse", 25),
                new Product(3, "Keyboard", 50)
            };

            Console.WriteLine("Serialization");

            string json = JsonSerializer.Serialize(
                products,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            );

            Console.WriteLine(json);

            Console.WriteLine();
            Console.WriteLine("Saving JSON to file");

            File.WriteAllText("products.json", json);

            Console.WriteLine("products.json created.");

            Console.WriteLine();
            Console.WriteLine(" Reading JSON ");

            string jsonFromFile = File.ReadAllText("products.json");

            Console.WriteLine(jsonFromFile);

            Console.WriteLine();
            Console.WriteLine("Deserialization");

            List<Product>? loadedProducts =
                JsonSerializer.Deserialize<List<Product>>(jsonFromFile);

            if (loadedProducts != null)
            {
                foreach (Product product in loadedProducts)
                {
                    Console.WriteLine(product);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Program finished.");
        }
    }
}