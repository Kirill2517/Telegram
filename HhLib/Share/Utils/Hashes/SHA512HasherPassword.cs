using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HhLib.Share.Utils.Hashes
{
    public class Hasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            string first = GetHash(password).Result;
            return GetHash(first + first.Substring(0, first.Length / 2)).Result;
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (HashPassword(providedPassword).Equals(hashedPassword))
                return PasswordVerificationResult.Success;
            return PasswordVerificationResult.Failed;
        }

        private static async Task<string> GetHash(string input)
        {
            return await Task.Run(() =>
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(input);
                using (var hash = SHA512.Create())
                {
                    var hashedInputBytes = hash.ComputeHash(bytes);
                    var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                    foreach (var b in hashedInputBytes)
                        hashedInputStringBuilder.Append(b.ToString("X2"));
                    return hashedInputStringBuilder.ToString();
                }
            });
        }
    }
}
