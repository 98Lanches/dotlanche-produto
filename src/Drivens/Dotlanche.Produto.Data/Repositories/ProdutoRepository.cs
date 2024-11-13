using Dotlanche.Produto.Application.Ports;
using Dotlanche.Produto.Data.DatabaseContext;
using Dotlanche.Produto.Data.Exceptions;
using DotLanche.Produto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotlanche.Produto.Data.Repositories;

internal class ProdutoRepository : IProdutoRepository
{
    private readonly ProdutoDbContext _dbContext;

    public ProdutoRepository(ProdutoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(RegistroProduto produto)
    {
        var categoria = await _dbContext.Categoria.FirstOrDefaultAsync(c => c.Id == produto.Categoria.Id) ?? throw new CategoriaNotFoundException();
        produto.Categoria = categoria;
        await _dbContext.Produto.AddAsync(produto);
    }

    public async Task<RegistroProduto> Delete(Guid idProduto)
    {
        var produto = await _dbContext.Produto.FirstOrDefaultAsync(p => p.Id == idProduto) ?? throw new ProdutoNotFoundException();
        _dbContext.Produto.Remove(produto);
        await _dbContext.SaveChangesAsync();
        return produto;
    }

    public async Task<RegistroProduto> Edit(RegistroProduto produto)
    {
        var entity = await _dbContext.Produto.FindAsync(produto.Id) ?? throw new ProdutoNotFoundException();
        _dbContext.Entry(entity).CurrentValues.SetValues(produto);
        await _dbContext.SaveChangesAsync();
        return produto;
    }

    public async Task<IEnumerable<RegistroProduto>> GetByCategoria(int idCategoria)
    {
        return await _dbContext.Produto.Include(p => p.Categoria).Where(c => c.Categoria.Id == idCategoria).ToListAsync();
    }

    public async Task<RegistroProduto?> GetById(Guid idProduto)
    {
        return await _dbContext.Produto.FirstOrDefaultAsync(p => p.Id == idProduto) ?? throw new ProdutoNotFoundException(idProduto);
    }

    public async Task<RegistroProduto?> GetByName(string name)
    {
        return await _dbContext.Produto.FirstOrDefaultAsync(p => p.Name == name) ?? throw new ProdutoNotFoundException();
    }

    public async Task<IEnumerable<RegistroProduto>> GetOrderProducts(IEnumerable<Guid> orderList)
    {
        return await _dbContext.Produto
        .Where(p => orderList.Contains(p.Id))
        .ToListAsync();
    }
}
