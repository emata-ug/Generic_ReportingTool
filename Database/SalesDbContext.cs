using Domain.Sales;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class SalesDbContext : DbContext
    {
        public DbSet<Sale> Sales { get; set; }

        public SalesDbContext(DbContextOptions<SalesDbContext> options) 
            : base(options)
        {

        }
    }
}
