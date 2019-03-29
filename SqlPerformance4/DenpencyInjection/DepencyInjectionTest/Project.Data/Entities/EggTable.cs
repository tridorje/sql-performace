using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YayoiApp.Infrastructure.SharedKernel;

namespace Project.Data.Entities
{

    [Table("EggTable")]
    public class EggTable : DomainEntity<int>
    {

        public string name { get; set; }
        public int value { get; set; }

        public EggTable()
        {

        }
    }
}
