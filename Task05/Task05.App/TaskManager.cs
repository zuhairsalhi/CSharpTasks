using System;

namespace Task05.App
{
    public delegate void NotificationHandler(string message);

    public class TaskManager
    {
        public event EventHandler? TaskCompleted;

        public void CompleteTask(string taskName)
        {
            Console.WriteLine($"Completing task:{taskName}");

            TaskCompleted?.Invoke(this,EventArgs.Empty);
        }

        public void SendNotification(
            string message,
            NotificationHandler notificationHandler)
        {
            notificationHandler(message);
        }
    }
}