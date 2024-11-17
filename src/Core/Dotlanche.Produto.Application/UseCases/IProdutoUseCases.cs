using DotLanche.Produto.Domain.Entities;

namespace Dotlanche.Produto.Application.UseCases;

public interface IProdutoUseCases
{
    Task<RegistroProduto> Add(RegistroProduto produto);
    Task<RegistroProduto> Edit(RegistroProduto produto);
    Task<RegistroProduto> Delete(Guid idProduto);
    Task<IEnumerable<RegistroProduto>> GetByCategoria(int idCategoria);
    Task<IEnumerable<RegistroProduto>> GetOrderProducts(IEnumerable<Guid> orderList);
    Task<RegistroProduto?> GetById(Guid id);
    Task<RegistroProduto?> GetByName(string produtoName);
}