using Project.Application.ViewModels;
using Project.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Interfaces
{
    public interface ITestTableService : IDisposable
    {

        Task<List<TestTableModel>> GetAllBy(RequestModel requestModel);
        TestTableModel GetById(int id);
        void Add(TestTableModel testTableModel);
        void Save();
        
    }
}
