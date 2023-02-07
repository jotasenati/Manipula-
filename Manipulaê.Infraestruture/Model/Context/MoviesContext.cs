using Manipulaê.Infraestruture.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Manipulaê.Infraestruture.Model.Context
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<MoviesEntities> Movies { get; set; }
    }
}
