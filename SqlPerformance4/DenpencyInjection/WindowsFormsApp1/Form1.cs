using DepencyInjectionTest;
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
using Unity;

namespace WindowsFormsApp1
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

        private void button1_Click(object sender, EventArgs e)
        {
            var temp = _testTableService.GetById(1);


            //var newTest = new TestTableModel()
            //{
            //    ID = 7,
            //    name = "Le tri",
            //    value = 3333
            //};

            //_testTableService.Add(newTest);
            //_testTableService.Save();

            var temp1 = _testTableService.GetById(3);

            var aesStr = _yayoiCryptor.EncryptData(_rawString, "1234567812345678");
            textBox2.Text = aesStr;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var container = DiContainer.BuildContainer();

            SubDiForm temp = container.Resolve<SubDiForm>();

            temp.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            _rawString = objTextBox.Text;
        }
    }
}
