using ChickenExpress.Application.Features.ItemVariant.Command.GetAllItemVariant;
using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.ItemVariant.Command.GetItemVariantById
{
    public class GetItemVariantByIdHandler : ResponseHandler, IRequestHandler<GetItemVariantByIdQuery, Response<GetAlllItemVariantResponse>>
    {
        private readonly IItemVariantService _itemVariantService;

        public GetItemVariantByIdHandler(IItemVariantService itemVariantService)
        {
            _itemVariantService = itemVariantService;
        }

        public async Task<Response<GetAlllItemVariantResponse>> Handle(GetItemVariantByIdQuery request, CancellationToken cancellationToken)
        {
            var result =await _itemVariantService.GetItemVariantById(request.Id);
            if (result != null)
            {
                return Success(result, message: "The Item Variant Get Successfully");
            }
            return NotFound<GetAlllItemVariantResponse>();
        }
    }
}
