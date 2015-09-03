using System;
using System.IO;
using Kata.SRP.Common;
using Kata.SRP.Hash;

namespace Kata.SRP.Cifrador
{
    public class SimpleCypher : ISimpleCypher
    {
        private readonly IStringBase64 base64Converter;
        private readonly IStringByte byteConverter;
        private readonly IHashManager hashManager;

        public SimpleCypher(IStringBase64 base64converter, IStringByte byteConverter, IHashManager hashManager)
        {
            this.base64Converter = base64converter;
            this.byteConverter = byteConverter;
            this.hashManager = hashManager;
        }

        public string Encode(string input, string password)
        {
            //Convertir password en bytes
            byte[] pass = this.byteConverter.GetBytes(password);

            //Convertir datos en bytes
            byte[] data = this.byteConverter.GetBytes(input);

            //Convertir bytes de password en clave SHA1 
            byte[] hashValue = this.hashManager.GetHash(pass);

            //Aplicar cifrado con la clave
            byte[] encriptedData = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                int value = data[i] ^ hashValue[i % 32];
                encriptedData[i] = byte.Parse(value.ToString());
            }

            //Convertir bytes en string y devolver         
            string output = this.base64Converter.GetBase64String(encriptedData);
            //this.SaveToFile(output, this.hashManager.GetHash(output));
            return output;
        }

        private void SaveToFile(string encriptedData, string hash)
        {
            string path = @"encriptedText.txt";

            try
            {
                if (!File.Exists(path))
                {
                    File.WriteAllText(path, encriptedData);
                }
                else
                {
                    File.AppendAllText(path, Environment.NewLine);
                    File.AppendAllText(path, Environment.NewLine);
                    File.AppendAllText(path, encriptedData);                
                }

                File.AppendAllText(path, Environment.NewLine);
                File.AppendAllText(path, hash);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public string Decode(string input, string password)
        {
            //Convertir password en bytes
            byte[] pass = this.byteConverter.GetBytes(password);

            //Convertir datos en bytes
            byte[] data = this.base64Converter.GetBytesFromBase64String(input);

            //Convertir bytes de password en clave SHA1 
            byte[] hashValue = this.hashManager.GetHash(pass);

            //Aplicar descifrado con la clave
            byte[] decriptedData = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                int value = data[i] ^ hashValue[i % 32];
                decriptedData[i] = byte.Parse(value.ToString());
            }

            //Convertir bytes en string y devolver         
            string output = this.byteConverter.GetString(decriptedData);
            return output;
        }
    }
}
