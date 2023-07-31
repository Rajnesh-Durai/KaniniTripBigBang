using System;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;

namespace BigBangProject.Helpers
{
    public class PasswordHash
    {
        private readonly RNGCryptoServiceProvider _hashcode = new RNGCryptoServiceProvider();
        private readonly int _saltSize;
        private readonly int _hashSize;
        private readonly int _iterations;

        public PasswordHash(IConfiguration configuration)
        {
            _saltSize = int.TryParse(configuration?["PasswordHash:SaltSize"], out int saltSize) ? saltSize : throw new ArgumentException("SaltSize configuration is missing or invalid.");
            _hashSize = int.TryParse(configuration?["PasswordHash:HashSize"], out int hashSize) ? hashSize : throw new ArgumentException("HashSize configuration is missing or invalid.");
            _iterations = int.TryParse(configuration?["PasswordHash:Iterations"], out int iterations) ? iterations : throw new ArgumentException("Iterations configuration is missing or invalid.");
        }

        public string HashPassword(string password)
        {
            byte[] salt;
            _hashcode.GetBytes(salt = new byte[_saltSize]);

            var key = new Rfc2898DeriveBytes(password, salt, _iterations);
            var hash = key.GetBytes(_hashSize);

            var hashBytes = new byte[_saltSize + _hashSize];
            Array.Copy(salt, 0, hashBytes, 0, _saltSize);
            Array.Copy(hash, 0, hashBytes, _saltSize, _hashSize);

            var base64Hash = Convert.ToBase64String(hashBytes);

            return base64Hash;
        }

        public bool VerifyPassword(string password, string base64Hash)
        {
            var hashBytes = Convert.FromBase64String(base64Hash);

            var salt = new byte[_saltSize];
            Array.Copy(hashBytes, 0, salt, 0, _saltSize);

            var key = new Rfc2898DeriveBytes(password, salt, _iterations);

            byte[] hash = key.GetBytes(_hashSize);

            for (var i = 0; i < _hashSize; i++)
            {
                if (hashBytes[i + _saltSize] != hash[i])
                    return false;
            }
            return true;
        }
    }
}
