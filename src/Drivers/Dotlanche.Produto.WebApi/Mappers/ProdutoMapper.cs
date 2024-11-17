using DotLanche.Produto.Domain.Entities;
using Dotlanche.Produto.WebApi.DTOs;

namespace Dotlanche.Produto.WebApi.Mappers;

public static class ProdutoMapper
{
    public static RegistroProduto ToDomainModel(this ProdutoDto produtoDto, Guid id)
    {
        var domainModel = new RegistroProduto(id,
                                            produtoDto.Name,
                                            produtoDto.Description,
                                            produtoDto.Price,
                                            new Categoria() { Id = (int)produtoDto.CategoriaId });
        return domainModel;
    }
}
