namespace Dotlanche.Produto.Data.Exceptions;

internal class CategoriaNotFoundException : Exception
{
    public CategoriaNotFoundException() : base("Categoria not found!") { }
}
