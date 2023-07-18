using System;
using System.Linq;

namespace UserRegistrationApp
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to User Registration System");
                Console.WriteLine("===================================");

                Console.Write("Enter your name: ");
                string userName = Console.ReadLine();

                Console.Write("Enter your email: ");
                string email = Console.ReadLine();

                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                ValidateInput(userName, email, password);

                // If the input is valid, display success message and insert details
                Console.WriteLine("User registration success!");
                Console.WriteLine("Name: " + userName);
                Console.WriteLine("Email: " + email);
                Console.WriteLine("Password: " + password);

                // Insert the user details into the database or perform any other necessary operations here

            }
            catch (ValidationException ve)
            {
                Console.WriteLine("Validation error: " + ve.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("***Welcome****");
                Console.ReadKey();
            }
        }

        static void ValidateInput(string userName, string email, string password)
        {
            if (string.IsNullOrEmpty(userName) || userName.Length < 4)
            {
                throw new ValidationException("Username must have at least 6 characters.");
            }

            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            {
                throw new ValidationException("Invalid email format.");
            }

            if (string.IsNullOrEmpty(password) || password.Length < 8)
            {
                throw new ValidationException("Password must have at least 8 characters.");
            }
        }
        static bool IsValidEmail(string email)
        {
            // Check for the presence of "@" and "."
            bool containsAtSymbol = email.Contains("@");
            bool containsDotSymbol = email.Contains(".");
            return containsAtSymbol && containsDotSymbol;
        }
    }
}

