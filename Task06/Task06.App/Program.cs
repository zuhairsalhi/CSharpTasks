using System;
using Task06.App.Models;

namespace Task06.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Money money1 = new Money(100,"USD");
            Money money2 = new Money(50,"USD");

            Console.WriteLine("Addition");

            Money total = money1 + money2;

            Console.WriteLine( $"{total.Amount} {total.Currency}");

            Console.WriteLine();

            Console.WriteLine("Subtraction");

            Money difference = money1 - money2;

            Console.WriteLine($"{difference.Amount} {difference.Currency}");

            Console.WriteLine();

            Console.WriteLine("Comparison");

            Console.WriteLine(money1 > money2);
            Console.WriteLine(money1 < money2);

            Console.WriteLine();

            Console.WriteLine("Equality");

            Money money3 = new Money(100,"USD");

            Console.WriteLine(money1 == money3);
            Console.WriteLine(money1 != money2);

            Console.WriteLine();

            Console.WriteLine("Garbage Collection");

            CreateMoney();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Garbage collection finished.");
        }

        static void CreateMoney()
        {
            Money temporaryMoney = new Money(500,"USD");
        }
    }
}