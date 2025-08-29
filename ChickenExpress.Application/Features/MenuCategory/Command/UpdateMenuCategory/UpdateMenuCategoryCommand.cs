using ChickenExpress.Application.Features.MenuCategory.Query.GetMenuCategories;
using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.MenuCategory.Command.UpdateMenuCategory
{
    public record UpdateMenuCategoryCommand(int Id,string?Name,int?SortedOrder,bool?IsActive):IRequest<Response<GetMenuCategoryResponse>>
    {

    }
}
