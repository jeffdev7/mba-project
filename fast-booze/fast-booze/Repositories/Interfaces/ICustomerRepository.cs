using fast_booze.Entities;

namespace fast_booze.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IQueryable<Customer> GetCustomers();
    }
}