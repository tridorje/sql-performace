using AutoMapper;
using Hr32bit;
using Microsoft.Extensions.Caching.Memory;
using Project.Application.Implementation;
using Project.Application.Interfaces;
using Project.Dat.IRepositories;
using Project.Dat.Repositories;
using Project.Data.EF;
using Project.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using YayoiApp.Application.AutoMapper;
using YayoiApp.Utilities.SecurityFunc;
using YayoiApp.Utilities.SecurityFunc.AES;
using YayoiApp.Utilities.SecurityFunc.DES;

namespace DepencyInjectionTest
{
    public static class DiContainer
    {

        public static IUnityContainer BuildContainer()
        {
            var currentContainer = new UnityContainer();

            var memoryCache = new MemoryCacheService(new MemoryCacheOptions());
            currentContainer.RegisterInstance<IMemoryCache>(memoryCache);


            var config = AutoMapperConfig.RegisterMappings();
            IMapper mapper = config.CreateMapper();
            currentContainer.RegisterInstance<IMapper>(mapper);

            

            //var appDbContext = new AppDbContext();
            //var eFUnitOfWork = new EFUnitOfWork(appDbContext);
            //currentContainer.RegisterInstance<IUnitOfWork>(eFUnitOfWork);



            currentContainer.RegisterType<ITestTableRepository, TestTableRepository>();

            currentContainer.RegisterType<IBoilEggTableRepository, BoilEggTableRepository>();
            currentContainer.RegisterType<IMohingaService, MohingaService>();
            

            //currentContainer.RegisterType<ITestTableService, TestTableService>();
            currentContainer.RegisterType<ITestTableService, TestTableService1>();
            currentContainer.RegisterType<IYayoiCryptor, AESUtils>();

            //currentContainer.RegisterType<IYayoiCryptor, DES>();

            return currentContainer;
        }
    }
}
