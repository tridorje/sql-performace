using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YayoiApp.Infrastructure.SharedKernel;

namespace Project.Data.Entities
{
    [Table("TestTable2")]
    public class TestTable2 : DomainEntity<int>
    {

        public string name { get; set; }
        public int value { get; set; }

        public virtual ICollection<Test1Test2> Test1Test2s { get; set; }

        public TestTable2(
            int id,
            string _name,
            int _value)
        {
            Id = id;
            name = _name;
            value = _value;
        }

        public TestTable2()
        {

        }
    }
}
