namespace Kata.SRP.Common
{
    public interface IStringBase64
    {  
        /// <summary>
        /// Convierte un array de bytes en un string codificado en base64
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string GetBase64String(byte[] input);

        /// <summary>
        /// Convierte un string codificado en base64 en un array de bytes
        /// </summary>
        /// <param name="base64Input"></param>
        /// <returns></returns>
        byte[] GetBytesFromBase64String(string base64Input);       
    }
}
