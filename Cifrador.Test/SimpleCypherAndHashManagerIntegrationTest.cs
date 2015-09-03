using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kata.SRP.Cifrador;
using Kata.SRP.Common;
using Kata.SRP.Hash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cifrador.Test
{
    [TestClass]
    public class SimpleCypherAndHashManagerIntegrationTest
    {

        [TestMethod]
        public void Cifrar_cadena_y_obtener_hash()
        {
            SimpleCypher simpleCipher = new SimpleCypher(new StringConverter(), new Sah256HashManager(new StringConverter()));

            string input = "texto de prueba";
            string password = "11111111111";

            string output = simpleCipher.Encode(input, password);

            Assert.AreNotEqual(String.Empty, output, "La salida no deberia ser una cadena vacia");
            Assert.AreEqual("Jy8y+sDt4OyPQkcYPxhE", output, "La salida deberia ser Jy8y+sDt4OyPQkcYPxhE");

            Sah256HashManager hashManager = new Sah256HashManager(new StringConverter());
            string hash = hashManager.GetHash(output);

            Assert.AreEqual(64, hash.Length, "La longitud de un SHA256 no coincide con el formato en hexadecimal de dos elemenos por byte");
            Assert.AreEqual("ea73d3a098d725a0bd5a8106bc17e6b976361ae1d4fc9f53300dc50154fed199", hash, "El hash no coincide");
        }
    }
}
