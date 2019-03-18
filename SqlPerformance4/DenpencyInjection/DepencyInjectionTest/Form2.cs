using Project.Application.Interfaces;
using Project.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YayoiApp.Utilities.SecurityFunc;

namespace DepencyInjectionTest
{
    public partial class Form2 : Form
    {

        private readonly ITestTableService _testTableService;
        private readonly IYayoiCryptor _yayoiCryptor;
        private string _rawString;

        public Form2(
            IYayoiCryptor yayoiCryptor,
            ITestTableService testTableService
            ) : this()
        {

            _testTableService = testTableService;
            _yayoiCryptor = yayoiCryptor;
        }

        public Form2()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            

            RequestModel requestModel = new RequestModel()
            {
                name = "Le tri",
                value = 3333
            };

            var list = await _testTableService.GetAllBy(requestModel);


            var aesStr = _yayoiCryptor.EncryptData("sdlfkjsdkfjsdlfj", "1234567812345678");
            textBox1.Text = aesStr;
        }
    }
}
