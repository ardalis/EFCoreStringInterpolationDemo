using Microsoft.EntityFrameworkCore;

namespace EFCoreTester
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\v11.0;Database=NORTHWIND;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
