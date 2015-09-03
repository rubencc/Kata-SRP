namespace Kata.SRP.Cifrador
{
    public interface ISimpleCypher
    {
        /// <summary>
        /// Codifica una cadena
        /// </summary>
        /// <param name="input"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        string Encode(string input, string password);

        /// <summary>
        /// Decodifica una cadena
        /// </summary>
        /// <param name="input"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        string Decode(string input, string password);
    }
}
