using ChickenExpress.Application.Features.Store.Command.AddStore;
using ChickenExpress.Application.Interfaces;
using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.Store.Command.Delete_Store
{
    public class DeleteStoreHandler : ResponseHandler, IRequestHandler<DeleteStoreCommand, Response<bool>>
    {
        private readonly IStoreService _storeService;

        public DeleteStoreHandler(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public async Task<Response<bool>> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            var result = await _storeService.DeleteStore(request.id);
            if (result)
            {
                return Deleted<bool>();
            }
            return BadRequest<bool>();
        }
    }
}
