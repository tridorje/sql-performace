using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Data.EF;
using Project.Data.Entities;
using Project.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YayoiApp.Infrastructure.Interfaces;

namespace Project.Application.Implementation
{
    public class TestTableService : ITestTableService
    {

        
        private readonly IMapper _mapper;
        private readonly ITestTableRepository _testTableRepository;


        public TestTableService(
            
            IMapper mapper,
            ITestTableRepository testTableRepository
        )
        {
            
            _mapper = mapper;
            _testTableRepository = testTableRepository;
        }



        public void Add(TestTableModel testTableModel)
        {
            var testTable = _mapper.Map<TestTable>(testTableModel);
            _testTableRepository.Add(testTable);
            //await Task.Run(() => _testTableRepository.Add(testTable));
          
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<TestTableModel>> GetAllBy(RequestModel requestModel)
        {

            var query = _testTableRepository.FindAll(x => 
                x.value == requestModel.value 
                && x.name.Equals(requestModel.name));

            var rs = await query.ProjectTo<TestTableModel>(_mapper.ConfigurationProvider).ToListAsync();

            return rs;
        }

        public TestTableModel GetById(int id)
        {
            //throw new NotImplementedException();
            var testTable = _testTableRepository.FindById(id);

            

            var rs = _mapper.Map<TestTable, TestTableModel>(testTable);

            return rs;
        }

        public void Save()
        {

            _testTableRepository.Commit();
        }

        
    }
}
