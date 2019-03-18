using AutoMapper;
using Project.Application.ViewModels;
using Project.Data.Entities;


namespace YayoiApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            

            CreateMap<TestTable, TestTableModel>();

            
        }
    }
}
