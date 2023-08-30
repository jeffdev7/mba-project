using fast_booze.data.DBConfiguration;
using fast_booze.Entities;
using fast_booze.Repositories.Interfaces;

namespace fast_booze.data.Repositories
{
    public sealed class BeverageRepository : Repository<Beverage>, IBeverageRepository
    {
        public BeverageRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<Beverage> GetBeverages()
        {
            return _context.Beverages;
        }
    }
}