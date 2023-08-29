using fast_booze.Entities;

namespace fast_booze.Repositories.Interfaces
{
    public interface ILiquorStoreRepository : IRepository<LiquorStore>
    {
        IQueryable<LiquorStore> GetLiquorStores();
    }
}