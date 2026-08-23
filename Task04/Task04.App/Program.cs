using System;
using Task04.App.Models;

namespace Task04.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee Demo");

            Employee employee1 = new Employee();

            Console.WriteLine($"Default Employee: {employee1.Name}");
            Console.WriteLine($"Salary: {employee1.Salary}");

            Console.WriteLine();

            Employee employee2 = new Employee(
                1,
                "Zuhair",
                300
            );

            Console.WriteLine($"ID: {employee2.Id}");
            Console.WriteLine($"Name: {employee2.Name}");
            Console.WriteLine($"Salary: {employee2.Salary}");

            Console.WriteLine();

            employee2[0] = "C#";
            employee2[1] = "SQL";
            employee2[2] = "Git";

            Console.WriteLine("Skills:");

            Console.WriteLine(employee2[0]);
            Console.WriteLine(employee2[1]);
            Console.WriteLine(employee2[2]);

            Console.WriteLine();

            Employee employee3 = new Employee(employee2);

            Console.WriteLine("Copied Employee:");
            Console.WriteLine($"ID: {employee3.Id}");
            Console.WriteLine($"Name: {employee3.Name}");
            Console.WriteLine($"Salary: {employee3.Salary}");

            Console.WriteLine();

            try
            {
                employee2.Salary = -500;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Validation Error: {ex.Message}");
            }

            Console.WriteLine();

            Console.WriteLine($"Maximum Salary: {Employee.MaxSalary}");
        }
    }
}