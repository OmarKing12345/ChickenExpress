using ChickenExpress.Application.ResponsesApi;
using ChickenExpress.Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItemById
{
    public class GetMenuItemByIdHandler : ResponseHandler,IRequestHandler<GetMenuItemByIdQuery, Response<GetMenuItemByIdResponse>>
    {
        private readonly IMenuItemService _menuItemService;

        public GetMenuItemByIdHandler(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        public async Task<Response<GetMenuItemByIdResponse>> Handle(GetMenuItemByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _menuItemService.GetMenuItemById(request.MenuItemId);
            if (result == null) {
                return NotFound<GetMenuItemByIdResponse>("MenuItemNotFound");
            }
            return Success(result);


        }
    }
}
