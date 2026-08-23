using System;
using System.Diagnostics;

namespace Task03.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implicit Casting");

            int intNumber = 100;
            long longNumber = intNumber;

            Console.WriteLine($"int: {intNumber}");
            Console.WriteLine($"long: {longNumber}");

            Console.WriteLine();
            Console.WriteLine("Explicit Casting");

            double price = 19.99;
            int wholePrice = (int)price;

            Console.WriteLine($"double: {price}");
            Console.WriteLine($"int: {wholePrice}");

            try
            {
                int largeNumber = 1000;
                byte smallNumber = checked((byte)largeNumber);

                Console.WriteLine(smallNumber);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Explicit casting failed: value is too large.");
            }

            Console.WriteLine();
            Console.WriteLine("Convert");

            try
            {
                string text = "hello";
                int number = Convert.ToInt32(text);

                Console.WriteLine(number);
            }
            catch (FormatException)
            {
                Console.WriteLine("Convert failed: invalid format.");
            }

            Console.WriteLine();
            Console.WriteLine("Parse");

            try
            {
                string text = "hello";
                int number = int.Parse(text);

                Console.WriteLine(number);
            }
            catch (FormatException)
            {
                Console.WriteLine("Parse failed: invalid format.");
            }

            Console.WriteLine();
            Console.WriteLine("TryParse");

            string input = "hello";

            if (int.TryParse(input, out int parsedNumber))
            {
                Console.WriteLine($"Parsed: {parsedNumber}");
            }
            else
            {
                Console.WriteLine("TryParse failed: invalid number.");
            }

            Console.WriteLine();
            Console.WriteLine("Boxing & Unboxing");

            int value = 100;

            object boxedValue = value;

            Console.WriteLine($"Boxed: {boxedValue}");

            int unboxedValue = (int)boxedValue;

            Console.WriteLine($"Unboxed: {unboxedValue}");

            try
            {
                double wrongUnboxing = (double)boxedValue;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Unboxing failed: wrong type.");
            }

            Console.WriteLine();
            Console.WriteLine("Performance");

            Stopwatch boxingWatch = Stopwatch.StartNew();

            object boxed = 0;

            for (int i = 0; i < 1_000_000; i++)
            {
                boxed = i;
            }

            boxingWatch.Stop();

            Stopwatch directWatch = Stopwatch.StartNew();

            int direct = 0;

            for (int i = 0; i < 1_000_000; i++)
            {
                direct = i;
            }

            directWatch.Stop();

            Console.WriteLine($"Boxing: {boxingWatch.ElapsedTicks} ticks");
            Console.WriteLine($"Direct: {directWatch.ElapsedTicks} ticks");
        }
    }
}