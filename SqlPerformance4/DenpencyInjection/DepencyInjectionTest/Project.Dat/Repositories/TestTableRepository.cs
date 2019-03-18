using Project.Data.Entities;
using Project.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YayoiApp.Data.EF;

namespace Project.Data.EF

{
    public class TestTableRepository : EFRepository<TestTable, int>, ITestTableRepository
    {

        public TestTableRepository(AppDbContext context) : base(context)
        {

        }
    }
}
