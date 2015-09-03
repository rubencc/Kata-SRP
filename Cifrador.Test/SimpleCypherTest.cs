using System;
using Kata.SRP.Cifrador;
using Kata.SRP.Common;
using Kata.SRP.Hash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cifrador.Test
{
    [TestClass]
    public class SimpleCypherTest
    {
        private SimpleCypher simpleCipher;

        [TestInitialize]
        public void Setup()
        {
            this.simpleCipher = new SimpleCypher(new StringBase64(), new StringByte(), new HashManager(new StringByte()));
        }

        [TestMethod]
        public void Cifrar_cadena_vacia()
        {
            string input = String.Empty;
            string password = "11111111111";

            string output = simpleCipher.Encode(input, password);

            Assert.AreEqual(String.Empty, output, "La salida deberia ser una cadena vacia");
        }

        [TestMethod]
        public void Cifrar_cadena()
        {

            string input = "texto de prueba";
            string password = "11111111111";

            string output = simpleCipher.Encode(input, password);

            Assert.AreNotEqual(String.Empty, output, "La salida no deberia ser una cadena vacia");
            Assert.AreEqual("Jy8y+sDt4OyPQkcYPxhE", output, "La salida deberia ser Jy8y+sDt4OyPQkcYPxhE");
        }

        [TestMethod]
        public void Descifrar_cadena()
        {

            string input = "Jy8y+sDt4OyPQkcYPxhE";
            string password = "11111111111";

            string output = simpleCipher.Decode(input, password);

            Assert.AreNotEqual(String.Empty, output, "La salida no deberia ser una cadena vacia");
            Assert.AreEqual("texto de prueba", output, "La salida deberia ser texto de prueba");
        }

        [TestMethod]
        public void Cigrar_y_descifrar_cadena()
        {

            string input = "texto de prueba";
            string password = "11111111111";

            string encodeText = simpleCipher.Encode(input, password);
            string decodeText = simpleCipher.Decode(encodeText, password);

            Assert.AreNotEqual(String.Empty, decodeText, "La salida no deberia ser una cadena vacia");
            Assert.AreEqual(input, decodeText, "La salida deberia ser texto de prueba");
        }
    }
}
