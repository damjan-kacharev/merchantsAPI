using MerchantsApi.Models;
using Microsoft.EntityFrameworkCore;

using MerchantsApi.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MerchantsApi.Database
{
    public class MerchantDbContext: DbContext
    {
        public MerchantDbContext(DbContextOptions<MerchantDbContext> options): base(options)
        {

        }

        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Store> Stores { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Cascade;
            }
        }

    }
}
