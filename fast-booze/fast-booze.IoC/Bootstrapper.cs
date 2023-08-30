using fast_booze.data.DBConfiguration;
using fast_booze.data.Repositories;
using fast_booze.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace fast_booze.IoC
{
    public sealed class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<IBeverageRepository, BeverageRepository>();
            service.AddScoped<ICustomerRepository, CustomerRepository>();
            service.AddScoped<IItemOrderRepository, ItemOrderRepository>();
            service.AddScoped<ILiquorStoreRepository, LiquorStoreRepository>();
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<IStockRepository, StockRepository>();



            service.AddTransient<IAppDbContext, ApplicationContext>();
        }
    }
}