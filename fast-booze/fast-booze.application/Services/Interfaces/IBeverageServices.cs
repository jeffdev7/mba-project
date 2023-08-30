using fast_booze.application.ViewModel;
using fast_booze.Entities;

namespace fast_booze.application.Services.Interfaces
{
    public interface IBeverageServices : IDisposable
    {
        IEnumerable<BeverageViewModel> GetAll();
        BeverageViewModel GetById(Guid id);
        Task<BeverageViewModel> Update(BeverageViewModel vm);
        Task<BeverageViewModel> Add(BeverageViewModel vm);
        Task<bool> Remove(Guid id);
        IEnumerable<BeverageViewModel> GetBeverage();
    }
}