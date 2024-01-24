﻿using Fiap.Api.Donation1.Models;
using Fiap.Api.Donation2.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Donation2.Data
{
    public class DataContext : DbContext
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<CategoriaModel> Categorias { get; set; }

        public DbSet<ProdutoModel> Produtos { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }
    }
}
