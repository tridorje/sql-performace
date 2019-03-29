using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YayoiApp.Infrastructure.SharedKernel;

namespace Project.Data.Entities
{

    [Table("NoddleTable")]
    public class NoddleTable : DomainEntity<int>
    {

        public string noddleName { get; set; }
        public int value { get; set; }

        public NoddleTable()
        {

        }
    }

    

}
