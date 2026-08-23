using System;

namespace Task06.App.Models
{
    public class Money
    {
        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money operator +(Money first, Money second)
        {
            CheckCurrency(first, second);

            return new Money(first.Amount + second.Amount,first.Currency);
        }

        public static Money operator -(Money first, Money second)
        {
            CheckCurrency(first, second);

            return new Money(first.Amount - second.Amount,first.Currency);
        }

        public static bool operator ==(Money first, Money second)
        {
            if (ReferenceEquals(first, second))
                return true;

            if (first is null || second is null)
                return false;

            return first.Amount == second.Amount &&
                   first.Currency == second.Currency;
        }

        public static bool operator !=(Money first, Money second)
        {
            return !(first == second);
        }

        public static bool operator >(Money first, Money second)
        {
            CheckCurrency(first, second);

            return first.Amount > second.Amount;
        }

        public static bool operator <(Money first, Money second)
        {
            CheckCurrency(first, second);

            return first.Amount < second.Amount;
        }

        private static void CheckCurrency(Money first,Money second)
        {
            if (first.Currency != second.Currency)
            {
                throw new InvalidOperationException("Cannot compare or operate on different currencies.");
            }
        }

        ~Money()
        {
            Console.WriteLine($"Finalizer called for {Amount} {Currency}");
        }
    }
}