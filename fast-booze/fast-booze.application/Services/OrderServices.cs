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
    public sealed class OrderServices : IOrderServices
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly ApplicationContext _context;

        public OrderServices(IMapper mapper, IOrderRepository orderRepository, ApplicationContext context)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _context = context;
        }

        public async Task<OrderViewModel> Add(OrderViewModel vm)
        {
            Order order = _mapper.Map<Order>(vm);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderViewModel>(order);
        }

        public IEnumerable<OrderViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>
               (_orderRepository.GetAll());
        }

        public IEnumerable<OrderViewModel> GetOrders()
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>(_orderRepository.GetOrders());

        }

        public OrderViewModel GetById(Guid id)
        {
            return _mapper.Map<OrderViewModel>(_orderRepository.GetById(id));
        }

        public async Task<bool> Remove(Guid id)
        {
            Order order = await _context.Orders
               .Where(p => p.Id == id).SingleOrDefaultAsync();

            if (order == null)
                return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<OrderViewModel> Update(OrderViewModel vm)
        {
            Order order = _mapper.Map<Order>(vm);
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderViewModel>(order);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}