namespace Kata.SRP.Hash
{
    public interface IHashManager
    {
        string GetHash(string input);
        byte[] Compute(byte[] input);
    }
}
