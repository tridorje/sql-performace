using AutoMapper;
using Project.Application.ViewModels;
using Project.Data.Entities;


namespace YayoiApp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            
            CreateMap<TestTableModel, TestTable>()
            .ConstructUsing(c => new TestTable(c.ID,c.name,c.value));

        }
    }
}
