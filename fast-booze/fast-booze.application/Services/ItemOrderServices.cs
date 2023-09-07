using AutoMapper;
using fast_booze.application.Services.Interfaces;
using fast_booze.application.ViewModel;
using fast_booze.data.DBConfiguration;
using fast_booze.Entities;
using fast_booze.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fast_booze.application.Services
{
    public sealed class ItemOrderServices : IItemOrderServices
    {
        private readonly IMapper _mapper;
        private readonly IItemOrderRepository _itemOrderRepository;
        private readonly ApplicationContext _context;

        public ItemOrderServices(IMapper mapper, IItemOrderRepository itemOrderRepository, ApplicationContext context)
        {
            _mapper = mapper;
            _itemOrderRepository = itemOrderRepository;
            _context = context;
        }

        public async Task<ItemOrderViewModel> Add(ItemOrderViewModel vm)
        {
            ItemOrder itemOrder = _mapper.Map<ItemOrder>(vm);
            _context.ItemOrders.Add(itemOrder);
            await _context.SaveChangesAsync();
            return _mapper.Map<ItemOrderViewModel>(itemOrder);
        }

        public IEnumerable<ItemOrderViewModel> GetItemOrders()
        {
            return _mapper.Map<IEnumerable<ItemOrderViewModel>>(_itemOrderRepository.GetItemOrders());

        }

        public ItemOrderViewModel GetById(Guid id)
        {
            return _mapper.Map<ItemOrderViewModel>(_itemOrderRepository.GetById(id));
        }

        public async Task<bool> Remove(Guid id)
        {
            ItemOrder? itemOrder = await _context.ItemOrders
               .Where(p => p.Id == id).SingleOrDefaultAsync();

            if (itemOrder == null)
                return false;

            _context.ItemOrders.Remove(itemOrder);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ItemOrderViewModel> Update(ItemOrderViewModel vm)
        {
            ItemOrder itemOrder = _mapper.Map<ItemOrder>(vm);
            _context.ItemOrders.Update(itemOrder);
            await _context.SaveChangesAsync();
            return _mapper.Map<ItemOrderViewModel>(itemOrder);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}