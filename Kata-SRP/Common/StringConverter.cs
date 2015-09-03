using System;
using System.Text;

namespace Kata.SRP.Common
{
    public class StringConverter : IStringConverter
    {
        public byte[] GetBytes(string input)
        {
            byte[] output = Encoding.UTF8.GetBytes(input);
            return output;
        }

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

        public string GetString(byte[] input)
        {
            return Encoding.UTF8.GetString(input);
        }
    }
}
