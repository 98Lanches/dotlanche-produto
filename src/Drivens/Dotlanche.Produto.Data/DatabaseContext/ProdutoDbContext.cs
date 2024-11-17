using DotLanche.Produto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotlanche.Produto.Data.DatabaseContext;

internal class ProdutoDbContext : DbContext
{
    public DbSet<RegistroProduto> Produto { get; set;}
    public DbSet<Categoria> Categoria { get; set;}

    public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CategoriaModelConfiguration().Configure(modelBuilder.Entity<Categoria>());
        new ProdutoModelConfiguration().Configure(modelBuilder.Entity<RegistroProduto>());
    }
}
