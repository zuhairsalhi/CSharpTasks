using System;

namespace Task18.App
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Task 18 Exception Handling");
            Console.WriteLine();

            Console.WriteLine("Try / Catch");

            try
            {
                int number = int.Parse("abc");
                Console.WriteLine(number);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number format.");
            }

            Console.WriteLine();
            Console.WriteLine("Division");

            try
            {
                int result = Divide(10, 0);
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero.");
            }


            Console.WriteLine();
            Console.WriteLine("Finally");

            try
            {
                Console.WriteLine("Trying something...");
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred.");
            }
            finally
            {
                Console.WriteLine("This always runs.");
            }

            Console.WriteLine();
            Console.WriteLine("Custom Validation");

            try
            {
                CreateUser("", 15);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Program finished.");
        }

        static int Divide(int firstNumber, int secondNumber)
        {
            if (secondNumber == 0)
            {
                throw new DivideByZeroException();
            }

            return firstNumber / secondNumber;
        }

        static void CreateUser(string name, int age)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            if (age < 18)
            {
                throw new ArgumentException("User must be 18 or older.");
            }

            Console.WriteLine("User created successfully.");
        }
    }
}