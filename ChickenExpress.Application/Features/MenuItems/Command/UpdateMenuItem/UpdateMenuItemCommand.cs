using ChickenExpress.Application.Features.MenuCategory.Query.GetMenuCategories;
using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItems;
using ChickenExpress.Application.ResponsesApi;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.MenuItems.Command.UpdateMenuItem
{
    public record UpdateMenuItemCommand(int Id,int? CategoryId, string? Name, string? Description,
        IFormFile? ImageUrl, bool? IsActive):IRequest<Response<GetMenuItemsResponse>>
    {
    }
}
