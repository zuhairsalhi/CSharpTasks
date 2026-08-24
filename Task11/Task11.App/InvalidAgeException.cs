namespace Task11.App
{
    public class InvalidAgeException : ValidationException
    {
        public InvalidAgeException(string message) : base(message)
        {

        }
    }
}