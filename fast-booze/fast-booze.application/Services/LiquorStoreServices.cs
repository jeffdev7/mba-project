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
    public sealed class LiquorStoreServices : ILiquorStoreServices
    {
        private readonly IMapper _mapper;
        private readonly ILiquorStoreRepository _liquorStoreRepository;
        private readonly ApplicationContext _context;

        public LiquorStoreServices(IMapper mapper, ILiquorStoreRepository liquorStoreRepository, ApplicationContext context)
        {
            _mapper = mapper;
            _liquorStoreRepository = liquorStoreRepository;
            _context = context;
        }

        public async Task<LiquorStoreViewModel> Add(LiquorStoreViewModel vm)
        {
            LiquorStore liquorStore = _mapper.Map<LiquorStore>(vm);
            _context.LiquorStores.Add(liquorStore);
            await _context.SaveChangesAsync();
            return _mapper.Map<LiquorStoreViewModel>(liquorStore);
        }

        public IEnumerable<LiquorStoreViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<LiquorStoreViewModel>>
               (_liquorStoreRepository.GetAll());
        }

        public IEnumerable<LiquorStoreViewModel> GetLiquorStores()
        {
            return _mapper.Map<IEnumerable<LiquorStoreViewModel>>(_liquorStoreRepository.GetLiquorStores());

        }

        public LiquorStoreViewModel GetById(Guid id)
        {
            return _mapper.Map<LiquorStoreViewModel>(_liquorStoreRepository.GetById(id));
        }

        public async Task<bool> Remove(Guid id)
        {
            LiquorStore liquorStore = await _context.LiquorStores
               .Where(p => p.Id == id).SingleOrDefaultAsync();

            if (liquorStore == null)
                return false;

            _context.LiquorStores.Remove(liquorStore);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<LiquorStoreViewModel> Update(LiquorStoreViewModel vm)
        {
            LiquorStore liquorStore = _mapper.Map<LiquorStore>(vm);
            _context.LiquorStores.Update(liquorStore);
            await _context.SaveChangesAsync();
            return _mapper.Map<LiquorStoreViewModel>(liquorStore);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}