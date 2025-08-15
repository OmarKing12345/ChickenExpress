using ChickenExpress.Application.ResponsesApi;
using ChickenExpress.Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItems
{
    public class GetMenuItemsHandler : ResponseHandler , IRequestHandler<GetMenuItemsQuery, Response<List<GetMenuItemsResponse>>>
    {
        private readonly IMenuItemService _menuItemService;

        public GetMenuItemsHandler(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        public async Task<Response<List<GetMenuItemsResponse>>> Handle(GetMenuItemsQuery request, CancellationToken cancellationToken)
        {
            var result = await _menuItemService.GetAllMenuItems();
            if(result.Count==0){
                return NotFound<List<GetMenuItemsResponse>>("Not Found");
            }
            return Success(result);
        }
    }
}
