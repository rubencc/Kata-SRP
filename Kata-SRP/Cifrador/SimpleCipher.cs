﻿using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace Kata.SRP.Cifrador
{
    public class SimpleCipher : ISimpleCipher
    {
        public string Cifrar(string input, string password)
        {
            //Convertir password en bytes
            byte[] pass = this.GetBytes(password);

            //Convertir datos en bytes
            byte[] data = this.GetBytes(input);

            //Convertir bytes de password en clave SHA1 
            SHA256 hash = SHA256Managed.Create();
            byte[] hashValue = hash.ComputeHash(pass);

            //Aplicar cifrado con la clave
            byte[] encriptedData = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                int value = data[i] ^ hashValue[i % 32];
                encriptedData[i] = byte.Parse(value.ToString());
            }

            //Convertir bytes en string y devolver

            string output = this.GetString(encriptedData);
            return output;
        }

        private byte[] GetBytes(string str)
        {
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(str);
            return bytesToBeEncrypted;
        }

        private string GetString(byte[] bytes)
        {
            string output = Convert.ToBase64String(bytes);
            return output;
        }


        public string ObtenerHash(string input)
        {
            StringBuilder sb = new StringBuilder();
            byte[] data = this.GetBytes(input);
            SHA256 hash = SHA256Managed.Create();
            byte[] hashValue = hash.ComputeHash(data);

            foreach (Byte b in hashValue)
                sb.Append(b.ToString("x2"));

            return sb.ToString();
        }
    }
}