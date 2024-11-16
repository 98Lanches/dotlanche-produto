using Dotlanche.Produto.Application.Ports;
using Dotlanche.Produto.Application.UseCases;
using DotLanche.Produto.Domain.Entities;

namespace DotLanches.Application.Services;
public class ProdutoUseCases : IProdutoUseCases
{
    private readonly IProdutoRepository _repository;
    public ProdutoUseCases(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<RegistroProduto> Add(RegistroProduto produto) => await _repository.Add(produto);
    public async Task<RegistroProduto> Edit(RegistroProduto produto) => await _repository.Edit(produto);
    public async Task<RegistroProduto> Delete(Guid idProduto) => await _repository.Delete(idProduto);
    public async Task<IEnumerable<RegistroProduto>> GetByCategoria(int idCategoria) => await _repository.GetByCategoria(idCategoria);
    public async Task<IEnumerable<RegistroProduto>> GetOrderProducts(IEnumerable<Guid> orderList) => await _repository.GetByIdList(orderList);
    public async Task<RegistroProduto?> GetById(Guid id) => await _repository.GetById(id);
    public async Task<RegistroProduto?> GetByName(string produtoName) => await _repository.GetByName(produtoName);
}