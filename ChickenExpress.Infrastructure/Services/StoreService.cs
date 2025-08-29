using ChickenExpress.Application.Features.Store.Query.GetAllStores;
using ChickenExpress.Application.Features.Store.Query.GetStoreById;
using ChickenExpress.Application.Interfaces;
using ChickenExpress.Domain.Entities;
using ChickenExpress.Persistence.Repositories.IRepository;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Infrastructure.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<bool> AddStore(Store store)
        {
            var result = await _storeRepository.CreateAsync(store);
            if (result != null)
            {
                var saving = await _storeRepository.CommitAsync();
                if (saving)
                {
                    return true;
                }
            }
            return false;

        }

        public async Task<bool> DeleteStore(int Id)
        {
            var store = await _storeRepository.GetOneAsync(x => x.Id == Id);
            if (store != null) {
                var result = _storeRepository.Delete(store);
                if (result)
                {
                    var saving = await _storeRepository.CommitAsync();
                    if (saving)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public async Task<IEnumerable<Store>> GetAllStores()
        {
            var result = await _storeRepository.GetAsync();

            return result;
        }

        public async Task<Store> GetStoreById(int Id)
        {
            var result = await _storeRepository.GetOneAsync(x => x.Id == Id);
            return result;
        }

        public async Task<bool> UpdateStore(Store store)
        {
            var result = _storeRepository.Update(store);
            if (result != null)
            {
                var saving = await _storeRepository.CommitAsync();
                if (saving)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
