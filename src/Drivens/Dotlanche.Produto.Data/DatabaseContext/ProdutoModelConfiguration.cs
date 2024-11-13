using DotLanche.Produto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotlanche.Produto.Data.DatabaseContext
{
    internal class ProdutoModelConfiguration : IEntityTypeConfiguration<RegistroProduto>
    {
        public void Configure(EntityTypeBuilder<RegistroProduto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Description).IsRequired();
        }
    }
}
