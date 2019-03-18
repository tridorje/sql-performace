using System;
using System.Collections.Generic;
using System.Text;

namespace YayoiApp.Utilities.SecurityFunc
{
    public interface IYayoiCryptor
    {

        void SetCacheInMemoryKey(String userName, String passWord);
        String GetCacheInMemoryKey(String userName);
        String DecryptData(String data, String pass);
        String EncryptData(String data, String pass);
        string GenerateRandomCryptographicKey(int keyLength);
    }
}
