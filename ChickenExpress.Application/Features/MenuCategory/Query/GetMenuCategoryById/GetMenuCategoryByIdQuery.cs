using ChickenExpress.Application.Features.MenuCategory.Query.GetMenuCategories;
using ChickenExpress.Application.ResponsesApi;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Application.Features.MenuCategory.Query.GetMenuCategoryById
{
    public record GetMenuCategoryByIdQuery(int Id):IRequest<Response<GetMenuCategoryByIdResponse>>
    {
    }
}
