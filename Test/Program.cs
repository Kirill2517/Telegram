using Microsoft.AspNet.Identity;
using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string value = new SHA512HasherPassword().HashPassword("password");
        Console.WriteLine(value);
        System.Console.WriteLine(new SHA512HasherPassword().VerifyHashedPassword(value, "password"));
    }

    public class SHA512HasherPassword : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            string first = SHA512(password);
            string input = first + first.Substring(0, first.Length / 2);
            return SHA512(input);
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (HashPassword(providedPassword).Equals(hashedPassword))
                return PasswordVerificationResult.Success;
            return PasswordVerificationResult.Failed;
        }

        private static string SHA512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
    }
}