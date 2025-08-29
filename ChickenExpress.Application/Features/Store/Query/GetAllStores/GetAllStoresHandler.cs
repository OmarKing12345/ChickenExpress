using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.Store.Query.GetAllStores
{
    public class GetAllStoresHandler : ResponseHandler, IRequestHandler<GetAllStoresQuery, Response<List<GetAllStoresResponse>>>
    {
        private readonly IStoreService _storeService;

        public GetAllStoresHandler(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public async Task<Response<List<GetAllStoresResponse>>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
        {
            var result = await _storeService.GetAllStores();
            if (result != null)
            {
                var Response = result.Adapt<List<GetAllStoresResponse>>();
                return Success(Response, message: "the Stores get Successfully");
            }
            return NotFound<List<GetAllStoresResponse>>();
        }
    }
}
