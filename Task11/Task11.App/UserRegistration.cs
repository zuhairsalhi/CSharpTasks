namespace Task11.App
{
    public class UserRegistration
    {
        public void Register(string name, int age)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ValidationException(
                    "Name cannot be empty."
                );
            }

            if (age < 18)
            {
                throw new InvalidAgeException(
                    "User must be at least 18 years old."
                );
            }

            Console.WriteLine(
                $"User {name} registered successfully."
            );
        }
    }
}