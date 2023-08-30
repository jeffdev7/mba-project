using fast_booze.application.ViewModel;
using fast_booze.Entities;

namespace fast_booze.application.Services.Interfaces
{
    public interface IOrderServices : IDisposable
    {
        IEnumerable<OrderViewModel> GetAll();
        OrderViewModel GetById(Guid id);
        Task<OrderViewModel> Update(OrderViewModel vm);
        Task<OrderViewModel> Add(OrderViewModel vm);
        Task<bool> Remove(Guid id);
        IEnumerable<OrderViewModel> GetOrders();
    }
}