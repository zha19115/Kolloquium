using Microsoft.EntityFrameworkCore;

namespace Kolloquium.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
    }
}
