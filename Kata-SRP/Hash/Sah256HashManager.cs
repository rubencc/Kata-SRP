using System;
using System.Security.Cryptography;
using System.Text;
using Kata.SRP.Common;

namespace Kata.SRP.Hash
{
    public class Sah256HashManager : IHashManager
    {
        private readonly IStringConverter stringConverter;

        public Sah256HashManager(IStringConverter stringConverter)
        {
            this.stringConverter = stringConverter;
        }

        public string GetHash(string input)
        {
            StringBuilder sb = new StringBuilder();
            byte[] data = this.stringConverter.GetBytes(input);
            SHA256 hashManager = SHA256Managed.Create();
            byte[] hashValue = hashManager.ComputeHash(data);

            foreach (Byte b in hashValue)
                sb.Append(b.ToString("x2"));

            return sb.ToString();
        }


        public byte[] Compute(byte[] input)
        {
            SHA256 hashManager = SHA256Managed.Create();
            byte[] hashValue = hashManager.ComputeHash(input);

            return hashValue;
        }
    }
}
