using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace YayoiApp.Application.AutoMapper
{
    public class AutoMapperConfig
    {

        //public static void Configure()
        //{
        //    Mapper.Initialize(cfg =>
        //    {
        //        cfg.AddProfile(new DomainToViewModelMappingProfile());
        //        cfg.AddProfile(new ViewModelToDomainMappingProfile());
        //    });

        //    Mapper.Configuration.AssertConfigurationIsValid();
        //}

        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
