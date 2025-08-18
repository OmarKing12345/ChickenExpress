using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.ItemVariant.Command.GetAllItemVariant
{
    public class GetAllItemVariantHandler : ResponseHandler, IRequestHandler<GetAllItemVariantQuery, Response<List<GetAlllItemVariantResponse>>>
    {
        private readonly IItemVariantService _itemVariantService;

        public GetAllItemVariantHandler(IItemVariantService itemVariantService)
        {
            _itemVariantService = itemVariantService;
        }

        public async Task<Response<List<GetAlllItemVariantResponse>>> Handle(GetAllItemVariantQuery request, CancellationToken cancellationToken)
        {
            var result = await _itemVariantService.GetAllItemVariant();
            if (result != null)
            {
                return Success(result,message: "The Item Variant Get Successfully");
            }
            return NotFound<List<GetAlllItemVariantResponse>>();
        }
    }
}
