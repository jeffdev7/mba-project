using fast_booze.data.DBConfiguration;
using fast_booze.Entities;
using fast_booze.Repositories.Interfaces;

namespace fast_booze.data.Repositories
{
    public sealed class ItemOrderRepository : Repository<ItemOrder>, IItemOrderRepository
    {
        public ItemOrderRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<ItemOrder> GetItemOrders()
        {
            return _context.ItemOrders;
        }
    }
}