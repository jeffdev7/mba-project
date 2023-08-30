using fast_booze.application.ViewModel;
using fast_booze.Entities;

namespace fast_booze.application.Services.Interfaces
{
    public interface IStockServices : IDisposable
    {
        IEnumerable<StockViewModel> GetAll();
        StockViewModel GetById(Guid id);
        Task<StockViewModel> Update(StockViewModel vm);
        Task<StockViewModel> Add(StockViewModel vm);
        Task<bool> Remove(Guid id);
        IEnumerable<StockViewModel> GetStock();
    }
}