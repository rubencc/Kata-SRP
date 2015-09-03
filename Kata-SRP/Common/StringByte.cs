using System.Text;

namespace Kata.SRP.Common
{
    public class StringByte : IStringByte
    {
        public byte[] GetBytes(string input)
        {
            byte[] output = Encoding.UTF8.GetBytes(input);
            return output;
        }

        public string GetString(byte[] input)
        {
            return Encoding.UTF8.GetString(input);
        }
    }
}
