namespace Kata.SRP.Cifrador
{
    public interface ISimpleCypher
    {
        string Encode(string input, string password);
        string Decode(string input, string password);
    }
}
