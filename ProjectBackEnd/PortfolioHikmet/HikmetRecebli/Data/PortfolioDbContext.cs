using HikmetRecebli.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HikmetRecebli.Data
{
    public class PortfolioDbContext: IdentityDbContext
    {

        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options):base(options) { }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OnlineAddress> OnlineAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            AppDbIntailazer.SeedDataAdd(builder);
        }

    }
}
