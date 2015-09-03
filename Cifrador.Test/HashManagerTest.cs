using System;
using Kata.SRP.Common;
using Kata.SRP.Hash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cifrador.Test
{
    [TestClass]
    public class HashManagerTest
    {
        private HashManager hashManager;

        [TestInitialize]
        public void Setup()
        {
            this.hashManager = new HashManager(new StringByte());
        }

        [TestMethod]
        public void Obtener_hash_de_una_cadena_vacia()
        {

            string input = String.Empty;
            string hash = hashManager.GetHash(input);

            Assert.AreEqual(64, hash.Length, "La longitud de un SHA256 no coincide con el formato en hexadecimal de dos elemenos por byte");
            Assert.AreEqual("e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", hash, "El hash no coincide");
        }

        [TestMethod]
        public void Obtener_hash_de_una_cadena()
        {

            string input = "texto de prueba";
            string hash = hashManager.GetHash(input);

            Assert.AreEqual(64, hash.Length, "La longitud de un SHA256 no coincide con el formato en hexadecimal de dos elemenos por byte");
            Assert.AreEqual("af297c87191fb56d612ddeaabbb93a70da1f8e407cc7037f043480dc6c670db0", hash, "El hash no coincide");
        }
    }
}
