using fast_booze.data.DBConfiguration;
using fast_booze.Entities;
using fast_booze.Repositories.Interfaces;

namespace fast_booze.data.Repositories
{
    public sealed class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<Stock> GetStocks()
        {
            return _context.Stocks;
        }
    }
}