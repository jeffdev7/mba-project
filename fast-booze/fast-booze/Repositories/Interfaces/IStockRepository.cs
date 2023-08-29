using fast_booze.Entities;

namespace fast_booze.Repositories.Interfaces
{
    public interface IStockRepository : IRepository<Stock>
    {
        IQueryable<Stock> GetStocks();
    }
}