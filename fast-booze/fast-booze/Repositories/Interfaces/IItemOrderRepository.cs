using fast_booze.Entities;

namespace fast_booze.Repositories.Interfaces
{
    public interface IItemOrderRepository : IRepository<ItemOrder>
    {
        IQueryable<ItemOrder> GetItemOrders();
    }
}