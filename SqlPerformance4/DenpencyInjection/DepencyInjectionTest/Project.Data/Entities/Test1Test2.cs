using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    [Table("Test1Test2")]
    public class Test1Test2
    {
        public Test1Test2() { }
        //-----------------------------
        //Relationships
        public int TestTable1Id { get; set; }
        [ForeignKey("TestTable1Id")]
        public virtual TestTable1 TestTable1 { get; set; }

        public int TestTable2Id { get; set; }
        [ForeignKey("TestTable2Id")]
        public virtual TestTable2 TestTable2 { get; set; }
    }
}
