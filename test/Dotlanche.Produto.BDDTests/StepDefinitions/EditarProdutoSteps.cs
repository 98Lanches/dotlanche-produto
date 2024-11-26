using Dotlanche.Produto.BDDTests.Setup;
using Dotlanche.Produto.WebApi.DTOs;
using DotLanche.Produto.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using System.Text.Json;

namespace Dotlanche.Produto.BDDTests.StepDefinitions;

[Binding]
public sealed class EditarProdutoSteps : IDisposable
{
    private readonly HttpClient produtoApiClient;
    private readonly IServiceScope scope;

    private readonly JsonSerializerOptions jsonOptions = new() { PropertyNameCaseInsensitive = true };

    public EditarProdutoSteps(ProdutoApi produtoApi)
    {
        produtoApiClient = produtoApi.CreateClient();
        scope = produtoApi.Services.CreateScope();
    }

    [When(@"for solicitado editar produto com id (.*) e valores Nome (.*) e Description (.*) e Price (.*) e idCategoria (.*)")]
    public async Task GivenAProductWithName(Guid idProduto, string name, string description, decimal price, int idCategoria)
    {
        var getProdutoRoute = $"Produto/{idProduto}";
        var produtoDto = new ProdutoDto()
        {
            Name = name,
            Description = description,
            Price = price,
            CategoriaId = (ProdutoDto.CategoriaEnum)idCategoria
        };
        var httpResponse = await produtoApiClient.PutAsJsonAsync<ProdutoDto>(getProdutoRoute, produtoDto);
        ScenarioContext.Current["HttpResponse"] = httpResponse;
        if (httpResponse.IsSuccessStatusCode)
        {
            var produto = await httpResponse.Content.ReadFromJsonAsync<RegistroProduto>(jsonOptions);
            ScenarioContext.Current["RetrievedProduct"] = produto;
        }
    }

    [Then(@"retornar o produto Sobremesa A")]
    public void ThenReturnTheProductDessertA()
    {
        var produto = ScenarioContext.Current["RetrievedProduct"] as RegistroProduto;
        produto.Should().NotBeNull();
        produto!.Name.Should().Be("Sobremesa A");
        produto.Price.Should().Be(20.00m);
        produto.Categoria.Id.Should().Be(4);
    }

    public void Dispose()
    {
        scope.Dispose();
    }
}
