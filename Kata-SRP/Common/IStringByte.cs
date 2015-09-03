namespace Kata.SRP.Common
{
    public interface IStringByte
    {
        /// <summary>
        /// Convierte un string en un array de bytes
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        byte[] GetBytes(string input);

        /// <summary>
        /// Convierte un array de bytes en una cadena codificada en UTF8
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string GetString(byte[] input);
    }
}
