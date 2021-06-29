using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace DesafioFull.CrossCutting.Security
{
    public static class Cryptography
    {
        public static string Hash(string value)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = KeyDerivation.Pbkdf2(
                password: value,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);

            return GetHashNewArray(hash, salt);
        }

        public static string HashWithDatabaseValue(string value, string hashDatabase)
        {
            byte[] hashBytes = Convert.FromBase64String(hashDatabase);
            byte[] salt = new byte[128 / 8];
            Array.Copy(hashBytes, 0, salt, 0, salt.Length);

            byte[] hash = KeyDerivation.Pbkdf2(
                password: value,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);

            return GetHashNewArray(hash, salt);
        }

        private static string GetHashNewArray(byte[] hash, byte[] salt)
        {
            byte[] result = new byte[hash.Length + salt.Length];

            Array.Copy(salt, 0, result, 0, salt.Length);
            Array.Copy(hash, 0, result, salt.Length, hash.Length);

            return Convert.ToBase64String(result);
        }
    }
}
