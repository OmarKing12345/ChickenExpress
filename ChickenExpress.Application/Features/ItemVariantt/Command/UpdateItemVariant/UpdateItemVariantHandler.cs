using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.ItemVariantt.Command.UpdateItemVariant
{
    internal class UpdateItemVariantHandler : ResponseHandler, IRequestHandler<UpdateItemVariantCommand, Response<bool>>
    {
        private readonly IItemVariantService _itemVariantService;

        public UpdateItemVariantHandler(IItemVariantService itemVariantService)
        {
            _itemVariantService = itemVariantService;
        }

        public async Task<Response<bool>> Handle(UpdateItemVariantCommand request, CancellationToken cancellationToken)
        {
            var itemVariant = new Domain.Entities.ItemVariant()
            {
                Id = request.Id,
                MenuItemId = request.MenuItemId.Value,
                Name = request.Name,
                Price = request.Price.Value

            };
            var result = await _itemVariantService.UpdateItemVariant(itemVariant);
            if (result)
            {
                return Success(result, message: "Item Variant Updated Successfully");
            }
            return BadRequest<bool>();
        }
    }
}
