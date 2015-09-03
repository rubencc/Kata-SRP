namespace Kata.SRP.Hash
{
    public interface IHashManager
    {
        /// <summary>
        /// Devuelve el hash de una cadena
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string GetHash(string input);

        /// <summary>
        /// Devuelve el hash de un array de bytes
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        byte[] GetHash(byte[] input);
    }
}
