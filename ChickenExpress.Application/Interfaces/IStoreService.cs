using ChickenExpress.Application.Features.Store.Query.GetAllStores;
using ChickenExpress.Application.Features.Store.Query.GetStoreById;
using ChickenExpress.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Interfaces
{
    public interface IStoreService
    {
        Task<IEnumerable<Store>> GetAllStores();
        Task<Store> GetStoreById(int Id);

        Task<bool> AddStore(Store store);

        Task<bool> DeleteStore(int Id);
        Task<bool> UpdateStore(Store store);
    }
}
