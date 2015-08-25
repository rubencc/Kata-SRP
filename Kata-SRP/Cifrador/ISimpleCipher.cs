namespace Kata.SRP.Cifrador
{
    public interface ISimpleCipher
    {
        string Cifrar(string input, string password);
        string ObtenerHash(string input);
    }
}
