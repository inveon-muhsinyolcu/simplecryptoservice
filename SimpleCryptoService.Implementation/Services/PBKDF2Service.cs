using SimpleCryptoService.Implementation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCryptoService.Implementation.Services
{
    public class PBKDF2Service : ICryptoService
    {
        public PBKDF2Service()
        {
            //Set default salt size and hashiterations
            HashIterations = 30000;
            SaltSize = 32;
            FormatTypeName = "pbkdf2_sha256";
            SplitterChar = "$";
        }

        public string SplitterChar { get; set; }
        public string FormatTypeName { get; set; }
        public int HashIterations { get; set; }
        public int SaltSize { get; set; }
        public string PlainText { get; set; }
        public string HashedText { get; private set; }
        public string Salt { get; set; }


        public string Compute()
        {
            if (string.IsNullOrEmpty(PlainText)) throw new InvalidOperationException("PlainText cannot be empty");

            if (string.IsNullOrEmpty(Salt))
                GenerateSalt();

            var hashedString = CalculateHash(HashIterations);

            HashedText = $"{FormatTypeName}{SplitterChar}{HashIterations}{SplitterChar}{Salt}{SplitterChar}{hashedString}";

            return HashedText;
        }

        public string Compute(string textToHash)
        {
            PlainText = textToHash;

            Compute();
            return HashedText;
        }
        public string Compute(string textToHash, string salt)
        {
            PlainText = textToHash;
            Salt = salt;

            Compute();
            return HashedText;
        }
        public string GenerateSalt()
        {
            if (SaltSize < 1) throw new InvalidOperationException(string.Format("Cannot generate a salt of size {0}, use a value greater than 1, recommended: 16", SaltSize));

            var rand = RandomNumberGenerator.Create();

            var ret = new byte[SaltSize];

            rand.GetBytes(ret);

            //assign the generated salt in the format of {iterations}.{salt}
            Salt = string.Format("{0}", Convert.ToBase64String(ret));

            return Salt;
        }

        public bool Compare(string passwordHash1, string passwordHash2)
        {
            if (passwordHash1 == null || passwordHash2 == null)
                return false;

            int min_length = Math.Min(passwordHash1.Length, passwordHash2.Length);
            int result = 0;

            for (int i = 0; i < min_length; i++)
                result |= passwordHash1[i] ^ passwordHash2[i];

            return 0 == result;
        }

        private string CalculateHash(int iteration)
        {
            //convert the salt into a byte array
            byte[] saltBytes = Encoding.UTF8.GetBytes(Salt);

            var pbkdf2 = new Rfc2898DeriveBytes(PlainText,
                saltBytes, iteration, HashAlgorithmName.SHA256);
            //pbkdf2.ite
            var key = pbkdf2.GetBytes(SaltSize);
            return Convert.ToBase64String(key);
        }
    }
}
