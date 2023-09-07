using fast_booze.application.ViewModel;

namespace fast_booze.application.Services.Interfaces
{
    public interface IStockServices : IDisposable
    {
        StockViewModel GetById(Guid id);
        Task<StockViewModel> Update(StockViewModel vm);
        Task<StockViewModel> Add(StockViewModel vm);
        Task<bool> Remove(Guid id);
        IEnumerable<StockListViewModel> GetStock();
    }
}