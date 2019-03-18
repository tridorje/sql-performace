
using Project.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.EF
{
    public interface IDbContext : IDisposable
    {

        DbSet<TestTable> TestTable { get; set; }
    }
}
