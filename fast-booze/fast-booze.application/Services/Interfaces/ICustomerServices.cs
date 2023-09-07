using fast_booze.application.ViewModel;

namespace fast_booze.application.Services.Interfaces
{
    public interface ICustomerServices : IDisposable
    {
        CustomerViewModel GetById(Guid id);
        Task<CustomerViewModel> Update(CustomerViewModel vm);
        Task<CustomerViewModel> Add(CustomerViewModel vm);
        Task<bool> Remove(Guid id);
        IEnumerable<CustomerViewModel> GetCustomers();
    }
}