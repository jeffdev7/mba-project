using AutoMapper;
using fast_booze.application.Services.Interfaces;
using fast_booze.application.ViewModel;
using fast_booze.data.DBConfiguration;
using fast_booze.data.Repositories;
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
        private readonly IItemOrderRepository _itemOrderRepository;

        public OrderServices(IMapper mapper, IOrderRepository orderRepository, 
            ApplicationContext context, IItemOrderRepository itemOrderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _context = context;
            _itemOrderRepository = itemOrderRepository; 
        }

        public async Task<OrderViewModel> Add(OrderViewModel vm)
        {
            Order order = _mapper.Map<Order>(vm);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderViewModel>(order);
        }

        public IEnumerable<OrderListViewModel> GetOrders()
        {
            var orders = _orderRepository.GetOrders().ToList();
            var orderViewModels = new List<OrderListViewModel>();

            foreach (var pedido in orders)
            {
                var itemOrders = _itemOrderRepository.GetAll()
                    .Where(io => io.OrderId == pedido.Id)
                    .Select(io => new ItemOrderViewModel
                    {
                        BeverageId = io.BeverageId,
                        Quantity = io.Quantity,
                        UnitPrice = io.UnitPrice,

                    }).ToList();
                    

                var orderViewModel = new OrderListViewModel
                {
                    Id = pedido.Id,
                    CustomerId = pedido.CustomerId,
                    Items = itemOrders
                };

                orderViewModels.Add(orderViewModel);
            }

            return orderViewModels;

        }

        public OrderViewModel GetById(Guid id)
        {
            return _mapper.Map<OrderViewModel>(_orderRepository.GetById(id));
        }

        public async Task<bool> Remove(Guid id)
        {
            Order? order = await _context.Orders
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