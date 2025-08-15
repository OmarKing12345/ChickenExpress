using ChickenExpress.Application.ResponsesApi;
using ChickenExpress.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItems
{
    public class GetMenuItemsQuery:IRequest<Response<List<GetMenuItemsResponse>>>
    {

    }
}
