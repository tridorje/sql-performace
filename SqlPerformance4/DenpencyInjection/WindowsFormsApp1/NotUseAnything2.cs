using Hr32bit;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YayoiApp.Utilities.SecurityFunc.AES;
using YayoiApp.Utilities.SecurityFunc.DES;

namespace WindowsFormsApp1
{
    public partial class NotUseAnything2 : Form
    {
        private readonly DES _yayoiCryptor;
        private readonly AESUtils _yayoiCryptor2;
        private readonly AESUtils _yayoiCryptor3;


        private string _rawString;

        public NotUseAnything2()
        {

            var memoryCache = new MemoryCacheService(new MemoryCacheOptions());
            _yayoiCryptor = new DES(memoryCache);


            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var aesStr = _yayoiCryptor.EncryptData("sfdsdfsdfs", "1234567812345678");
        }
    }
}
