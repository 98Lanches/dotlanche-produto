namespace Dotlanche.Produto.Data.Exceptions;

public class ProdutoNotFoundException : Exception
{
    public ProdutoNotFoundException() : base("Produto not found!") { }

    public ProdutoNotFoundException(Guid id) : base($"Produto not found for given id: {id}") { }
}
