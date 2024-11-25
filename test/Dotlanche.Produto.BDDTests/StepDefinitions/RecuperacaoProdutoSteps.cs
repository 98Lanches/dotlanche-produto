﻿using Dotlanche.Produto.BDDTests.Setup;
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

    [When(@"for consultada a categoria (.*)")]
    public async Task WhenRetrievingProductByCategory(int idCategoria)
    {
        var getProdutoRoute = $"Produto/categoria?idCategoria={idCategoria}";
        try
        {
            var httpResponse = await produtoApiClient.GetAsync(getProdutoRoute);
            ScenarioContext.Current["HttpResponse"] = httpResponse;

            if (httpResponse.IsSuccessStatusCode)
            {
                var produtos = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<RegistroProduto>>(jsonOptions);
                ScenarioContext.Current["RetrievedProduct"] = produtos;
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

    [Then(@"deve retornar apenas os produtos dessa categoria")]
    public void ThenShouldReturnTheProductsForGivenCategory()
    {
        var listaProdutos = ScenarioContext.Current["RetrievedProduct"] as IEnumerable<RegistroProduto>;
        listaProdutos.Should().NotBeNull("a list of products should have been retrieved");

        int expectedCategoriaId = 1;

        listaProdutos!.Should().NotBeEmpty("at least one product should belong to the specified category");
        listaProdutos.Should().OnlyContain(produto => produto.Categoria.Id == expectedCategoriaId,
            because: "all retrieved products should belong to the specified category");
    }

    [When(@"for consultado a lista de produtos com ids (.*)")]
    public async Task WhenRetrievingListOfProductsByIds(string ids)
    {
        var getProdutoRoute = $"Produto?orderList={ids}";
        try
        {
            var httpResponse = await produtoApiClient.GetAsync(getProdutoRoute);
            ScenarioContext.Current["HttpResponse"] = httpResponse;

            if (httpResponse.IsSuccessStatusCode)
            {
                var produtos = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<RegistroProduto>>(jsonOptions);
                ScenarioContext.Current["RetrievedProducts"] = produtos;
            }
            else
            {
                ScenarioContext.Current["RetrievedProducts"] = null;
            }
        }
        catch (HttpRequestException ex)
        {
            ScenarioContext.Current["Exception"] = ex;
        }
    }

    [Then(@"deve retornar os produtos")]
    public void ThenShouldReturnTheProducts()
    {
        var retrievedProducts = ScenarioContext.Current["RetrievedProducts"] as IEnumerable<RegistroProduto>;
        retrievedProducts.Should().NotBeNull("the products should have been retrieved successfully");

        var expectedIds = new List<Guid>
        {
            Guid.Parse("b0a518e4-f51c-4ca6-94a7-f343c1a1b339"),
            Guid.Parse("1dabcc03-e5a0-407b-a876-d65b6c05c23d")
        };

        retrievedProducts!.Should().HaveCount(expectedIds.Count, because: "all products with the specified IDs should be returned");
        retrievedProducts.Select(p => p.Id).Should().BeEquivalentTo(expectedIds, because: "the retrieved products should match the requested IDs");
    }


    public void Dispose()
    {
        scope.Dispose();
    }
}
