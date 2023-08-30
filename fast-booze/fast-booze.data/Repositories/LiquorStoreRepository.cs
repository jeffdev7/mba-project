using fast_booze.data.DBConfiguration;
using fast_booze.Entities;
using fast_booze.Repositories.Interfaces;

namespace fast_booze.data.Repositories
{
    public sealed class LiquorStoreRepository : Repository<LiquorStore>, ILiquorStoreRepository
    {
        public LiquorStoreRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<LiquorStore> GetLiquorStores()
        {
            return _context.LiquorStores;
        }
    }
}