using Project.Application.Interfaces;
using Project.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Implementation
{
    public class TestTableService1 : ITestTableService
    {
        public void Add(TestTableModel testTableModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<List<TestTableModel>> GetAllBy(RequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public TestTableModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
