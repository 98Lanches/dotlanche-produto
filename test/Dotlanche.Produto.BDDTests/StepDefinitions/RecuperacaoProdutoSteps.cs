using Dotlanche.Produto.BDDTests.Setup;
using DotLanche.Produto.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Dotlanche.Produto.Data.DatabaseContext;
using Dotlanche.Produto.Data.Exceptions;
using System.Net;
using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;

namespace Dotlanche.Produto.BDDTests.StepDefinitions;

[Binding]
public sealed class RecuperacaoProdutoSteps : IDisposable
{
    private readonly HttpClient produtoApiClient;
    private readonly JsonSerializerOptions jsonOptions = new() { PropertyNameCaseInsensitive = true };
    private readonly IServiceScope scope;

    public RecuperacaoProdutoSteps(ProdutoApi produtoApi)
    {
        produtoApiClient = produtoApi.CreateClient();
        scope = produtoApi.Services.CreateScope();
    }

    [Given(@"produtos cadastrado:")]
    public async Task GivenProductsAreRegistered(Table produtosTable)
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ProdutoDbContext>();
        var produtos = produtosTable.Rows.Select(row =>
        {
            var id = Guid.Parse(row["Id"]);
            var name = row["Name"];
            var description = row["Description"];
            var price = decimal.Parse(row["Price"]);
            var categoria = new Categoria { Name = row["Categoria"] };

            return new RegistroProduto(id)
            {
                Name = name,
                Description = description,
                Price = price,
                Categoria = categoria
            };
        }).ToList();

        dbContext.Produto.AddRange(produtos);
        await dbContext.SaveChangesAsync();
    }

    [When(@"for consultado o produto com id (.*)")]
    public async Task WhenRetrievingProductById(Guid productId)
    {
        var getProdutoRoute = $"Produto/{productId}";
        try
        {
            var httpResponse = await produtoApiClient.GetAsync(getProdutoRoute);
            ScenarioContext.Current["HttpResponse"] = httpResponse;
            if (httpResponse.IsSuccessStatusCode)
            {
                var produto = await httpResponse.Content.ReadFromJsonAsync<RegistroProduto>(jsonOptions);
                ScenarioContext.Current["RetrievedProduct"] = produto;
            }
            else
            {
                ScenarioContext.Current["RetrievedProduct"] = null;
            }
        }
        catch (HttpRequestException ex)
        {
            ScenarioContext.Current["Exception"] = ex;
        }
        catch (ProdutoNotFoundException ex)
        {
            ScenarioContext.Current["Exception"] = ex;
        }
    }


    [Then(@"deve retornar o produto")]
    public void ThenShouldReturnTheProduct()
    {
        var produto = ScenarioContext.Current["RetrievedProduct"] as RegistroProduto;
        produto.Should().NotBeNull();
        produto!.Name.Should().Be("Lanche A");
        produto.Price.Should().Be(14.99m);
        produto.Categoria.Name.Should().Be("Lanche");
    }

    [Then(@"deve retornar status não encontrado")]
    public void ThenShouldThrowProductNotFoundException()
    {
        var httpResponse = ScenarioContext.Current["HttpResponse"] as HttpResponseMessage;
        httpResponse.Should().NotBeNull("a response should have been captured");

        httpResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound, because: "the product does not exist in the database");

        var retrievedProduct = ScenarioContext.Current["RetrievedProduct"];
        retrievedProduct.Should().BeNull("no product should be returned for a nonexistent ID");
    }

        public void Dispose()
    {
        scope.Dispose();
    }
}
