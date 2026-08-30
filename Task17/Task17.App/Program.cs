using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Task17.App
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Task 17: Async and Await");
            Console.WriteLine();

            Console.WriteLine("Starting...");

            string result = await GetDataAsync();

            Console.WriteLine($"Result: {result}");

            Console.WriteLine();
            Console.WriteLine(" Multiple Tasks ");

            Task<string> task1 = GetDataAsync("Task 1");
            Task<string> task2 = GetDataAsync("Task 2");
            Task<string> task3 = GetDataAsync("Task 3");

            string[] results = await Task.WhenAll(task1, task2, task3);

            foreach (string item in results)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine(" Cancellation ");

            using CancellationTokenSource cancellationTokenSource =
                new CancellationTokenSource();

            Task longTask = LongRunningTaskAsync(
                cancellationTokenSource.Token);

            await Task.Delay(1500);

            Console.WriteLine("Cancelling task.");

            cancellationTokenSource.Cancel();

            try
            {
                await longTask;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Task was cancelled.");
            }

            Console.WriteLine();
            Console.WriteLine("Program finished.");
        }

        static async Task<string> GetDataAsync()
        {
            await Task.Delay(1000);

            return "Data loaded successfully";
        }

        static async Task<string> GetDataAsync(string taskName)
        {
            await Task.Delay(1000);

            return $"{taskName} completed";
        }

        static async Task LongRunningTaskAsync(
            CancellationToken cancellationToken)
        {
            for (int i = 1; i <= 10; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                Console.WriteLine($"Working... {i}");

                await Task.Delay(500, cancellationToken);
            }
        }
    }
}