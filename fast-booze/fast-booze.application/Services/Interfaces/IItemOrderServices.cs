using fast_booze.application.ViewModel;
using fast_booze.Entities;

namespace fast_booze.application.Services.Interfaces
{
    public interface IItemOrderServices : IDisposable
    {
        IEnumerable<ItemOrderViewModel> GetAll();
        ItemOrderViewModel GetById(Guid id);
        Task<ItemOrderViewModel> Update(ItemOrderViewModel vm);
        Task<ItemOrderViewModel> Add(ItemOrderViewModel vm);
        Task<bool> Remove(Guid id);
        IEnumerable<ItemOrderViewModel> GetItemOrders();
    }
}