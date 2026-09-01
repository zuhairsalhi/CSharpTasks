#nullable enable

using System;
using System.Collections.Generic;
using System.IO;

string filePath = "products.csv";

if (!File.Exists(filePath))
{
    File.WriteAllLines(filePath,
    [
        "1,Laptop,1200,Electronics",
        "2,Mouse,25,Electronics",
        "3,Keyboard,50,Electronics",
        "4,Chair,150,Furniture",
        "5,Desk,300,Furniture",
        "6,Phone,800,Electronics"
    ]);
}

IEnumerable<string> csvLines = ReadCsvLines(filePath);

IEnumerable<Product> products = ParseProducts(csvLines);

IEnumerable<Product> filteredProducts = FilterProducts(products);

IEnumerable<string> result = TransformProducts(filteredProducts);

List<string>? messages = null;

messages ??= new List<string>();

messages.Add("Pipeline started.");

Console.WriteLine("Product Data Pipeline");
Console.WriteLine();

foreach (string output in result)
{
    Console.WriteLine(output);
}

Console.WriteLine();

Console.WriteLine(
    messages.Count > 0
        ? messages[0]
        : "No messages."
);

Console.WriteLine();
Console.WriteLine("Pipeline completed successfully.");


IEnumerable<string> ReadCsvLines(string path)
{
    if (!File.Exists(path))
    {
        yield break;
    }

    using StreamReader reader = new StreamReader(path);

    string? line;

    while ((line = reader.ReadLine()) != null)
    {
        if (!string.IsNullOrWhiteSpace(line))
        {
            yield return line;
        }
    }
}


IEnumerable<Product> ParseProducts(
    IEnumerable<string> lines)
{
    foreach (string line in lines)
    {
        string[] parts = line.Split(',');

        if (parts.Length != 4)
        {
            continue;
        }

        if (!int.TryParse(parts[0], out int id))
        {
            continue;
        }

        if (!decimal.TryParse(parts[2], out decimal price))
        {
            continue;
        }

        string name = parts[1].Trim();
        string category = parts[3].Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            continue;
        }

        if (string.IsNullOrWhiteSpace(category))
        {
            continue;
        }

        yield return new Product(
            id,
            name,
            price,
            category
        );
    }
}


IEnumerable<Product> FilterProducts(
    IEnumerable<Product> products)
{
    foreach (Product product in products)
    {
        if (product.Category.Equals(
            "Electronics",
            StringComparison.OrdinalIgnoreCase))
        {
            if (product.Price > 20)
            {
                yield return product;
            }
        }
    }
}
IEnumerable<string> TransformProducts(
    IEnumerable<Product> products)
{
    foreach (Product product in products)
    {
        string? category = product.Category;

        string categoryName =
            category?.ToUpper() ?? "UNKNOWN";

        yield return
            $"Product: {product.Name} | " +
            $"Price: ${product.Price} | " +
            $"Category: {categoryName}";
    }
}
record Product(
    int Id,
    string Name,
    decimal Price,
    string Category
);