using fast_booze.application.ViewModel;
using fast_booze.Entities;

namespace fast_booze.application.Services.Interfaces
{
    public interface ICustomerServices : IDisposable
    {
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel GetById(Guid id);
        Task<CustomerViewModel> Update(CustomerViewModel vm);
        Task<CustomerViewModel> Add(CustomerViewModel vm);
        Task<bool> Remove(Guid id);
        IEnumerable<CustomerViewModel> GetCustomers();
    }
}