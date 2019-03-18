using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YayoiApp.Infrastructure.SharedKernel;

namespace Project.Data.Entities
{

    [Table("TestTable")]
    public class TestTable : DomainEntity<int>
    {

        
        public string name { get; set; }
        public int value { get; set; }


        public virtual ICollection<TestTable1> TestTable1s { get; set; }

        public TestTable(
            int id,
            string _name,
            int _value)
        {
            Id = id;
            name = _name;
            value = _value;
        }

        public TestTable()
        {

        }
    }
}
