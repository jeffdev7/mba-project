using fast_booze.application.ViewModel;

namespace fast_booze.application.Services.Interfaces
{
    public interface IOrderServices : IDisposable
    {
        OrderViewModel GetById(Guid id);
        Task<OrderViewModel> Update(OrderViewModel vm);
        Task<OrderViewModel> Add(OrderViewModel vm);
        Task<bool> Remove(Guid id);
        IEnumerable<OrderListViewModel> GetOrders();
    }
}