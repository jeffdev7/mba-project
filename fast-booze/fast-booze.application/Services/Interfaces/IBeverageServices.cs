using fast_booze.application.ViewModel;

namespace fast_booze.application.Services.Interfaces
{
    public interface IBeverageServices : IDisposable
    {
        BeverageViewModel GetById(Guid id);
        Task<BeverageViewModel> Update(BeverageViewModel vm);
        Task<BeverageViewModel> Add(BeverageViewModel vm);
        Task<bool> Remove(Guid id);
        IEnumerable<BeverageViewModel> GetBeverages();
    }
}