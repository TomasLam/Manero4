using Microsoft.EntityFrameworkCore;
using Manero.Api.Models;

namespace Manero.Api.Data
{
    public class ManeroContext : DbContext
    {
        public ManeroContext(DbContextOptions<ManeroContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}
