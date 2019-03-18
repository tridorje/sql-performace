using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Data.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YayoiApp.Data.EF;
using YayoiApp.Utilities.SecurityFunc;
using Unity;
using System.Windows.Forms;

namespace DepencyInjectionTest
{
    public partial class Form1 : Form
    {

        private readonly IYayoiCryptor _yayoiCryptor;
        private string _rawString;

        private readonly ITestTableService _testTableService;


        public Form1(
            IYayoiCryptor yayoiCryptor,
            ITestTableService testTableService) : this()
        {

            _testTableService = testTableService;

            


            _yayoiCryptor = yayoiCryptor;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            _rawString = objTextBox.Text;
        }

        private void button1_ClickAsync(object sender, EventArgs e)
        {

            //IDbContext dbContext = new AppDbContext("Server=DESKTOP-OGUS4IV; Database=EfTest; User Id=sa; Password=123;");
            //_testTableService.SetContext(dbContext);

            var temp =  _testTableService.GetById(1);


            var newTest = new TestTableModel()
            {
                ID = 5,
                name = "Le tri",
                value = 3333
            };

            _testTableService.Add(newTest);
            _testTableService.Save();

            var temp1 = _testTableService.GetById(3);

            var aesStr = _yayoiCryptor.EncryptData(_rawString,"12345678");
            textBox2.Text = aesStr;
        }

        private void button2_Click(object sender, EventArgs e)
        {



            var container = DiContainer.BuildContainer();

            Form2 temp = container.Resolve<Form2>();

            temp.ShowDialog();
        }
    }
}
