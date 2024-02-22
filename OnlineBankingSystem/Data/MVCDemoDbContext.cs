using Microsoft.EntityFrameworkCore;
using OnlineBankingSystem.Models.Domain;

namespace OnlineBankingSystem.Data
{
    public class MVCDemoDbContext : DbContext
    {
        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
