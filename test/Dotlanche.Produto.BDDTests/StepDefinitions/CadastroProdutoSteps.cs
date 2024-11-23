using Dotlanche.Produto.BDDTests.Setup;
using Dotlanche.Produto.WebApi.DTOs;
using DotLanche.Produto.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using System.Text.Json;

namespace Dotlanche.Produto.BDDTests.StepDefinitions;

[Binding]
public sealed class CadastroProdutoSteps : IDisposable
{
    private readonly HttpClient produtoApiClient;
    private readonly IServiceScope scope;

    private readonly JsonSerializerOptions jsonOptions = new() { PropertyNameCaseInsensitive = true };

    private ProdutoDto produto = new();
    private RegistroProduto response;

    public CadastroProdutoSteps(ProdutoApi produtoApi)
    {
        produtoApiClient = produtoApi.CreateClient();
        scope = produtoApi.Services.CreateScope();
    }

    [Given(@"um produto com nome de ""(.*)"" e com preço de (.*) e com categoria (.*) e com descrição ""(.*)""")]
    public void GivenAProductWithName(string name, decimal price, int categoriaId, string description)
    {
        produto.Name = name;
        produto.Price = price;
        produto.CategoriaId = (ProdutoDto.CategoriaEnum)categoriaId;
        produto.Description = description;
    }

    [When(@"a solicitação de cadastro de produto for enviada")]
    public async Task WhenTheProductIsSubmitted()
    {
        const string endpoint = "Produto";
        var registerProdutoHttpResponse = await produtoApiClient.PostAsJsonAsync(endpoint, produto);
        var responseJson = await registerProdutoHttpResponse.Content.ReadAsStringAsync();
        response = JsonSerializer.Deserialize<RegistroProduto>(responseJson, jsonOptions);
    }

    [Then(@"deve retornar o id do produto")]
    public void ThenReturnTheProductInstanceWithAGeneratedIdGUID()
    {
        response!.Id.Should().NotBeEmpty();
    }

    public void Dispose()
    {
        scope.Dispose();
    }
}
