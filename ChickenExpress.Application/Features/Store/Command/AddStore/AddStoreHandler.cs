using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.Store.Command.AddStore
{
    internal class AddStoreHandler : ResponseHandler, IRequestHandler<AddStoreCommand, Response<bool>>
    {
        private readonly IStoreService _storeService;

        public AddStoreHandler(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public async Task<Response<bool>> Handle(AddStoreCommand request, CancellationToken cancellationToken)
        {
            var store = new Domain.Entities.Store()
            {
                AddressText = request.AddressText,
                City = request.City,
                District = request.District,
                GeoLat = request.GeoLat,
                GeoLng = request.GeoLng,
                IsOpen = request.IsOpen,
                Name = request.Name,

            };
            var result = await _storeService.AddStore(store);
            if (result)
            {
                return Success(result,message:"Store Add Successfully");
            }
            return BadRequest<bool>();
        }
    }
}
