using System;
using Kata.SRP.Cifrador;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cifrador.Test
{
    [TestClass]
    public class SimpleCipherTest
    {
        [TestMethod]
        public void Cifrar_cadena_vacia()
        {
            SimpleCipher simpleCipher = new SimpleCipher();

            string input = String.Empty;
            string password = "11111111111";

            string output = simpleCipher.Cifrar(input, password);

            Assert.AreEqual(String.Empty, output, "La salida deberia ser una cadena vacia");
        }

        [TestMethod]
        public void Cifrar_cadena()
        {
            SimpleCipher simpleCipher = new SimpleCipher();

            string input = "texto de prueba";
            string password = "11111111111";

            string output = simpleCipher.Cifrar(input, password);

            Assert.AreNotEqual(String.Empty, output, "La salida no deberia ser una cadena vacia");
            Assert.AreEqual("Jy8y+sDt4OyPQkcYPxhE", output, "La salida deberia ser Jy8y+sDt4OyPQkcYPxhE");
        }

        [TestMethod]
        public void Cifrar_cadena_y_obtener_hash()
        {
            SimpleCipher simpleCipher = new SimpleCipher();

            string input = "texto de prueba";
            string password = "11111111111";

            string output = simpleCipher.Cifrar(input, password);

            Assert.AreNotEqual(String.Empty, output, "La salida no deberia ser una cadena vacia");
            Assert.AreEqual("Jy8y+sDt4OyPQkcYPxhE", output, "La salida deberia ser Jy8y+sDt4OyPQkcYPxhE");

            string hash = simpleCipher.ObtenerHash(output);

            Assert.AreEqual(64, hash.Length, "La longitud de un SHA256 no coincide con el formato en hexadecimal de dos elemenos por byte");
            Assert.AreEqual("ea73d3a098d725a0bd5a8106bc17e6b976361ae1d4fc9f53300dc50154fed199", hash, "El hash no coincide");
        }

        [TestMethod]
        public void Obtener_hash_de_una_cadena_vacia()
        {
            SimpleCipher simpleCipher = new SimpleCipher();

            string input = String.Empty;
            string hash = simpleCipher.ObtenerHash(input);

            Assert.AreEqual(64, hash.Length, "La longitud de un SHA256 no coincide con el formato en hexadecimal de dos elemenos por byte");
            Assert.AreEqual("e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", hash, "El hash no coincide");
        }

        [TestMethod]
        public void Obtener_hash_de_una_cadena()
        {
            SimpleCipher simpleCipher = new SimpleCipher();

            string input = "texto de prueba";
            string hash = simpleCipher.ObtenerHash(input);

            Assert.AreEqual(64, hash.Length, "La longitud de un SHA256 no coincide con el formato en hexadecimal de dos elemenos por byte");
            Assert.AreEqual("af297c87191fb56d612ddeaabbb93a70da1f8e407cc7037f043480dc6c670db0", hash, "El hash no coincide");
        }
    }
}
