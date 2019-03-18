using Microsoft.Extensions.Caching.Memory;

using System;

using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace YayoiApp.Utilities.SecurityFunc.AES
{
    public class AESUtils : IYayoiCryptor
    {

        //private readonly ILogger<IAESUtils> _logger;
        public IMemoryCache _cache;



        public string GenerateRandomCryptographicKey(int keyLength)
        {
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[keyLength];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        public AESUtils(IMemoryCache cache)
        {

            _cache = cache;
        }

        public String DecryptData(String data, String pass)
        {
            Byte[] outputBytes = Convert.FromBase64String(data);

            string plaintext = string.Empty;

            try
            {

                AesManaged myAes = new AesManaged();

                // Override the cipher mode, key and IV
                myAes.Mode = CipherMode.CBC;
                myAes.IV = new byte[16] { 0x10, 0x16, 0x1F, 0xAD, 0x10, 0x10, 0xAA, 0x22, 0x12, 0x51, 0xF1, 0x1E, 0x15, 0x11, 0x1B, 0x10 }; // must be the same as in objective-c
                myAes.Key = Encoding.UTF8.GetBytes(pass);
                //CipherKey;  // Byte array representing the key
                myAes.Padding = PaddingMode.PKCS7;

                // Create a encryption object to perform the stream transform.
                ICryptoTransform encryptor = myAes.CreateDecryptor();


                using (MemoryStream memoryStream = new MemoryStream(outputBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(cryptoStream))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {


            }

            return plaintext;
        }

        public String EncryptData(String data, String pass)
        {
            string resultStr = string.Empty;

            try
            {
                // Create a new instance of the AesManaged class.  This generates a new key and initialization vector (IV).
                AesManaged myAes = new AesManaged();

                // Override the cipher mode, key and IV
                myAes.Mode = CipherMode.CBC;
                myAes.IV = new byte[16] { 0x10, 0x16, 0x1F, 0xAD, 0x10, 0x10, 0xAA, 0x22, 0x12, 0x51, 0xF1, 0x1E, 0x15, 0x11, 0x1B, 0x10 }; // must be the same as in objective-c
                myAes.Key = Encoding.UTF8.GetBytes(pass);
                //CipherKey;  // Byte array representing the key
                myAes.Padding = PaddingMode.PKCS7;

                // Create a encryption object to perform the stream transform.
                ICryptoTransform encryptor = myAes.CreateEncryptor();

                // perform the encryption as required...
                MemoryStream ms = new MemoryStream();
                CryptoStream ct = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
                byte[] binput = Encoding.UTF8.GetBytes(data);
                ct.Write(binput, 0, binput.Length);
                ct.Close();
                byte[] result = ms.ToArray();

                resultStr = Convert.ToBase64String(result);

            }
            catch (Exception ex)
            {
                // TODO: Log the error 


            }
            return resultStr;
        }

        public void SetCacheInMemoryKey(string userName, string passWord)
        {
            try
            {
                _cache.Set(userName, passWord);
            }
            catch (Exception ex)
            {

            }
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

            }

            return aesCode;
        }
    }
}
