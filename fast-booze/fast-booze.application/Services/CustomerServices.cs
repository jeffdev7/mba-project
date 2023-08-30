using AutoMapper;
using fast_booze.application.Services.Interfaces;
using fast_booze.application.ViewModel;
using fast_booze.data.DBConfiguration;
using fast_booze.Entities;
using fast_booze.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace fast_booze.application.Services
{
    public sealed class CustomerServices : ICustomerServices
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly ApplicationContext _context;

        public CustomerServices(IMapper mapper, ICustomerRepository customerRepository, ApplicationContext context)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _context = context;
        }

        public async Task<CustomerViewModel> Add(CustomerViewModel vm)
        {
            Customer customer = _mapper.Map<Customer>(vm);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return _mapper.Map<CustomerViewModel>(customer);
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>
               (_customerRepository.GetAll());
        }

        public IEnumerable<CustomerViewModel> GetCustomer()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(_customerRepository.GetCustomers());

        }

        public CustomerViewModel GetById(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(_customerRepository.GetById(id));
        }

        public async Task<bool> Remove(Guid id)
        {
            Customer customer = await _context.Customers
               .Where(p => p.Id == id).SingleOrDefaultAsync();

            if (customer == null)
                return false;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CustomerViewModel> Update(CustomerViewModel vm)
        {
            Customer customer = _mapper.Map<Customer>(vm);
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return _mapper.Map<CustomerViewModel>(customer);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}