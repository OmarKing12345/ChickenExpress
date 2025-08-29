using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.Store.Query.GetStoreById
{
    internal class GetStoreByIdHandler : ResponseHandler, IRequestHandler<GetStoreByIdQuery, Response<GetStoreByIdResponse>>
    {

        private readonly IStoreService _storeService;
        public GetStoreByIdHandler(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public async Task<Response<GetStoreByIdResponse>> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _storeService.GetStoreById(request.Id);
            if (result != null) {
                var response = result.Adapt<GetStoreByIdResponse>();
                return Success(response, message:"the Store Get Successfully");
            
            }
            return NotFound<GetStoreByIdResponse>();
        
        }
    }
}
