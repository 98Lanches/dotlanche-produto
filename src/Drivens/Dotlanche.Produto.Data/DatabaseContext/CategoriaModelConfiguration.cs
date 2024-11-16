using DotLanche.Produto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotlanche.Produto.Data.DatabaseContext;

internal class CategoriaModelConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();

        builder.HasData(
            new Categoria() { Id = 1, Name = "Lanche" },
            new Categoria() { Id = 2, Name = "Acompanhamento" },
            new Categoria() { Id = 3, Name = "Bebida" },
            new Categoria() { Id = 4, Name = "Sobremesa" }
        );
    }
}
