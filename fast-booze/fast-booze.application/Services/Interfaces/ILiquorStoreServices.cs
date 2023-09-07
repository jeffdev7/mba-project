using fast_booze.application.ViewModel;

namespace fast_booze.application.Services.Interfaces
{
    public interface ILiquorStoreServices : IDisposable
    {
        LiquorStoreViewModel GetById(Guid id);
        Task<LiquorStoreViewModel> Update(LiquorStoreViewModel vm);
        Task<LiquorStoreViewModel> Add(LiquorStoreViewModel vm);
        Task<bool> Remove(Guid id);
        IEnumerable<LiquorStoreViewModel> GetLiquorStores();
    }
}