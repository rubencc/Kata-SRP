﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Kata.SRP.Cifrador
{
    public class SimpleCypher : ISimpleCypher
    {
        public string Encode(string input, string password)
        {
            //Convertir password en bytes
            byte[] pass = this.GetBytes(password);

            //Convertir datos en bytes
            byte[] data = this.GetBytes(input);

            //Convertir bytes de password en clave SHA1 
            SHA256 hashManager = SHA256Managed.Create();
            byte[] hashValue = hashManager.ComputeHash(pass);

            //Aplicar cifrado con la clave
            byte[] encriptedData = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                int value = data[i] ^ hashValue[i % 32];
                encriptedData[i] = byte.Parse(value.ToString());
            }

            //Convertir bytes en string y devolver         
            string output = this.GetBase64String(encriptedData);
            this.SaveToFile(output, this.GetHash(output));
            return output;
        }

        private byte[] GetBytes(string input)
        {
            byte[] output = Encoding.UTF8.GetBytes(input);
            return output;
        }

        private string GetBase64String(byte[] input)
        {
            string output = Convert.ToBase64String(input);
            return output;
        }

        private byte[] GetBytesFromBase64String(string input)
        {
            byte[] output = Convert.FromBase64String(input);
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

        public string GetHash(string input)
        {
            StringBuilder sb = new StringBuilder();
            byte[] data = this.GetBytes(input);
            SHA256 hashManager = SHA256Managed.Create();
            byte[] hashValue = hashManager.ComputeHash(data);

            foreach (Byte b in hashValue)
                sb.Append(b.ToString("x2"));

            return sb.ToString();
        }


        public string Decode(string input, string password)
        {
            //Convertir password en bytes
            byte[] pass = this.GetBytes(password);

            //Convertir datos en bytes
            byte[] data = this.GetBytesFromBase64String(input);

            //Convertir bytes de password en clave SHA1 
            SHA256 hashManager = SHA256Managed.Create();
            byte[] hashValue = hashManager.ComputeHash(pass);

            //Aplicar descifrado con la clave
            byte[] decriptedData = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                int value = data[i] ^ hashValue[i % 32];
                decriptedData[i] = byte.Parse(value.ToString());
            }

            //Convertir bytes en string y devolver         
            string output = Encoding.UTF8.GetString(decriptedData);
            return output;
        }
    }
}
