using CrudDesafio.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudDesafio.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<RepositorioModel> Repositorio { get; set; }

    }
}
