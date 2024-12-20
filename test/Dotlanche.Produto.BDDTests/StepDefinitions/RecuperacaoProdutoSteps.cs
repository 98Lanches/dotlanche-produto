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

        var categoriasMap = new Dictionary<int, Categoria>();

        foreach (var row in produtosTable.Rows)
        {
            var id = Guid.Parse(row["Id"]);
            var name = row["Name"];
            var description = row["Description"];
            var price = decimal.Parse(row["Price"]);
            var idCategoria = int.Parse(row["idCategoria"]);
            var categoriaName = row["Categoria"];

            var categoria = await dbContext.Categoria
                .FirstOrDefaultAsync(c => c.Id == idCategoria);

            if (categoria is null)
            {
                categoria = new Categoria { Id = idCategoria, Name = categoriaName };
                dbContext.Categoria.Add(categoria);
            }

            var produto = new RegistroProduto(id)
            {
                Name = name,
                Description = description,
                Price = price,
                Categoria = categoria
            };

            dbContext.Produto.Add(produto);
        }

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

    [When(@"for consultado o produto com nome (.*)")]
    public async Task WhenRetrievingProductByName(string nomeProduto)
    {
        var getProdutoRoute = $"Produto/nome?nomeProduto={nomeProduto}";
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

    [Then(@"deve retornar o produto Lanche A")]
    public void ThenShouldReturnTheProductA()
    {
        var produto = ScenarioContext.Current["RetrievedProduct"] as RegistroProduto;
        produto.Should().NotBeNull();
        produto!.Name.Should().Be("Lanche A");
        produto.Price.Should().Be(14.99m);
        produto.Categoria.Name.Should().Be("Lanche");
    }

    [Then(@"deve retornar o produto Lanche C")]
    public void ThenShouldReturnTheProductC()
    {
        var produto = ScenarioContext.Current["RetrievedProduct"] as RegistroProduto;
        produto.Should().NotBeNull();
        produto!.Name.Should().Be("Lanche C");
        produto.Price.Should().Be(17.99m);
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

    [Then(@"deve retornar os produtos Lanche D e Bebida D")]
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

    [When(@"for consultado a lista de produtos de categoria (.*)")]
    public async Task WhenRetrievingListOfProductsByCategory(int idCategoria)
    {
        var getProdutoRoute = $"Produto/categoria?idCategoria={idCategoria}";
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

    [Then(@"deve retornar produtos com a categoria Lanche")]
    public void ThenShouldReturnProductsWithCategoryLanche()
    {
        var produtos = ScenarioContext.Current["RetrievedProducts"] as IEnumerable<RegistroProduto>;
        produtos.Should().NotBeNull("a list of products should have been retrieved");
        produtos!.Should().NotBeEmpty("at least one product should be returned");
        produtos.Should().OnlyContain(produto => produto.Categoria.Id == 1,
            because: "all retrieved products should belong to the category with id 1");
    }


    public void Dispose()
    {
        scope.Dispose();
    }
}
