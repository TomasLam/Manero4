using System.Net;
using System.Net.Http.Json;
using Manero.Api.Models;
using Manero.Api.Data;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Manero.IntegrationTests;

public class ProductsApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ProductsApiTests(WebApplicationFactory<Program> factory)
    {
        // Skapar en klient mot testservern
        _client = factory.CreateClient();

        // Skapar databasen automatiskt för testmiljön
        using var scope = factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ManeroContext>();
        db.Database.EnsureCreated();
    }

    [Fact]
    public async Task GetProducts_Should_Return_OK_And_List()
    {
        var response = await _client.GetAsync("/api/products");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var products = await response.Content.ReadFromJsonAsync<List<Product>>();
        products.Should().NotBeNull();
    }

    [Fact]
    public async Task PostProduct_Should_Create_And_Return_201()
    {
        var newProduct = new Product
        {
            Name = "Testprodukt",
            Description = "För teständamål",
            Price = 10,
            Stock = 2
        };

        var response = await _client.PostAsJsonAsync("/api/products", newProduct);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}

