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
    public sealed class StockServices : IStockServices
    {
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;
        private readonly ApplicationContext _context;

        public StockServices(IMapper mapper, IStockRepository stockRepository, ApplicationContext context)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
            _context = context;
        }

        public async Task<StockViewModel> Add(StockViewModel vm)
        {
            Stock stock = _mapper.Map<Stock>(vm);
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return _mapper.Map<StockViewModel>(stock);
        }

        public IEnumerable<StockViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<StockViewModel>>
               (_stockRepository.GetAll());
        }

        public IEnumerable<StockViewModel> GetStock()
        {
            return _mapper.Map<IEnumerable<StockViewModel>>(_stockRepository.GetStocks());

        }

        public StockViewModel GetById(Guid id)
        {
            return _mapper.Map<StockViewModel>(_stockRepository.GetById(id));
        }

        public async Task<bool> Remove(Guid id)
        {
            Stock stock = await _context.Stocks
               .Where(p => p.Id == id).SingleOrDefaultAsync();

            if (stock == null)
                return false;

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<StockViewModel> Update(StockViewModel vm)
        {
            Stock stock = _mapper.Map<Stock>(vm);
            _context.Stocks.Update(stock);
            await _context.SaveChangesAsync();
            return _mapper.Map<StockViewModel>(stock);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}