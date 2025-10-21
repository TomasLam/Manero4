using Manero.Api.Models;
using FluentAssertions;

namespace Manero.Tests;

public class ProductTests
{
    [Fact]
    public void Product_Should_Have_Valid_Defaults()
    {
        // Arrange
        var p = new Product
        {
            Name = "T-shirt",
            Description = "Blå bomullströja",
            Price = 199,
            Stock = 10
        };

        // Assert
        p.Id.Should().Be(0);  // ny produkt ska ha 0 innan den sparas
        p.Price.Should().BeGreaterThan(0);
        p.CreatedUtc.Should().BeBefore(DateTime.UtcNow.AddSeconds(1));
    }
}
