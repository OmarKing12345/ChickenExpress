using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.Store.Command.UpdateStore
{
    internal class UpdateStoreHandler : ResponseHandler, IRequestHandler<UpdateStoreCommand, Response<bool>>
    {
        private readonly IStoreService _storeService;

        public UpdateStoreHandler(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public async Task<Response<bool>> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var existing = await _storeService.GetStoreById(request.Id);
            if (existing == null)
                return NotFound<bool>();

            existing.AddressText = request.AddressText ?? existing.AddressText;
            existing.City = request.City ?? existing.City;
            existing.District = request.District ?? existing.District;
            existing.GeoLat = request.GeoLat ?? existing.GeoLat;
            existing.GeoLng = request.GeoLng ?? existing.GeoLng;
            existing.IsOpen = request.IsOpen;
            existing.Name = request.Name ?? existing.Name;

            var result = await _storeService.UpdateStore(existing);
            if (result)
            {
                return Success(result,message:"the store updated successfully");
            }
            return BadRequest<bool>();
        }
    }
}
