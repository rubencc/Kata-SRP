using System;
using Kata.SRP.Cifrador;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cifrador.Test
{
    [TestClass]
    public class SimpleCypherTest
    {
        [TestMethod]
        public void Cifrar_cadena_vacia()
        {
            SimpleCypher simpleCipher = new SimpleCypher();

            string input = String.Empty;
            string password = "11111111111";

            string output = simpleCipher.Encode(input, password);

            Assert.AreEqual(String.Empty, output, "La salida deberia ser una cadena vacia");
        }

        [TestMethod]
        public void Cifrar_cadena()
        {
            SimpleCypher simpleCipher = new SimpleCypher();

            string input = "texto de prueba";
            string password = "11111111111";

            string output = simpleCipher.Encode(input, password);

            Assert.AreNotEqual(String.Empty, output, "La salida no deberia ser una cadena vacia");
            Assert.AreEqual("Jy8y+sDt4OyPQkcYPxhE", output, "La salida deberia ser Jy8y+sDt4OyPQkcYPxhE");
        }

        [TestMethod]
        public void Descifrar_cadena()
        {
            SimpleCypher simpleCipher = new SimpleCypher();

            string input = "Jy8y+sDt4OyPQkcYPxhE";
            string password = "11111111111";

            string output = simpleCipher.Decode(input, password);

            Assert.AreNotEqual(String.Empty, output, "La salida no deberia ser una cadena vacia");
            Assert.AreEqual("texto de prueba", output, "La salida deberia ser texto de prueba");
        }

        [TestMethod]
        public void Cigrar_y_descifrar_cadena()
        {
            SimpleCypher simpleCipher = new SimpleCypher();

            string input = "texto de prueba";
            string password = "11111111111";

            string encodeText = simpleCipher.Encode(input, password);
            string decodeText = simpleCipher.Decode(encodeText, password);

            Assert.AreNotEqual(String.Empty, decodeText, "La salida no deberia ser una cadena vacia");
            Assert.AreEqual(input, decodeText, "La salida deberia ser texto de prueba");
        }

        [TestMethod]
        public void Cifrar_cadena_y_obtener_hash()
        {
            SimpleCypher simpleCipher = new SimpleCypher();

            string input = "texto de prueba";
            string password = "11111111111";

            string output = simpleCipher.Encode(input, password);

            Assert.AreNotEqual(String.Empty, output, "La salida no deberia ser una cadena vacia");
            Assert.AreEqual("Jy8y+sDt4OyPQkcYPxhE", output, "La salida deberia ser Jy8y+sDt4OyPQkcYPxhE");

            string hash = simpleCipher.GetHash(output);

            Assert.AreEqual(64, hash.Length, "La longitud de un SHA256 no coincide con el formato en hexadecimal de dos elemenos por byte");
            Assert.AreEqual("ea73d3a098d725a0bd5a8106bc17e6b976361ae1d4fc9f53300dc50154fed199", hash, "El hash no coincide");
        }

        [TestMethod]
        public void Obtener_hash_de_una_cadena_vacia()
        {
            SimpleCypher simpleCipher = new SimpleCypher();

            string input = String.Empty;
            string hash = simpleCipher.GetHash(input);

            Assert.AreEqual(64, hash.Length, "La longitud de un SHA256 no coincide con el formato en hexadecimal de dos elemenos por byte");
            Assert.AreEqual("e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", hash, "El hash no coincide");
        }

        [TestMethod]
        public void Obtener_hash_de_una_cadena()
        {
            SimpleCypher simpleCipher = new SimpleCypher();

            string input = "texto de prueba";
            string hash = simpleCipher.GetHash(input);

            Assert.AreEqual(64, hash.Length, "La longitud de un SHA256 no coincide con el formato en hexadecimal de dos elemenos por byte");
            Assert.AreEqual("af297c87191fb56d612ddeaabbb93a70da1f8e407cc7037f043480dc6c670db0", hash, "El hash no coincide");
        }
    }
}
