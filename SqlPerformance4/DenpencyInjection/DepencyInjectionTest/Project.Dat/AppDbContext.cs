




using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.Data.EF;
using Project.Data.Entities;
using System;



//using YayoiApp.Data.EF.Configurations;
using System.Linq;



namespace YayoiApp.Data.EF
{
    public class AppDbContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-OGUS4IV; Database=EfTest; User Id=sa; Password=123;")
            .EnableSensitiveDataLogging(true)
            .UseLoggerFactory(new LoggerFactory().AddConsole((category, level) => level == LogLevel.Information && category == DbLoggerCategory.Database.Command.Name, true));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //map table to model
            builder.Entity<TestTable>().ToTable("TestTable")
               .HasKey(x => new { x.Id });

            //many to many configuration
            builder.Entity<Test1Test2>().ToTable("Test1Test2")
                .HasKey(x => new { x.TestTable1Id, x.TestTable2Id });

        }

        public DbSet<TestTable> TestTable { get; set; }
        public DbSet<TestTable1> TestTable1 { get; set; }
        public DbSet<TestTable2> TestTable2 { get; set; }
        public DbSet<Test1Test2> Test1Test2 { get; set; }
        public DbSet<EggTable> EggTable { get; set; }
        public DbSet<NoddleTable> NoddleTable { get; set; }

        

    }
   

}
