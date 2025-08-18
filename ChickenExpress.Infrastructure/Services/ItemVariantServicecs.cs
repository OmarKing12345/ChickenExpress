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
    }
}
