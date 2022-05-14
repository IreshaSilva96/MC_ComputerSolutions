using MC_ComputerSolutions.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC_ComputerSolutions
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceProducts> InvoiceProducts { get; set; }



        public IEnumerable<object> GetUnitByRFIDDTO { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder build)
        {

            string SQLConnectionString = "Server=DESKTOP-NREBFKV;Database=MC_ComputerSolutions;Trusted_Connection=true;";

            build.UseSqlServer(SQLConnectionString);

            base.OnConfiguring(build);
        }

    }
}
