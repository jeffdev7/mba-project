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
    public sealed class BeverageServices : IBeverageServices
    {
        private readonly IMapper _mapper;
        private readonly IBeverageRepository _beverageRepository;
        private readonly ApplicationContext _context;

        public BeverageServices(IMapper mapper, IBeverageRepository beverageRepository, ApplicationContext context)
        {
            _mapper = mapper;
            _beverageRepository = beverageRepository;
            _context = context;
        }

        public async Task<BeverageViewModel> Add(BeverageViewModel vm)
        {
            Beverage beverage = _mapper.Map<Beverage>(vm);
            _context.Beverages.Add(beverage);
            await _context.SaveChangesAsync();
            return _mapper.Map<BeverageViewModel>(beverage);
        }

        public IEnumerable<BeverageViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<BeverageViewModel>>
               (_beverageRepository.GetAll());
        }

        public IEnumerable<BeverageViewModel> GetBeverages()
        {
            return _mapper.Map<IEnumerable<BeverageViewModel>>(_beverageRepository.GetBeverages());

        }

        public BeverageViewModel GetById(Guid id)
        {
            return _mapper.Map<BeverageViewModel>(_beverageRepository.GetById(id));
        }

        public async Task<bool> Remove(Guid id)
        {
            Beverage beverage = await _context.Beverages
               .Where(p => p.Id == id).SingleOrDefaultAsync();

            if (beverage == null)
                return false;

            _context.Beverages.Remove(beverage);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<BeverageViewModel> Update(BeverageViewModel vm)
        {
            Beverage beverage = _mapper.Map<Beverage>(vm);
            _context.Beverages.Update(beverage);
            await _context.SaveChangesAsync();
            return _mapper.Map<BeverageViewModel>(beverage);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}