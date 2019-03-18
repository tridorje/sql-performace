using Microsoft.Extensions.Caching.Memory;

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace YayoiApp.Utilities.SecurityFunc.DES
{
    public class DES : IYayoiCryptor
    {

        
        private IMemoryCache _cache;
        public DES()
        {

        }
        public DES( IMemoryCache cache)
        {

            _cache = cache;
        }

        public string DecryptData(string data, string pass)
        {
            // Convert encrypted message and password to bytes
            byte[] encryptedMessageBytes = Convert.FromBase64String(data);
            byte[] passwordBytes = ASCIIEncoding.ASCII.GetBytes(pass);

            // Set encryption settings -- Use password for both key and init. vector
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Mode = CipherMode.ECB;
            ICryptoTransform transform = provider.CreateDecryptor(passwordBytes, passwordBytes);
            CryptoStreamMode mode = CryptoStreamMode.Write;

            // Set up streams and decrypt
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memStream, transform, mode);
            cryptoStream.Write(encryptedMessageBytes, 0, encryptedMessageBytes.Length);
            cryptoStream.FlushFinalBlock();

            // Read decrypted message from memory stream
            byte[] decryptedMessageBytes = new byte[memStream.Length];
            memStream.Position = 0;
            memStream.Read(decryptedMessageBytes, 0, decryptedMessageBytes.Length);

            // Encode deencrypted binary data to base64 string
            //string message = Convert.ToBase64String(decryptedMessageBytes);
            string message = ASCIIEncoding.UTF8.GetString(decryptedMessageBytes);
            return message;
        }

        public string EncryptData(string data, string pass)
        {
            // Encode message and password
            byte[] messageBytes = ASCIIEncoding.UTF8.GetBytes(data);
            byte[] passwordBytes = ASCIIEncoding.ASCII.GetBytes(pass);

            // Set encryption settings -- Use password for both key and init. vector
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Mode = CipherMode.ECB;
            ICryptoTransform transform = provider.CreateEncryptor(passwordBytes, passwordBytes);
            CryptoStreamMode mode = CryptoStreamMode.Write;

            // Set up streams and encrypt
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memStream, transform, mode);
            cryptoStream.Write(messageBytes, 0, messageBytes.Length);
            cryptoStream.FlushFinalBlock();

            // Read the encrypted message from the memory stream
            byte[] encryptedMessageBytes = new byte[memStream.Length];
            memStream.Position = 0;
            memStream.Read(encryptedMessageBytes, 0, encryptedMessageBytes.Length);

            // Encode the encrypted message as base64 string
            string encryptedMessage = Convert.ToBase64String(encryptedMessageBytes);

            return encryptedMessage;
        }

        public string GenerateRandomCryptographicKey(int keyLength)
        {
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[keyLength];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        public string GetCacheInMemoryKey(string userName)
        {
            var aesCode = "";

            try
            {
                aesCode = _cache.Get(userName).ToString();
            }
            catch (Exception ex)
            {
                //_logger.LogInformation("error GetCacheInMemoryKey:\n {ex}", ex);
            }

            return aesCode;
        }

        public void SetCacheInMemoryKey(string userName, string passWord)
        {
            try
            {
                _cache.Set(userName, passWord);
            }
            catch (Exception ex)
            {
               // _logger.LogInformation("error SetCacheInMemoryKey:\n {ex}", ex);
            }
        }
    }
}
