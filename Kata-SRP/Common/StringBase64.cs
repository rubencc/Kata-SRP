using System;

namespace Kata.SRP.Common
{
    public class StringBase64 : IStringBase64
    {
        public string GetBase64String(byte[] input)
        {
            string output = Convert.ToBase64String(input);
            return output;
        }

        public byte[] GetBytesFromBase64String(string input)
        {
            byte[] output = Convert.FromBase64String(input);
            return output;
        }
    }
}
