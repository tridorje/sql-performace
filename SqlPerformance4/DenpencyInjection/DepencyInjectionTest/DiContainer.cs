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
using System.Text;
using System.Threading.Tasks;
using Unity;
using YayoiApp.Application.AutoMapper;
using YayoiApp.Utilities.SecurityFunc;
using YayoiApp.Utilities.SecurityFunc.AES;

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
            currentContainer.RegisterType<ITestTableService, TestTableService>();

            currentContainer.RegisterType<IYayoiCryptor, AESUtils>();
            // note: registering types could be moved off to app config if you want as well
            return currentContainer;
        }
    }
}
