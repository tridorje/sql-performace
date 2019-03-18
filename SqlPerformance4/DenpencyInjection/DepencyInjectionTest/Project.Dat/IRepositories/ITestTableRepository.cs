using Project.Data.EF;
using Project.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YayoiApp.Infrastructure.Interfaces;

namespace Project.Data.IRepositories
{
    public interface ITestTableRepository : IRepository<TestTable, int>
    {
        
    }
}
