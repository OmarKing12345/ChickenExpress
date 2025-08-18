using ChickenExpress.Application.Features.ItemVariant.Command.GetAllItemVariant;
using ChickenExpress.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Interfaces
{
    public interface IItemVariantService
    {
        Task<List<GetAlllItemVariantResponse>> GetAllItemVariant();
        Task<GetAlllItemVariantResponse> GetItemVariantById(int Id);
        Task<bool> AddItemVariant(ItemVariant itemVariant);
    }
}
