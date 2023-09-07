using AutoMapper;
using fast_booze.application.Services.Interfaces;
using fast_booze.application.ViewModel;
using fast_booze.data.DBConfiguration;
using fast_booze.Entities;
using fast_booze.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace fast_booze.application.Services
{
    public sealed class StockServices : IStockServices
    {
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;
        private readonly ApplicationContext _context;
        private readonly IBeverageRepository _beverageRepository;

        public StockServices(IMapper mapper, IStockRepository stockRepository, 
            ApplicationContext context, IBeverageRepository beverageRepository)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
            _context = context;
            _beverageRepository = beverageRepository;
        }

        public async Task<StockViewModel> Add(StockViewModel vm)
        {
            Stock stock = _mapper.Map<Stock>(vm);
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();

            var stockvm = new StockViewModel
            {
                Beverages = vm.Beverages,   
                AveragePrice = stock.AveragePrice,
                QuantityInStock = stock.QuantityInStock,
                Discount = stock.Discount,
                hasDiscount = stock.hasDiscount
            };
            return stockvm;
        }

        public IEnumerable<StockListViewModel> GetStock()
        {
            var stocks = _stockRepository.GetStocks().ToList();
            var stockViewModels = new List<StockListViewModel>();

            foreach (var stock in stocks)
            {
                var productViewModels = _beverageRepository.GetAll()
                    .Select(b => new BeverageViewModel
                    {
                        Id = b.Id,
                        Name = b.Name,
                        Code = b.Code,
                        Brand = b.Brand,    
                        Price = b.Price
                    })
                    .ToList();

                var stockViewModel = new StockListViewModel
                {
                    Id = stock.Id,
                    LiquorStoreId = stock.LiquorStoreId,
                    Beverages = productViewModels,
                    QuantityInStock = stock.QuantityInStock,
                    AveragePrice = stock.AveragePrice,
                    hasDiscount = stock.hasDiscount,
                    Discount = stock.Discount
                };

                stockViewModels.Add(stockViewModel);
            }

            return stockViewModels;
        }

        public StockViewModel GetById(Guid id)
        {
            return _mapper.Map<StockViewModel>(_stockRepository.GetById(id));
        }

        public async Task<bool> Remove(Guid id)
        {
            Stock? stock = await _context.Stocks
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