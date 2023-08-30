using fast_booze.Entities;
using fast_booze.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace fast_booze.data.DBConfiguration
{
    public interface IAppDbContext { }
    public class ApplicationContext : IdentityDbContext<ApplicationUser>, IAppDbContext
    {
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }
        public DbSet<LiquorStore> LiquorStores { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        public ApplicationContext() { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Beverage>().HasKey(_ => _.Id);
            builder.Entity<LiquorStore>().HasKey(_ => _.Id);

            builder.Entity<Customer>().HasKey(_ => _.Id);
            builder.Entity<Customer>().HasOne(_ => _.Order);

            builder.Entity<Order>().HasKey(_ => _.Id);
            builder.Entity<Order>()
                .HasMany(_ => _.Items)
                .WithOne(_ => _.Order);
            builder.Entity<Order>()
                .HasOne(_ => _.Customer)
                .WithOne(_ => _.Order).IsRequired();

            builder.Entity<ItemOrder>().HasKey(_ => _.Id);
            builder.Entity<ItemOrder>().HasOne(_ => _.Order);
            builder.Entity<ItemOrder>().HasOne(_ => _.Beverage);

            builder.Entity<Stock>().HasKey(_ => _.Id);
            builder.Entity<Stock>().HasMany(_ => _.Beverages);
            builder.Entity<Stock>().HasOne(_ => _.LiquorStore);

            base.OnModelCreating(builder);
        }
    }
}