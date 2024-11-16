using DotLanche.Produto.Domain.Entities;

namespace Dotlanche.Produto.Application.Ports;

public interface IProdutoRepository
{
    public Task<RegistroProduto> Add(RegistroProduto produto);
    public Task<RegistroProduto> Edit(RegistroProduto produto);
    public Task<RegistroProduto> Delete(Guid idProduto);
    public Task<IEnumerable<RegistroProduto>> GetByCategoria(int idCategoria);
    public Task<IEnumerable<RegistroProduto>> GetByIdList(IEnumerable<Guid> orderList);
    public Task<RegistroProduto?> GetById(Guid idProduto);
    public Task<RegistroProduto?> GetByName(string name);
}