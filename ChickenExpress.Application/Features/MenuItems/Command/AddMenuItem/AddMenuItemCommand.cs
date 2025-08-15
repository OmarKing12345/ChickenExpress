using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItems;
using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.MenuItems.Command.AddMenuItem
{
    public record AddMenuItemCommand(int CategoryId, string Name, string? Description,
        string? ImageUrl, bool IsActive):IRequest<Response<bool>>
    {
    }
}
