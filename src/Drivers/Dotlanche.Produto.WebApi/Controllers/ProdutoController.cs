using Dotlanche.Produto.Application.UseCases;
using Dotlanche.Produto.Data.Exceptions;
using Dotlanche.Produto.WebApi.DTOs;
using Dotlanche.Produto.WebApi.Mappers;
using DotLanche.Produto.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Dotlanche.Produto.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoUseCases _services;

    public ProdutoController(IProdutoUseCases services)
    {
        _services = services;
    }

    /// <summary>
    /// Cria um novo produto
    /// </summary>
    /// <param name="produtoDto">Dados do novo produto</param>
    /// <returns>Produto criado</returns>
    [HttpPost]
    [ProducesResponseType(typeof(RegistroProduto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] ProdutoDto produtoDto)
    {
        var id = Guid.NewGuid();
        var newProduto = await _services.Add(produtoDto.ToDomainModel(id));

        return StatusCode(StatusCodes.Status201Created, newProduto);
    }

    /// <summary>
    /// Atualiza um produto existente
    /// </summary>
    /// <param name="idProduto">ID do produto a ser atualizado</param>
    /// <param name="produtoDto">Novos dados do produto</param>
    /// <returns>Produto atualizado</returns>
    [HttpPut("{idProduto}")]
    [ProducesResponseType(typeof(RegistroProduto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] Guid idProduto, [FromBody] ProdutoDto produtoDto)
    {
        try
        {
            var produto = await _services.Edit(produtoDto.ToDomainModel(idProduto));
            return Ok(produto);
        }
        catch (ProdutoNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Remove um produto
    /// </summary>
    /// <param name="idProduto">ID do produto a ser removido</param>
    /// <returns>Produto removido</returns>
    [HttpDelete("{idProduto}")]
    [ProducesResponseType(typeof(RegistroProduto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid idProduto)
    {
        try
        {
            var produto = await _services.Delete(idProduto);
            return Ok(produto);
        }
        catch (ProdutoNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Busca produtos pertencentes a uma categoria
    /// </summary>
    /// <param name="idCategoria">ID da categoria a ser buscada</param>
    /// <returns>Lista de produtos que pertencem a categoria informada</returns>
    [HttpGet("categoria")]
    [ProducesResponseType(typeof(IEnumerable<RegistroProduto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByCategoria([Required][FromQuery] int idCategoria)
    {
        var produtoList = await _services.GetByCategoria(idCategoria);
        return Ok(produtoList);
    }

    /// <summary>
    /// Busca produtos pelo Id
    /// </summary>
    /// <param name="idProduto">Id do produto a ser buscado</param>
    /// <returns>Produto pelo Id</returns>
    [HttpGet("{idProduto}")]
    [ProducesResponseType(typeof(RegistroProduto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([Required][FromRoute] Guid idProduto)
    {
        try
        {
            var produto = await _services.GetById(idProduto);
            return Ok(produto);
        }
        catch (ProdutoNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Busca produtos pelo nome
    /// </summary>
    /// <param name="nomeProduto">Nome do produto a ser buscado</param>
    /// <returns>Produto pelo nome</returns>
    [HttpGet("nome")]
    [ProducesResponseType(typeof(RegistroProduto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([Required][FromQuery] string nomeProduto)
    {
        try
        {
            var produto = await _services.GetByName(nomeProduto);
            return Ok(produto);
        }
        catch (ProdutoNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Busca produtos pelo Id
    /// </summary>
    /// <param name="orderList">Lista de Ids dos produtos a serem buscado, separados por vírgula</param>
    /// <returns>Lista de produtos pelo Id</returns>
    [HttpGet]
    [ProducesResponseType(typeof(RegistroProduto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetOrderList([Required][FromQuery] string orderList)
    {
        if (string.IsNullOrEmpty(orderList))
            return BadRequest("Order list cannot be empty.");

        var orderIds = orderList.Split(',')
                                .Select(id => Guid.TryParse(id, out var guid) ? guid : (Guid?)null)
                                .Where(guid => guid.HasValue)
                                .Select(guid => guid.Value)
                                .ToList();

        if (!orderIds.Any())
            return BadRequest("Invalid IDs in order list.");

        var produtoList = await _services.GetOrderProducts(orderIds);
        return Ok(produtoList);
    }
}