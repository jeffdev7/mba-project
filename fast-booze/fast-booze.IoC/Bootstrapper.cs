using fast_booze.application.Services;
using fast_booze.application.Services.Interfaces;
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

            service.AddScoped<IBeverageServices, BeverageServices>();
            service.AddScoped<ICustomerServices, CustomerServices>();
            service.AddScoped<IItemOrderServices, ItemOrderServices>();
            service.AddScoped<ILiquorStoreServices, LiquorStoreServices>();
            service.AddScoped<IOrderServices, OrderServices>();
            service.AddScoped<IStockServices, StockServices>();

            service.AddTransient<IAppDbContext, ApplicationContext>();
        }
    }
}