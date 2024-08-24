using Kolloquium.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kolloquium.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

    }
}
