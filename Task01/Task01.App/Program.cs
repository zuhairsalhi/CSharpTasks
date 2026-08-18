using System;

namespace Task01.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Primitive Types");
            Console.WriteLine();

            int intValue = 0;
            double doubleValue = 0;
            float floatValue = 0;
            decimal decimalValue = 0;
            char charValue = '\0';
            string? stringValue = null;
            bool boolValue = false;
            byte byteValue = 0;
            long longValue = 0;

            Console.WriteLine("int:");
            Console.WriteLine($"Default: {intValue}");
            Console.WriteLine($"Min: {int.MinValue}");
            Console.WriteLine($"Max: {int.MaxValue}");
            Console.WriteLine();

            Console.WriteLine("double:");
            Console.WriteLine($"Default: {doubleValue}");
            Console.WriteLine($"Min: {double.MinValue}");
            Console.WriteLine($"Max: {double.MaxValue}");
            Console.WriteLine();

            Console.WriteLine("float:");
            Console.WriteLine($"Default: {floatValue}");
            Console.WriteLine($"Min: {float.MinValue}");
            Console.WriteLine($"Max: {float.MaxValue}");
            Console.WriteLine();

            Console.WriteLine("decimal:");
            Console.WriteLine($"Default: {decimalValue}");
            Console.WriteLine($"Min: {decimal.MinValue}");
            Console.WriteLine($"Max: {decimal.MaxValue}");
            Console.WriteLine();

            Console.WriteLine("char:");
            Console.WriteLine($"Default: {(int)charValue}");
            Console.WriteLine($"Min: {(int)char.MinValue}");
            Console.WriteLine($"Max: {(int)char.MaxValue}");
            Console.WriteLine();

            Console.WriteLine("string:");
            Console.WriteLine($"Default: {stringValue ?? "null"}");
            Console.WriteLine();

            Console.WriteLine("bool:");
            Console.WriteLine($"Default: {boolValue}");
            Console.WriteLine();

            Console.WriteLine("byte:");
            Console.WriteLine($"Default: {byteValue}");
            Console.WriteLine($"Min: {byte.MinValue}");
            Console.WriteLine($"Max: {byte.MaxValue}");
            Console.WriteLine();

            Console.WriteLine("long:");
            Console.WriteLine($"Default: {longValue}");
            Console.WriteLine($"Min: {long.MinValue}");
            Console.WriteLine($"Max: {long.MaxValue}");
        }
    }
}