using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.IO;

namespace Infotainment.Data.Crypto
{
    public class RSACrypto : IDisposable
    {
        public static RSACrypto Instance
        {
            get { return new RSACrypto(); }
        }

        private RSACryptoServiceProvider RSA
        {
            get { return new RSACryptoServiceProvider(); }
        }

        private string RSAKey
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("RSAPrivateKey");
            }
        }

        public string Encrypt(string Text)
        {
            return Encryption(Encryption(Text));
        }
        public string Decrypt(string Text)
        {
            return Decryption(Decryption(Text));
        }

        private string Encryption(string Text)
        {
            //var plaintext = Encoding.ASCII.GetBytes(Text);
            //var encryptedText = Encrypt(plaintext, RSA.ExportParameters(false), false);
            //return ASCIIEncoding.ASCII.GetString(encryptedText);

            var ms = new MemoryStream();
            using (var des = new DESCryptoServiceProvider())
            {
                byte[] byKey = Encoding.UTF8.GetBytes(RSAKey.Substring(0, 8));
                byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
                using (var cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write))
                {
                    var inputByteArray = Encoding.UTF8.GetBytes(Text);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                };
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        private string Decryption(string Text)
        {
            //var plaintext = Encoding.ASCII.GetBytes(Text);
            //var encryptedText = Decrypt(plaintext, RSA.ExportParameters(false), false);
            //return ASCIIEncoding.ASCII.GetString(encryptedText);

            var ms = new MemoryStream();
            using (var des = new DESCryptoServiceProvider())
            {
                byte[] byKey = Encoding.UTF8.GetBytes(RSAKey.Substring(0, 8));
                byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
                using (var cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write))
                {
                   var inputByteArray = Convert.FromBase64String(Text.Replace(" ", "+"));
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                }
            }

            return Encoding.UTF8.GetString(ms.ToArray());
        }

        #region /// Encryption & Decruption
        private byte[] Encrypt(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            //var ByteConverter = new UnicodeEncoding();
            try
            {
                byte[] encryptedData;
                using (var rsa = new RSACryptoServiceProvider())
                {
                    rsa.ImportParameters(RSAKey);
                    encryptedData = rsa.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        private byte[] Decrypt(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            var ByteConverter = new UnicodeEncoding();
            try
            {
                byte[] decryptedData;
                using (var rsa = new RSACryptoServiceProvider())
                {
                    rsa.ImportParameters(RSAKey);
                    decryptedData = rsa.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #endregion

        #region Memory
        private bool disposed = false;
        ~RSACrypto()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }


                disposed = true;
            }
        }
        #endregion
    }
}

