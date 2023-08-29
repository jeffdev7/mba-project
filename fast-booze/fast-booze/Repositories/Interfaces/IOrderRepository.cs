using fast_booze.Entities;

namespace fast_booze.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IQueryable<Order> GetOrders();
    }
}