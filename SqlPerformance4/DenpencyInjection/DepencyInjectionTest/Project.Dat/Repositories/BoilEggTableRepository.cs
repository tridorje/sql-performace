using Project.Dat.IRepositories;
using Project.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YayoiApp.Data.EF;

namespace Project.Dat.Repositories
{
    public class BoilEggTableRepository : EFRepository<EggTable, int>, IBoilEggTableRepository
    {

        public BoilEggTableRepository(AppDbContext context) : base(context)
        {

        }
    }
}
