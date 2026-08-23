using System;
using System.IO;

namespace Task05.App
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();

            manager.TaskCompleted += OnTaskCompletedConsole;

            manager.TaskCompleted += OnTaskCompletedFile;

            Console.WriteLine("Delegate Demo");

            manager.SendNotification("A new task has been created.",ConsoleNotification);

            Console.WriteLine();

            Console.WriteLine("Event Demo");

            manager.CompleteTask("Complete Task 5");

            Console.WriteLine();
            Console.WriteLine("Done.");
        }

        static void ConsoleNotification(string message)
        {
            Console.WriteLine($"Notification: {message}");
        }

        static void OnTaskCompletedConsole(object? sender,EventArgs e)
        {
            Console.WriteLine("Event Handler: Task completed!");
        }

        static void OnTaskCompletedFile(object? sender,EventArgs e)
        {
            string filePath = "task-log.txt";

            File.AppendAllText(filePath,$"Task completed at {DateTime.Now}{Environment.NewLine}");

            Console.WriteLine($"Event Handler: Logged to {filePath}");
        }
    }
}