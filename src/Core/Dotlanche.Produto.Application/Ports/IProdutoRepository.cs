using DotLanche.Produto.Domain.Entities;

namespace DotLanche.Produto.Application.Ports.Repositories;

public interface IProdutoRepository
{
    public Task<int> Add(RegistroProduto produto);
    public Task<RegistroProduto> Edit(RegistroProduto produto);
    public Task<RegistroProduto> Delete(int idProduto);
    public Task<IEnumerable<RegistroProduto>> GetByCategoria(int idCategoria);
    public Task<IEnumerable<RegistroProduto>> GetOrderProducts(IEnumerable<Guid> orderList);
    public Task<RegistroProduto?> GetById(Guid idProduto);
    public Task<RegistroProduto?> GetByName(string name);
}