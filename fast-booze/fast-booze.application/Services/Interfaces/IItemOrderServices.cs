using fast_booze.application.ViewModel;

namespace fast_booze.application.Services.Interfaces
{
    public interface IItemOrderServices : IDisposable
    {
        ItemOrderViewModel GetById(Guid id);
        Task<ItemOrderViewModel> Update(ItemOrderViewModel vm);
        Task<ItemOrderViewModel> Add(ItemOrderViewModel vm);
        Task<bool> Remove(Guid id);
        IEnumerable<ItemOrderViewModel> GetItemOrders();
    }
}