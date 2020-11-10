using MediatrTutorial.Domain;
using Microsoft.EntityFrameworkCore;

namespace MediatrTutorial.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; } = default!;
    }
}