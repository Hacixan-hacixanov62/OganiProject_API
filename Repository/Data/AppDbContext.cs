using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;

   
    }
}
