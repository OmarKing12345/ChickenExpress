using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenExpress.Application.ResponsesApi;
using MediatR;

namespace ChickenExpress.Application.Features.MenuItems.Queries.GetMenuCategories
{
    public class GetMenuCategoriesQuery :  IRequest<Response<List<GetMenuCategoryResponse>>>
    {

    }
}
