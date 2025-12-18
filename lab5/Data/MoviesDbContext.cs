using Microsoft.EntityFrameworkCore;
using lab5.Models;

namespace lab5.Data
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
            : base(options)
        {
        }
    }
}
