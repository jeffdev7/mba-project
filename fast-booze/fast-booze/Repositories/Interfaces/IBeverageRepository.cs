using fast_booze.Entities;

namespace fast_booze.Repositories.Interfaces
{
    public interface IBeverageRepository : IRepository<Beverage>
    {
        IQueryable<Beverage> GetBeverages();
    }
}