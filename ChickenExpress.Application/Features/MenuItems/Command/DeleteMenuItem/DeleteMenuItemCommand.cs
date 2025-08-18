using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.MenuItems.Command.DeleteMenuItem
{
    public record DeleteMenuItemCommand(int MenuItemId):IRequest<Response<bool>>
    {
    }
}
