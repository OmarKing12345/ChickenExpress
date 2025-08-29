using ChickenExpress.Application.Features.ItemVariant.Command.GetAllItemVariant;
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
    public class ItemVariantServicecs : IItemVariantService
    {
        private readonly IItemVariantRepository _repository;

        public ItemVariantServicecs(IItemVariantRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddItemVariant(ItemVariant itemVariant)
        {
            var result = await _repository.CreateAsync(itemVariant);
            if (result != null)
            {
                await _repository.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteItemVariant(int ItemVariantId)
        {
            var CurrentItemVariant = await _repository.GetOneAsync(x => x.Id == ItemVariantId);
            if (CurrentItemVariant != null) {
                var result = _repository.Delete(CurrentItemVariant);
                if (result)
                {
                    await _repository.CommitAsync();
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<List<GetAlllItemVariantResponse>> GetAllItemVariant()
        {
            var result = await _repository.GetAsync();
            return result.Adapt<List<GetAlllItemVariantResponse>>();
        }

        public async Task<GetAlllItemVariantResponse> GetItemVariantById(int Id)
        {
            var result = await _repository.GetOneAsync(x=>x.Id == Id);
            return result.Adapt<GetAlllItemVariantResponse>();
        }

        public async Task<bool> UpdateItemVariant(ItemVariant itemVariant)
        {
            var ItemVariantInDB = await _repository.GetOneAsync(x => x.Id == itemVariant.Id);
            if(ItemVariantInDB==null)
                return false;
            ItemVariantInDB.MenuItemId = itemVariant.MenuItemId != null ? itemVariant.MenuItemId : ItemVariantInDB.MenuItemId;
            ItemVariantInDB.Price = itemVariant.Price!=null?itemVariant.Price:ItemVariantInDB.Price;            ItemVariantInDB.Price = itemVariant.Price!=null?itemVariant.Price:ItemVariantInDB.Price;
            ItemVariantInDB.Name = itemVariant.Name != null ? itemVariant.Name : ItemVariantInDB.Name;

            var result = _repository.Update(ItemVariantInDB);
            if (result != null)
            {
                await _repository.CommitAsync();
                return true;
            }
            return false;



        }
    }
}
