using Fiap.Api.Donation2.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Donation2.Data
{
    public class DataContext : DbContext
    {
        public DbSet<UsuarioModel> Usuario { get; set; }

        public DbSet<CategoriaModel> Categorias { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }
    }
}
