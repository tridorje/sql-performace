using AutoMapper;
using Hr32bit;
using Microsoft.Extensions.Caching.Memory;
using Project.Application.Implementation;
using Project.Application.Interfaces;
using Project.Data.EF;
using Project.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using YayoiApp.Application.AutoMapper;
using YayoiApp.Data.EF;
using YayoiApp.Infrastructure.Interfaces;
using YayoiApp.Utilities.SecurityFunc;
using YayoiApp.Utilities.SecurityFunc.AES;

namespace DepencyInjectionTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            var container = DiContainer.BuildContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(container.Resolve<Form1>());
        }


        
    }
}
