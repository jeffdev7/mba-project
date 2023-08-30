using fast_booze.data.DBConfiguration;
using fast_booze.Entities;
using fast_booze.Repositories.Interfaces;

namespace fast_booze.data.Repositories
{
    public sealed class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<Order> GetOrders()
        {
            return _context.Orders;
        }
    }
}