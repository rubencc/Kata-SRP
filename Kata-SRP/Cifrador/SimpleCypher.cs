using Kata.SRP.Common;
using Kata.SRP.Hash;

namespace Kata.SRP.Cifrador
{
    public class SimpleCypher : ISimpleCypher
    {
        private readonly IStringConverter stringConverter;
        private readonly IHashManager hashManager;

        public SimpleCypher(IStringConverter stringConverter, IHashManager hashManager)
        {
            this.stringConverter = stringConverter;
            this.hashManager = hashManager;
        }

        public string Encode(string input, string password)
        {
            //Convertir password en bytes
            byte[] pass = this.stringConverter.GetBytes(password);

            //Convertir datos en bytes
            byte[] data = this.stringConverter.GetBytes(input);

            //Aplicar cifrado con el pass
            byte[] encriptedData = this.CodeAndDecode(data, pass);

            //Convertir bytes en string y devolver         
            string output = this.stringConverter.GetBase64String(encriptedData);
            return output;
        }

        public string Decode(string input, string password)
        {
            //Convertir password en bytes
            byte[] pass = this.stringConverter.GetBytes(password);

            //Convertir datos en bytes
            byte[] data = this.stringConverter.GetBytesFromBase64String(input);

            //Apliar descifrado con el pass
            byte[] encriptedData = this.CodeAndDecode(data, pass);

            //Convertir bytes en string y devolver         
            string output = this.stringConverter.GetString(encriptedData);
            return output;
        }

        private byte[] CodeAndDecode(byte[] data, byte[] pass)
        {
            //Convertir bytes de password en clave SHA1 
            byte[] hashValue = this.hashManager.Compute(pass);

            //Aplicar descifrado con la clave
            byte[] transformedData = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                int value = data[i] ^ hashValue[i % 32];
                transformedData[i] = byte.Parse(value.ToString());
            }

            return transformedData;
        }
    }
}
