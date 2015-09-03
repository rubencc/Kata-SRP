namespace Kata.SRP.Common
{
    public interface IStringConverter
    {
        byte[] GetBytes(string input);
        string GetBase64String(byte[] input);
        byte[] GetBytesFromBase64String(string input);
        string GetString(byte[] input);
    }
}
