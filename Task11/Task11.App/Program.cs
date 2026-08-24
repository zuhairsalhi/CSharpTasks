using System;

namespace Task11.App
{
    class Program
    {
        static void Main(string[] args)
        {
            UserRegistration registration =
                new UserRegistration();

            try
            {
                registration.Register("Zuhair", 24);
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine($"Age Error: {ex.Message}");
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(
                    $"Validation Error: {ex.Message}"
                );
            }
            catch (AppException ex)
            {
                Console.WriteLine(
                    $"Application Error: {ex.Message}"
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Unexpected Error: {ex.Message}"
                );
            }
            finally
            {
                Console.WriteLine("Registration process finished.");
            }
        }
    }
}