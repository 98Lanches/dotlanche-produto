using Dotlanche.Produto.BDDTests.Setup;
using DotLanche.Produto.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Dotlanche.Produto.Data.DatabaseContext;
using System.Net;
using System.Net.Http.Json;

namespace Dotlanche.Produto.BDDTests.StepDefinitions;

[Binding]
public sealed class DeletarProdutoSteps : IDisposable
{
    private readonly HttpClient produtoApiClient;
    private readonly JsonSerializerOptions jsonOptions = new() { PropertyNameCaseInsensitive = true };
    private readonly IServiceScope scope;

    public DeletarProdutoSteps(ProdutoApi produtoApi)
    {
        produtoApiClient = produtoApi.CreateClient();
        scope = produtoApi.Services.CreateScope();
    }

    [When(@"solicitar que delete o produto com id (.*)")]
    public async Task WhenRequestingToDeleteProduct(Guid idProduto)
    {
        var deleteProdutoRoute = $"Produto/{idProduto}";

        var httpResponse = await produtoApiClient.DeleteAsync(deleteProdutoRoute);
        ScenarioContext.Current["HttpResponse"] = httpResponse;

        if (httpResponse.IsSuccessStatusCode)
        {
            var deletedProduto = await httpResponse.Content.ReadFromJsonAsync<RegistroProduto>(jsonOptions);
            ScenarioContext.Current["DeletedProduct"] = deletedProduto;
        }
        else
        {
            ScenarioContext.Current["DeletedProduct"] = null;
        }
    }

    [Then(@"deve apagar o registro")]
    public async Task ThenShouldDeleteTheRecord()
    {
        var httpResponse = ScenarioContext.Current["HttpResponse"] as HttpResponseMessage;
        httpResponse.Should().NotBeNull("a response should have been captured");
        httpResponse!.StatusCode.Should().Be(HttpStatusCode.OK, "the deletion should succeed");

        var deletedProduto = ScenarioContext.Current["DeletedProduct"] as RegistroProduto;
        deletedProduto.Should().NotBeNull("the deleted product should be returned");

        var dbContext = scope.ServiceProvider.GetRequiredService<ProdutoDbContext>();
        var produtoInDb = await dbContext.Produto.FindAsync(deletedProduto!.Id);
        produtoInDb.Should().BeNull("the product should no longer exist in the database");
    }

    [Then(@"retornar o objeto apagado")]
    public void ThenShouldReturnTheDeletedObject()
    {
        var deletedProduto = ScenarioContext.Current["DeletedProduct"] as RegistroProduto;
        deletedProduto.Should().NotBeNull("the deleted product should be returned");

        deletedProduto!.Id.Should().Be(Guid.Parse("c0a518e4-f51c-4ca6-94a7-f343c1a1b338"), "the deleted product ID should match the requested ID");
        deletedProduto.Name.Should().Be("Lanche A", "the deleted product name should match the original product");
    }

    public void Dispose()
    {
        scope.Dispose();
    }
}
