using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infotainment.Data.Crypto;

namespace UnitTest
{
    [TestClass]
    public class CryptoTest
    {
        [TestMethod]
        public void Encryption()
        {
            string text = "newsPa$$word@123";
            string encrypt = RSACrypto.Instance.Encrypt(text);
            Assert.IsTrue(text == RSACrypto.Instance.Decrypt(encrypt));
        }
    }
}
