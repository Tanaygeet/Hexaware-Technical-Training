/* Tanaygeet Shrivastava */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Task 4 question 14

namespace PasswordGenerator4._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Desired password length
            int passwordLength = 8; 

            string securePassword = GenerateSecurePassword(passwordLength);

            Console.WriteLine($"Generated Secure Password: {securePassword}");

            Console.ReadKey();      
        }

        // Function to generate a secure password
        static string GenerateSecurePassword(int length)
        {
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string numbers = "0123456789";
            const string specialChars = "!@#$%^&*()_-+=<>?[]{}";

            Random random = new Random();
            StringBuilder passwordBuilder = new StringBuilder();

            passwordBuilder.Append(uppercase[random.Next(uppercase.Length)]);
            passwordBuilder.Append(lowercase[random.Next(lowercase.Length)]);
            passwordBuilder.Append(numbers[random.Next(numbers.Length)]);
            passwordBuilder.Append(specialChars[random.Next(specialChars.Length)]);

            // Add random characters from all categories to fill the remaining length
            string allChars = uppercase + lowercase + numbers + specialChars;
            for (int i = 3; i < length; i++) 
            {
                passwordBuilder.Append(allChars[random.Next(allChars.Length)]);
            }

            return passwordBuilder.ToString();
        }
    }
}
