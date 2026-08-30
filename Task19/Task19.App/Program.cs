using System;
using System.IO;

namespace Task19.App
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Task 19 File I/O");
            Console.WriteLine();

            string filePath = "contacts.txt";

            Console.WriteLine("Writing to file");

            File.WriteAllText(
                filePath,
                "Zuhair - 0791234567\n" +
                "Ahmad - 0789876543\n" +
                "Omar - 0775555555"
            );

            Console.WriteLine("File created successfully.");

            Console.WriteLine();
            Console.WriteLine("File Content");

            string content = File.ReadAllText(filePath);

            Console.WriteLine(content);

            Console.WriteLine();
            Console.WriteLine("Adding another contact");

            File.AppendAllText(
                filePath,
                "\nKhaled - 0791111111"
            );

            Console.WriteLine();
            Console.WriteLine(" Updated File ");

            string updatedContent = File.ReadAllText(filePath);

            Console.WriteLine(updatedContent);

            Console.WriteLine();
            Console.WriteLine(" File Check ");

            if (File.Exists(filePath))
            {
                Console.WriteLine("contacts.txt exists");
            }
            else
            {
                Console.WriteLine("contacts.txt does not exist");
            }

            Console.WriteLine();
            Console.WriteLine("Program finished");
        }
    }
}