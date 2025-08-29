using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.ItemVariantt.Command.DeleteItemVariant
{
    public class DeleteItemVariantHandler : ResponseHandler, IRequestHandler<DeleteItemVariantCommand, Response<bool>>
    {
        private readonly IItemVariantService _itemVariantService;

        public DeleteItemVariantHandler(IItemVariantService itemVariantService)
        {
            _itemVariantService = itemVariantService;
        }

        public async Task<Response<bool>> Handle(DeleteItemVariantCommand request, CancellationToken cancellationToken)
        {
            var result = await _itemVariantService.DeleteItemVariant(request.ItemVariantId);
            if (result)
            {
                return Success(result,message:"Item Variant Deleted Successfully");
            }
            return BadRequest<bool>();

        }
    }
}
