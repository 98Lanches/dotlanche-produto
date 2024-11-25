using DotLanche.Produto.Domain.Entities;

namespace Dotlanche.Produto.BDDTests.DataTableObjects;

internal class ProdutoDataTableObject
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Categoria Categoria { get; set; }
}
